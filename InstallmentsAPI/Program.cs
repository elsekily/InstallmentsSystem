using System.Text;
using InstallmentsAPI.Core;
using InstallmentsAPI.Entities.Models;
using InstallmentsAPI.Entities.Resources;
using InstallmentsAPI.Persistence;
using InstallmentsAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddAuthorization(config =>
            {
                config.AddPolicy(Policies.Admin, Policies.Policy(Policies.Admin));
                config.AddPolicy(Policies.Moderator, Policies.Policy(Policies.Moderator));
            });

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddDbContext<InstallmentsDbContext>(options =>
    options.UseSqlite("Filename=../Yaseen.db"));

builder.Services.AddIdentity<User, Role>()
   .AddEntityFrameworkStores<InstallmentsDbContext>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IInstallmentRepository, InstallmentsRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentsRepository>();
builder.Services.AddScoped<IClientRepository, ClientsRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseStaticFiles();

app.UseRouting();
//app.UseHttpLogging();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<InstallmentsDbContext>();
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<Role>>();
    context.Database.Migrate();
    Seed.SeedUsers(userManager, roleManager);
}
app.Run();

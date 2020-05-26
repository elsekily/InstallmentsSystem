namespace InstallmentsSystem.Entities.Models
{
    public class InstallmentClients
    {
        public int Id { get; set; }
        public int InstallmentId { get; set; }
        public Installment Installment { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}

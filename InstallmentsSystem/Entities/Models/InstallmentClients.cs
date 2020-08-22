namespace InstallmentsSystem.Entities.Models
{
    public class InstallmentClients
    {
        public int Id { get; set; }
        public Installment Installment { get; set; }
        public Client Client { get; set; }
    }
}

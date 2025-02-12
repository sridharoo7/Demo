namespace Services.Model
{
    public class Customer : User
    {
        public DateTime LastPaymentDate { get; set; }
        public string Plan { get; set; }
    }
}

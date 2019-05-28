namespace Equipment.Rental.Models.Models
{
    public class CartRequest
    {
        public int Id { get; set; }
        public int RentDays { get; set; }
        public string MachineHashId { get; set; }
    }
}

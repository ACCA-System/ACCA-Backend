namespace ACCA_Backend.DataAccess.Entities
{
    public class DonationType
    {
        public int Id { get; set; }        
        public int MoneyTypeId { get; set; }
        public int MaterialDonationId { get; set; }
        public MaterialDonation MaterialDonation { get; set; }
    }
}

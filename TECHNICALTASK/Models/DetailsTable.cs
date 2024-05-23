namespace TECHNICALTASK.Models
{
    public class DetailsTable
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public decimal Amount { get; set; }

        // Navigation property
        public MasterTable Master { get; set; }
    }
}

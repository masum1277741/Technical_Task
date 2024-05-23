namespace TECHNICALTASK.Models
{
    public class MasterTable
    {
        public int Id { get; set; }
        public int NumberofItem { get; set; }

        // Navigation property
        public ICollection<DetailsTable> Details { get; set; }
    }
}

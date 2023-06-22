namespace SiteManagement.Models.DTOs
{
    public class UpdateWorkerDTO
    {
        public int WorkerId { get; set; }
        public int SiteId { get; set; }
        public string NameSurname { get; set; }
        public string Duty { get; set; }
    }
}

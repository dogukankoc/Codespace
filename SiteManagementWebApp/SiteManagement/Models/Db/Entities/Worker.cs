namespace SiteManagement.Models.Db.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        public int SiteId { get; set; }

        public string NameSurname { get; set; }
        public string Duty { get; set; }


    }
}

namespace SiteManagement.Models.Db.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

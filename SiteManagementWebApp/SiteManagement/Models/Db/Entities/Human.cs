using System.ComponentModel.DataAnnotations.Schema;

namespace SiteManagement.Models.Db.Entities
{
    public class Human
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public int ApartmentId { get; set; }

    }
}

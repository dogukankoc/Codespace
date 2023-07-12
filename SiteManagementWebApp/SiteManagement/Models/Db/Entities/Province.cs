using System.Collections.Generic;

namespace SiteManagement.Models.Db.Entities
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<District> Districts { get; set; } //Navigation prop. One to Many relationship.
    }
}

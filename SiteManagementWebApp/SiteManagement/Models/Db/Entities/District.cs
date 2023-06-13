using System.Collections.Generic;

namespace SiteManagement.Models.Db.Entities
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ProvinceId { get; set; }

        public Province Province { get; set; } //Nav.Prop.
    }
}

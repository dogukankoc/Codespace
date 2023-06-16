using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SiteManagement.Models.Db.Entities
{
    public class District
    {


        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }

        public ICollection<Site> Site { get; set; }
        public Province Province { get; set; } //Nav.Prop.
        
    }
}

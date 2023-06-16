using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteManagement.Models.Db.Entities
{
    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int? ManagerHumanId { get; set; }
        public ICollection<Block> Blocks { get; set; }
        public ICollection<Worker> Workers { get; set; }
        public int DistrictId { get; set; }

        [ForeignKey(nameof(DistrictId))]
        public District District { get; set; }


        [ForeignKey(nameof(ManagerHumanId))]
        public Human Human { get; set; }




    }
}

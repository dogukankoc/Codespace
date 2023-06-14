using System.Collections.Generic;

namespace SiteManagement.Models.Db.Entities
{
    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public District DistrcitId { get; set; }
        public int ManagerHumanId { get; set; }

        public ICollection<Block> Blocks { get; set; }

        public ICollection<Worker> Workers { get; set; }


    }
}

using System.Collections.Generic;

namespace SiteManagement.Models.Db.Entities
{
    public class Block
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public string BlockName { get; set; }
        public ICollection<Apartment> Apartments { get; set; }
    }
}

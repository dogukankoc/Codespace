using System.Collections.Generic;

namespace SiteManagement.Models.Db.Entities
{
    public class Apartment
    {

        public int Id { get; set; }
        public int BlockId { get; set; }
        public int HomeOwnerId { get; set; }
        public ICollection<ApartmentDept> ApartmentDepts { get; set; }
        public ICollection<Human> Humans { get; set; }


    }
}

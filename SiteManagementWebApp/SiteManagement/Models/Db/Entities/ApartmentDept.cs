using System;

namespace SiteManagement.Models.Db.Entities
{
    public class ApartmentDept
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public float ElectricityDebt { get; set; }
        public float GasDebt { get; set; }
        public float WaterDept { get; set; }
        public DateTime DeptDate { get; set; }
    }
}

namespace SiteManagement.Models.DTOs
{
    public class UpdateSiteDTO
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public int DistrictId { get; set; }
        public string SiteAdress { get; set; }
        public int CityId { get; set; }
    }
}

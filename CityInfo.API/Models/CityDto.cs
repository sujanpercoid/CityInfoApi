namespace CityInfo.API.Models
{
    public class CityDto
    {
       
      public int Id { get; set; }

      public string Name { get; set; } = string.Empty;
        public int NumberOfPointsOfInterest
        { get
            {
                return PointOfInterests.Count;
            }
        }

      public string? Description { get; set; }
        public ICollection<PointOfInterestDto> PointOfInterests { get; set; }=new List<PointOfInterestDto>();   

    }
}

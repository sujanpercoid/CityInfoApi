using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CityDataStore
    {
        public List<CityDto> Cities { get; set; }
        public static CityDataStore Current { get; } = new CityDataStore();
        public CityDataStore()
        {
            // initial dummy data
            Cities = new List<CityDto>
    {
        new CityDto
        {
            Id = 1,
            Name = "New York City",
            Description = "The one with that big park.",
            PointOfInterests = new List<PointOfInterestDto>()
            {
                new PointOfInterestDto()
                {
                    Id=1,
                    Name ="Central Park",
                    Description="The most vistsied park in the us"
                },
                new PointOfInterestDto()
                {
                    Id=2,
                    Name ="Empire state building",
                    Description="The tallest building in NY"
                }
            }
        },

        new CityDto
        {
            Id = 2,
            Name = "Antwerp",
            Description = "The one with the cathedral that was never really finished",
            PointOfInterests = new List<PointOfInterestDto>()
            {
                new PointOfInterestDto()
                {
                    Id=3,
                    Name ="Cathedal of lady",
                    Description="A Gothic Style OF Cathedial"
                },
                new PointOfInterestDto()
                {
                    Id=4,
                    Name ="Antwerp Central Station",
                    Description="The Finest railway sation in Belgiu,"
                }
            }
        },
        new CityDto
        {
            Id = 3,
            Name = "Paris",
            Description = "The one with that big tower.",
            PointOfInterests = new List<PointOfInterestDto>()
            {
                new PointOfInterestDto()
                {
                    Id=5,
                    Name ="Effile Tower",
                    Description="Iron Strut Of love"
                },
                new PointOfInterestDto()
                {
                    Id=6,
                    Name ="The Louver",
                    Description="The world largedt musem"
                }
            }


        }
    };
        }

    }
}

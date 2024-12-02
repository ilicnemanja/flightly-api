using Flightly.DTOs.Shared;
using Flightly.Models;

namespace Flightly.DTOs.FlightDtos
{
    public class FlightsDto
    {
        public IEnumerable<Flights> Flights { get; set; }
        public MetadataDto Metadata { get; set; }
    }
}

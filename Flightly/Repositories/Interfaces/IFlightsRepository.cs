using Flightly.DTOs.FlightDtos;

namespace Flightly.Repositories.Interfaces
{
    public interface IFlightsRepository
    {
        Task<FlightsDto> GetAllFlights(FlightsQueryParamsDto queryParams);
    }
}

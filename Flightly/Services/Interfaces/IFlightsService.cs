using Flightly.DTOs.FlightDtos;

namespace Flightly.Services.Interfaces
{
    public interface IFlightsService
    {
        Task<FlightsDto> GetAllFlights(FlightsQueryParamsDto queryParams);
    }
}

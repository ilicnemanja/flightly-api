using Flightly.DTOs.FlightDtos;
using Flightly.Repositories.Interfaces;
using Flightly.Services.Interfaces;

namespace Flightly.Services
{
    public class FlightsService : IFlightsService
    {
        private readonly IFlightsRepository _repository;
        public FlightsService(IFlightsRepository flightsRepository)
        {
            _repository = flightsRepository;
        }

        public async Task<FlightsDto> GetAllFlights(FlightsQueryParamsDto queryParams)
        {
            try
            {
                if (queryParams == null)
                    throw new ArgumentNullException(nameof(queryParams), "Query parameters cannot be null.");

                return await _repository.GetAllFlights(queryParams);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("[Service]: An error occurred while fetching flight data.", ex);
            }
        }
    }
}

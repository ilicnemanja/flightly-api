using Flightly.DTOs.FlightDtos;
using Flightly.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Flightly.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightsController : Controller
    {
        private readonly IFlightsService _flightsService;

        public FlightsController(IFlightsService flightsService)
        {
            _flightsService = flightsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlights([FromQuery] FlightsQueryParamsDto queryParams)
        {
            try
            {
                if (queryParams.PageNumber <= 0 || queryParams.PageSize <= 0)
                    return BadRequest("PageNumber and PageSize must be greater than zero.");

                var result = await _flightsService.GetAllFlights(queryParams);
                if (result == null || result.Flights == null || !result.Flights.Any())
                    return NotFound("No flights found matching the query.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"[Controller]: An unexpected error occurred: {ex.Message}");
            }
        }
    }
}

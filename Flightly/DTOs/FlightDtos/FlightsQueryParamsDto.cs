namespace Flightly.DTOs.FlightDtos
{
    public class FlightsQueryParamsDto
    {
        public string? FlightNumber { get; set; }
        public string? AirlineName { get; set; }
        public string? SortBy { get; set; } = "FlightNumber";
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}

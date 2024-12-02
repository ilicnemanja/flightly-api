using Flightly.Data;
using Flightly.DTOs.FlightDtos;
using Flightly.DTOs.Shared;
using Flightly.Helpers.Interfaces;
using Flightly.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Flightly.Repositories
{
    public class FlightsRepository : IFlightsRepository
    {
        private readonly FlightDbContext _context;
        private readonly IHelpers _helpers;

        public FlightsRepository(FlightDbContext context, IHelpers helpers)
        {
            _context = context;
            _helpers = helpers;
        }

        public async Task<FlightsDto> GetAllFlights(FlightsQueryParamsDto queryParams)
        {
            try
            {
                // Base query
                var query = _context.Flights.AsQueryable();

                // Filtering
                if (!string.IsNullOrEmpty(queryParams.FlightNumber))
                {
                    query = query.Where(f => f.FlightNumber.Contains(queryParams.FlightNumber));
                }

                if (!string.IsNullOrEmpty(queryParams.AirlineName))
                {
                    query = query.Where(f => f.AirlineName.Contains(queryParams.AirlineName));
                }

                // Sorting
                query = _helpers.ApplySorting(query, queryParams.SortBy, queryParams.IsDescending);

                // Total records count
                var totalRecords = await query.CountAsync();

                // Pagination
                var flights = await query
                    .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                    .Take(queryParams.PageSize)
                    .ToListAsync();

                // Metadata creation
                var totalPages = (int)Math.Ceiling(totalRecords / (double)queryParams.PageSize);
                var metadata = new MetadataDto
                {
                    TotalCount = totalRecords,
                    PageSize = queryParams.PageSize,
                    CurrentPage = queryParams.PageNumber,
                    TotalPages = totalPages,
                    HasNext = queryParams.PageNumber < totalPages,
                    HasPrevious = queryParams.PageNumber > 1
                };

                return new FlightsDto
                {
                    Flights = flights,
                    Metadata = metadata
                };
            }
            catch (DbUpdateException dbEx)
            {
                throw new ApplicationException("[Repository]: A database error occurred.", dbEx);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("[Repository]: An error occurred while accessing the flight repository.", ex);
            }
        }
    }
}

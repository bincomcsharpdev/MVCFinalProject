using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCFinalProject.Models.DTOs;
using MVCFinalProject.Services.Interfaces;

namespace MVCFinalProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        // GET: api/portfolio
        [HttpGet]
        public async Task<IActionResult> GetAllPortfolioItems()
        {
            var portfolioItems = await _portfolioService.GetAllPortfolioItemsAsync();
            return Ok(portfolioItems);
        }

        // GET: api/portfolio/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioItem(Guid id)
        {
            var portfolioItem = await _portfolioService.GetPortfolioItemByIdAsync(id);
            if (portfolioItem == null) return NotFound("Portfolio item not found");

            return Ok(portfolioItem);
        }

        // GET: api/portfolio/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserPortfolioItems(Guid userId)
        {
            var portfolioItems = await _portfolioService.GetUserPortfolioItemsAsync(userId);
            return Ok(portfolioItems);
        }

        // POST: api/portfolio
        [HttpPost]
        public async Task<IActionResult> CreatePortfolioItem([FromBody] PortfolioItemDto portfolioItemDto, IFormFile? file)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = GetUserId(); // A helper method to retrieve the authenticated user’s ID
            await _portfolioService.AddPortfolioItemAsync(portfolioItemDto, userId, file);

            return CreatedAtAction(nameof(GetPortfolioItem), new { id = portfolioItemDto.Id }, portfolioItemDto);
        }

        // PUT: api/portfolio/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePortfolioItem(Guid id, [FromBody] PortfolioItemDto portfolioItemDto, IFormFile? file)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _portfolioService.UpdatePortfolioItemAsync(id, portfolioItemDto, file);

            return NoContent();
        }

        // DELETE: api/portfolio/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortfolioItem(Guid id)
        {
            await _portfolioService.DeletePortfolioItemAsync(id);
            return NoContent();
        }

        private Guid GetUserId()
        {
            return Guid.Parse(User.Claims.First(c => c.Type == "sub").Value);
        }
    }
}

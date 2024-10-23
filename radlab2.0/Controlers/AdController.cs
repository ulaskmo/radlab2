using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using radlab2_0.Data;
using radlab2_0.Models;

namespace radlab2_0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private readonly AdDbContext _context;

        public AdController(AdDbContext context)
        {
            _context = context;
        }

        // GET: api/ad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ad>>> GetAds()
        {
            return await _context.Ads.ToListAsync();
        }

        // GET: api/ad/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Ad>> GetAd(int id)
        {
            var ad = await _context.Ads.FindAsync(id);

            if (ad == null)
            {
                return NotFound();
            }

            return ad;
        }

        // POST: api/ad
        [HttpPost]
        public async Task<ActionResult<Ad>> PostAd(Ad ad)
        {
            _context.Ads.Add(ad);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAd), new { id = ad.Id }, ad);
        }

        // PUT: api/ad/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAd(int id, Ad ad)
        {
            if (id != ad.Id)
            {
                return BadRequest();
            }

            _context.Entry(ad).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ad/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAd(int id)
        {
            var ad = await _context.Ads.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }

            _context.Ads.Remove(ad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/ad/seller/{seller}
        [HttpGet("seller/{seller}")]
        public async Task<ActionResult<IEnumerable<Ad>>> GetAdsBySeller(string seller)
        {
            var ads = await _context.Ads.Where(a => a.Seller == seller).ToListAsync();
            return ads.Count == 0 ? NotFound() : Ok(ads);
        }

        // GET: api/ad/category/{category}
        [HttpGet("category/{category}")]
        public async Task<ActionResult<IEnumerable<Ad>>> GetAdsByCategory(string category)
        {
            var ads = await _context.Ads
                .Where(a => a.Category == category)
                .OrderBy(a => a.Seller)
                .ToListAsync();
            return ads.Count == 0 ? NotFound() : Ok(ads);
        }
    }
}

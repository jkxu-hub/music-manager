using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using System;
using Serilog;

namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly DataDbContext _context;

        public RatingController(DataDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Double>> GetAverageRating(string? id)
        {
            Log.Information("GetAverageRating: {@id}", id); 
            if (id == null)
            {
                Log.Error("Song id is null for: {@id}", id); 
                return NotFound();
            }
            //getting the average from a database and then averaging it
            return _context.Ratings
            .Where(r => r.SongId == id)
            .Average(r => r.rating);
        }

        [HttpPost]
        public async Task<ActionResult<Rating>> PostRating(Rating songRating)
        {
            Log.Information("Post Request Rating: {@rating}", songRating); 
            if (songRating == null)
            {
                Log.Error("Rating was null for: {@rating}", songRating); 
                return BadRequest("Rating cannot be null.");
            }

            _context.Ratings.Add(songRating);
            await _context.SaveChangesAsync();

            return Ok();
        }

  
        
    }
}

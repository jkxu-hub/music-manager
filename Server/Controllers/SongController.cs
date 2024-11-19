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
    public class SongsController : ControllerBase
    {
        private readonly DataDbContext _context;

        public SongsController(DataDbContext context)
        {
            _context = context;
        }

  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSongDetails(string? id)
        {
            Log.Information("GetSongDetails: {@id}", id); 
            if (id == null)
            {
                Log.Error("Song id is null for: {@id}", id); 
                return NotFound();
            }

            Song song = null;

            try
            {
                song = await _context.Songs
                .FirstOrDefaultAsync(m => m.Id == new Guid(id));
            }catch (Exception ex)
            {
                Log.Error(ex, "Malformed ID: {@id}", id);

            }

            if (song == null)
            {
                Log.Error("Song not found for ID: {@id}", id); 
                return NotFound();
            }

            return song;
        }


        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            Log.Information("Post Request Song: {@song}", song); 
            if (song == null)
            {
                Log.Error("Song was null for: {@song}", song); 
                return BadRequest("Song cannot be null.");
            }

            if(song.FileBytes.Length == 0){
                Log.Error("Song was not uploaded for: {@song}", song); 
                return BadRequest("No File Uploaded");
            }

            
            string uniqueFileName = GenerateImageName(song.FileExtension);
            string DBPath = "/images/" + uniqueFileName;

            //updates file path for DB storage
            song.FilePath = DBPath;

            string savePath = GetImageDirectory() + uniqueFileName;

            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                stream.Write(song.FileBytes);
            }
            
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [NonAction]
        private static string GetImageDirectory(){
            string curr_directory = Directory.GetCurrentDirectory();
            int index = curr_directory.LastIndexOf("\\");

            string imageDirectory = curr_directory.Substring(0, index);
            imageDirectory = imageDirectory + "\\client\\wwwroot\\images\\";
            return imageDirectory;
        }

        [NonAction]
        private static string GenerateImageName(string extension){
            return Guid.NewGuid().ToString() + extension;
        }

        
    }
}

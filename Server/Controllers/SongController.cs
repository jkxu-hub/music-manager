using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using System;

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

        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            //Console.WriteLine("Controller: " + song.FileBytes.Length.ToString());
            if (song == null)
            {
                return BadRequest("Song cannot be null.");
            }

            if(song.FileBytes.Length == 0){
                return BadRequest("No File Uploaded");
            }

            Console.WriteLine(Directory.GetCurrentDirectory());
            string curr_directory = Directory.GetCurrentDirectory();
            int index = curr_directory.LastIndexOf("\\");
            string imageDirectory;
            imageDirectory = curr_directory.Substring(0, index);
            imageDirectory = imageDirectory + "\\client\\wwwroot\\images\\";
            Console.WriteLine(imageDirectory);
            
            
            string uniqueFileName = Guid.NewGuid().ToString() + ".png";
            string DBPath = "/images/" + uniqueFileName;
            song.FilePath = DBPath;

            string savePath = imageDirectory + uniqueFileName;

            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                stream.Write(song.FileBytes);
            }
            
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

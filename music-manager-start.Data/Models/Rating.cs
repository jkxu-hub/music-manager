using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace music_manager_starter.Data.Models
{
    public sealed class Rating
    {
        public Guid Id { get; set; }

        public String SongId { get; set; }

        [Range(1, 10, ErrorMessage = "The rating must be between 1 and 10.")]
        public int rating { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace music_manager_starter.Shared
{
    public sealed class Song
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }

        [NotMapped]
        public int Rating { get; set; }
        public string? FilePath{ get; set; }

        [NotMapped]
        public byte[] FileBytes{ get; set; }
        [NotMapped]
        public string FileExtension{ get; set; }
    }
}

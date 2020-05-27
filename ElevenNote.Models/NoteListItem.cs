﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class NoteListItem
    {
        public int NoteID { get; set; }
        public string Title { get; set; }
        [Display (Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}

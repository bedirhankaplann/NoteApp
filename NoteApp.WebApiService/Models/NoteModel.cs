using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApp.WebApiService.Models
{
    public class NoteModel
    {
        public string NoteTitle { get; set; }
        public string NoteDescription { get; set; }
        public int CategoryId { get; set; }

    }
}

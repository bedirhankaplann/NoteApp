using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApp.WebApiService.Models
{
    public class NoteModel
    {
        [Required(ErrorMessage = "Note's Title Can Not Be Null")]
        [Display(Name = "Note's Title")]
        public string NoteTitle { get; set; }

        [Required(ErrorMessage = "Note's Description Can Not Be Null")]
        [Display(Name = "Note's Description")]
        public string NoteDescription { get; set; }

        [Required(ErrorMessage = "Category Id Can Not Be Null")]
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }

    }
}

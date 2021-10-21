using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApp.WebApiService.Models
{
    public class CategoryModel
    {
        [Required(ErrorMessage = "Category Name Can Not Be Null")]
        [Display(Name = "Category's Name")]
        public string CategoryName { get; set; }
    }
}

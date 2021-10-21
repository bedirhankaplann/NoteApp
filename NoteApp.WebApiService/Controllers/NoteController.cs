using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApp.Business.Abstract;
using NoteApp.Entities;
using NoteApp.WebApiService.Filters;
using NoteApp.WebApiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApp.WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService noteService;

        public NoteController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        [HttpGet]
        [NoteException]
        public IActionResult Get()
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>
            {
                Entities = noteService.GetAll(),
                IsSuccess = true,
                HasError = false
            };
            response.EntitesCount = response.Entities.Count();

            return Ok(response);
        }

        [HttpGet("{id}")]
        [NoteException]
        public IActionResult Get(int id)
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>
            {
                Entity = noteService.GetById(id),
                IsSuccess = true,
                HasError = false
            };

            return Ok(response);
        }
        [HttpPost]
        [NoteException]
        [NoteValidate]
        public IActionResult Post([FromBody] NoteModel model)
        {
            
            Note note = new Note
            {
                NoteTitle = model.NoteTitle,
                NoteDescription = model.NoteDescription,
                CategoryId = model.CategoryId
            };
            noteService.Add(note);
            ServiceResponse<Note> response = new ServiceResponse<Note>
            {
                Entity = note,
                IsSuccess = true,
                HasError = false
            };
            return Ok();
        }
        [HttpPut]
        [NoteException]
        [NoteValidate]
        public IActionResult Put(int id, [FromBody] NoteModel model)
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>();
            var note = noteService.GetById(id);
            if (note == null)
            {
                response.HasError = true;
                response.IsSuccess = false;
                response.Errors.Add("Category Not Found");
                return BadRequest(response);
            }
            else
            {
                note.NoteTitle = model.NoteTitle;
                noteService.Update(note);
                response.IsSuccess = true;
                response.HasError = false;
                return Ok(response);
            }
        }
        [HttpDelete]
        [NoteException]
        public IActionResult Delete(int id)
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>();
            var note = noteService.GetById(id);
            if (note == null)
            {
                response.HasError = true;
                response.IsSuccess = false;
                response.Errors.Add("Category Not Found");
                return BadRequest(response);
            }
            else
            {
                noteService.Delete(note);
                response.IsSuccess = true;
                response.HasError = false;
                return Ok(response);
            }
        }
    }
}

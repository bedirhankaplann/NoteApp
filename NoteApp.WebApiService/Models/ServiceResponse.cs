using System.Collections.Generic;

namespace NoteApp.WebApiService.Models
{
    public class ServiceResponse<T> : BaseResponse
    {
        public ServiceResponse()
        {
            Errors = new List<string>();
            Entities = new List<T>();
        }
        public T Entity { get; set; }
        public List<T> Entities { get; set; }
        public int EntitesCount { get; set; }
        
    }
}

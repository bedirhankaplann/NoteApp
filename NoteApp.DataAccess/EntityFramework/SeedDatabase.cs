using Microsoft.Extensions.DependencyInjection;
using NoteApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoteApp.DataAccess.EntityFramework
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<NoteDbContext>();

            Category category = new Category
            {
                CategoryName = "Sosyal Ağ",

            };
            if (!context.Categories.Any())
            {
                context.Categories.Add(category);
                if(context.SaveChanges() > 0)
                {
                    Note note = new Note
                    {
                        NoteTitle = "Yeni Not",
                        NoteDescription = "Not Açıklaması",
                        CategoryId = category.Id,
                        Category = category
                    };

                    context.Notes.Add(note);
                    context.SaveChanges();
                }

            }

            
        }
    }
}

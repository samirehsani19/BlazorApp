using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared.Models
{
    public class Todo
    {
        [Key]
        public int TodoID { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

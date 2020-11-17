using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared.Models
{
    public class Diary
    {
        [Key]
        public int DiaryID { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

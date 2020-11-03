using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Todo> Todos { get; set; }
        public virtual DbSet<Diary> Diaries { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<User>().HasData(new User 
            {
                UserID=1,
                FirstName="Samir",
                LastName="Jan",
                Email="samir.jan@gmail.com",
                Password="Samir123"
            });

            model.Entity<Todo>().HasData(new Todo
            {
                TodoID=1,
                Date=new DateTime(2020,10,28),
                Title="Shopping",
                Description="List of products that i need to buy ...",
            },
            new Todo
            {
                TodoID=2,
                Date=new DateTime(2020, 10, 29),
                Title="Meet friends",
                Description="Adress here",
            });

            model.Entity<Diary>().HasData(new Diary 
            {
                DiaryID=1,
                Date=new DateTime(2020, 10, 30),
                Title="At Home",
                Description="Today i have guests at home",
            },
            new Diary 
            {
                DiaryID=2,
                Date=new DateTime(2020, 10, 31),
                Title="At Work",
                Description="Today i created an blazor project",
            });
        }
    }
}

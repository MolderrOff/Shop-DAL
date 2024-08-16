using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL //Берёт из базы данных и превращает в объект  car на C#
{
    public class ApplicationDbContext : DbContext //позволяет возможность использовать все из Entity Framework
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
                                                        //сам конструктор принимает generic объект options

        {
           //Database.EnsureCreated(); //устанавливает связь с БД, создаёт базу данных если не создана
        }

        public DbSet<Product> Product { get; set; }  //в эту сущность будут вставляться данные из нашей таблицы
        public DbSet<Category> Category { get; set; }
        [HasNoKey]
        public DbSet<ResultJoin> ResultJoin { get; set; }
    }

    internal class HasNoKeyAttribute : Attribute
    {
    }
}

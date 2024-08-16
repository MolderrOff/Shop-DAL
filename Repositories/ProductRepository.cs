using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entity;

namespace Shop.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        //private object category;
        //private object product;

        public ProductRepository(ApplicationDbContext db)  // инициализировали класс в конструкторе
        {
            _db = db;
        }

        public async Task<bool> Create(Product entity)  // при имплементации подставился Car - это благодаря дженерикам
                                                    // связь с IBaswRepository и ICarRepository
        {
            await _db.Product.AddAsync(entity);
            // _db.Car.Update(entity);
            await _db.SaveChangesAsync();//140824 2-25 await _db.SaveChangesAsync();//await _db.SaveChangesAsync();//dataManager.ServiceItems.SaveServiceItem(model);
            return true;
        }

  
        public async Task<bool> DeleteAsync(Product entity) //  public bool Delete(Car entity)
        {
            _db.Product.Remove(entity);
            await _db.SaveChangesAsync(); // 
            return true;//чтобы изменения в бд сохранились
        }



        public async Task<Product> GetAsync(int id)  // или public async Task<Car> GetAsync(int id)
        {
            return await _db.Product.FirstOrDefaultAsync(x => x.Id == id);// получаем первый попавшийся объект по условиям
            //где x - объект product будет равен значению Id

        }


        public async Task<List<Product>> GetAsyncSelect()  // 150824 19-49 или public async Task<Car> GetAsync(int id)
        {

            List<Product> products = await _db.Product.FromSqlRaw("SELECT Product.Id, Product.NameProduct, Product.IdNameCategory FROM Product").ToListAsync();//SELECT NameProduct, NameCategory FROM dbo.Product , 
                                                                                                                                                               //dbo.Category WHERE Category.Id = Product.IdNameCategory Order
                                                                                                                                                               //By NameProduct;
                                                                                                                                                               // SELECT * FROM Product
                                                                                                                                                               // SELECT Product.Id, Product.NameProduct, Product.IdNameCategory FROM Product
                                                                                                                                                               //SELECT * FROM myfun();
                                                                                                                                                               //return await _db.Car.FirstOrDefaultAsync(x => x.Id == id);


            return products; 

        }
        public async Task<List<ResultJoin>> GetResultJoin()
        {
            List<ResultJoin> resultJoins = await _db.ResultJoin.FromSqlRaw("SELECT * FROM Category").ToListAsync();
            return resultJoins;
        }

        // SELECT * FROM myfun()
        //        async List<Product> IBaseRepository<Product>.GetResultJoin()
        //        {
        // List < Product > p = await _db.ResultJoin.FromSqlRaw("SELECT * FROM myfun()").ToListAsync();


        //return p;
        //        }
        public async Task<Product> GetByNameAsync(string NameProduct)
        {
            return await _db.Product.FirstOrDefaultAsync(x => x.NameProduct == NameProduct);
            //Свойство объекта NameProduct будет равно нашему параметру NameProduct
            //throw new NotImplementedException();
        }



        public async Task<List<Product>> Select()
        {

            List<Product> products = await _db.Product.ToListAsync(); //Делаем обращение к бд, и возвращаем из неё в метод select 
            return products;  //сделали метод асинхронным, чтобы сайт не завис во время получения данных 

        }

        async Task<bool> IBaseRepository<Product>.Delete(Product entity)
        {
            _db.Product.Remove(entity);
            await _db.SaveChangesAsync(); // 140824 2-25
            return true;
            //throw new NotImplementedException();
        }


    }





    //public class CategoryRepository : IProductRepository
    //{
    //    private readonly ApplicationDbContext _db;
    //    private object product;
    //    private object category;

    //    public CategoryRepository(ApplicationDbContext db)
    //    { 
    //        _db = db;
    //    }
    //    public Task<bool> Create(Product entity)
    //    {

    //        throw new NotImplementedException();
    //    }

    //    public Task<bool> Delete(Product entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public async Task<Category> GetAsync(int id)
    //    {
    //        return await _db.Category.FirstOrDefaultAsync(x => x.Id == id);
    //    }
   

    //    public Task<List<Product>> GetAsyncSelect()
    //    {
    //        //var query = from product1 in product
    //        //            join category1 in category on product1.IdNameCategory equals category1.Id
    //        //            select new { Name = $"{product1.NameProduct}", DepartmentName = category1.NameCategory };

    //        //foreach (var item in query)
    //        //{
    //        //    Console.WriteLine($"{item.Name} - {item.DepartmentName}");
    //        //}
    //        //return;
    //        throw new NotImplementedException();
    //    }

    //    public Task<List<Product>> GetAsyncSelectCategory()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<Product> GetByNameAsync(string NameProduct)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<List<Product>> Select()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    Task<Product> IBaseRepository<Product>.GetAsync(int id)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}

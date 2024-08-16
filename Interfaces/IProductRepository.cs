using Shop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    //передаём объект Product как тип дженерика <>
    //добавляем специфические методы
    {
        Task<Product> GetByNameAsync(string NameProduct);  //унаследовались от базового репозитория и внутри создали 
        //специфический метод Product GetByNameAsync(string name); 

    }
}

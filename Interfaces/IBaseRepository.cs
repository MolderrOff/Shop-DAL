using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Interfaces
{
    public interface IBaseRepository<T> //Общие методы для взаимодействия с бд <> - значит Generic
    {                                     //Generic -система понимает с каким объектом имеет дело при передаче
                                          //при наследовании интерфейса передаётся определённый объект
        Task<bool> Create(T entity);// bool Create(T entity);
        Task<T> GetAsync(int id);  //метод 2   T GetAsync(int id); 
        //IEnumerable<T> Select();
        Task<List<T>> Select(); //  получение коллекции элементов в тип Generic передаём селект без параметров //IEnumerable<T> Select();
        Task<List<T>> GetAsyncSelect(); //150824 19-55
        //Task<List<T>> GetAsyncSelectCategory(); //150824 21-58
        //Task<List<T>> GetResultJoin();
        Task<bool> Delete(T entity); //4 метод удаления из таблицы bool Delete(T entity);

    }
}


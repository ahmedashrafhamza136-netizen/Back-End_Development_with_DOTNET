using Microsoft.AspNetCore.Mvc;
using WebApplicationTutorial.Models;

namespace WebApplicationTutorial.Interfaces
{
    public interface IService
    {
        public Boolean AddProducts(Product p);

        public List<Product> GetAll();


        public Boolean Update(int id, int id2);

        public Boolean Delete(int id);


        public Product GetById(int id);

    }
}

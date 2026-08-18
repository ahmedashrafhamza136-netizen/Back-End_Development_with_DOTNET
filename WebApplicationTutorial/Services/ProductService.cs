using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTutorial.Models;

namespace WebApplicationTutorial.Interfaces
{
    public class ProductService : IService
    {
        private static List<Product> products = new List<Product>();

        public Product GetById(int id)
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i]);

                if (products[i].id == id)
                {
                    return products[i];
                }
            }

            return null;
        }

        public bool AddProducts(Product p )
        {
            products.Add(p);
            return true;
        }

        public bool Delete(int id)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].id == id) { }
                {  products.RemoveAt(i); return true; }


            }
            return false;


        }

        public List<Product> GetAll()
        {
            return products;
        }




        public bool Update(int id, int id2)
        {
            for (int i = 0; i < products.Count; i++) {
                if (products[i].id == id) { 
                    products[i].id = id2;
                    return true;
                }
            }
            return false;
        }
    }
}

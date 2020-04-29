using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;
namespace MyShop.DataAccess.InMemory
{
    public class ProductRespo
    {
        ObjectCache cache = MemoryCache.Default;
        IList<Product> products;

        public ProductRespo()
        {
            products = cache["Products"] as List<Product>;
            if(products==null)
            {
                products = new List<Product>();
            }
        }
        public void Commit()
        {
            cache["Products"] = products;
        }
        public void insert(Product p)
        {
            products.Add(p);
        }
        public void Update(Product product)
        {
            Product ProToUpdate = products.FirstOrDefault(p => p.Id == product.Id);
            if(ProToUpdate!=null)
            {
                ProToUpdate = product;
            }
            else
            {
                throw new Exception();
            }
        }
        public Product find(String id)
        {

            Product Product = products.FirstOrDefault(p => p.Id == id);
            if (Product != null)
            {
                return Product;
            }
            else
            {
                throw new Exception();
            }
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }
        public void delete( string id)
        {

            Product Delete = products.FirstOrDefault(p => p.Id == id);
            if (Delete != null)
            {
                products.Remove(Delete);
            }
            else
            {
                throw new Exception("Product No Found");
            }
        }
    }
}

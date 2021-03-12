using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            // IDısposable pattern implementation of C#    buradaki using. C#'a özel bir yapıdır. 
            using (NorthwindContext context = new NorthwindContext())  //Northwind Context ile iş bitince direk olarak bellekten atılacak. Daha performanslı oldu. Belleği Hızlıca Temizleme.
            {
                var addedEntity = context.Entry(entity);  //Refernası yakala
                addedEntity.State = EntityState.Added;    // yakaladığın referans aslında ekleme işlemi.
                context.SaveChanges();                    // Değişiklikleri kaydeder.
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())  //Northwind Context ile iş bitince direk olarak bellekten atılacak. Daha performanslı oldu. Belleği Hızlıca Temizleme.
            {
                var deletedEntity = context.Entry(entity);       //Refernası yakala
                deletedEntity.State = EntityState.Deleted;       // yakaladığın referans aslında silme işlemi.
                context.SaveChanges();                           // Değişiklikleri kaydeder.
            }                   
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null) // burada filtrelemeye göre yaptık ama filtre verilmek zorunlu değil
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())  //Northwind Context ile iş bitince direk olarak bellekten atılacak. Daha performanslı oldu. Belleği Hızlıca Temizleme.
            {
                var updatedEntity = context.Entry(entity);  //Refernası yakala
                updatedEntity.State = EntityState.Modified;    // yakaladığın referans aslında ekleme işlemi.
                context.SaveChanges();                    // Değişiklikleri kaydeder.
            }
        }
    }
}

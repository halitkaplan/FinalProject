using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {   // İş Kodları:
            // Tümünü Listelemeye çalışıyor ama Yetkisi var mı?
            // Kurallardan geçerse işlemleri yapabilir. 
            return _productDal.GetAll();
           
           // InMemoryProductDal ınMemoryProductdal = new InMemoryProductDal(); böyle bir şey yazamam çünkü, bir katman başka bir katmanı newleyemez.
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId==id);  // Benim gönderdiğim CategoryId'ye eşitse, onları filtrele demek.
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max);
        }
    }
}

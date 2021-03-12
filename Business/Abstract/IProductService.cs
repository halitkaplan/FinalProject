using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id); //Id dediğin için parametresini bu şekilde belitrrim.

        List<Product> GetByUnitPrice(decimal min, decimal max);

    }
}

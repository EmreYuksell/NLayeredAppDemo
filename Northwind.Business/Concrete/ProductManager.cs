using Northwind.DataAcces.Concrete;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete
{
    public class ProductManager
    {
        ProductDal _productDal = new ProductDal();

        public List<Product> GetAll()
        {
            //Business Code
            ProductDal productDal = new ProductDal();
            return _productDal.GetAll();
        }

    }
}

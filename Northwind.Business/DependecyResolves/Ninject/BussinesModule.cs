using Ninject.Modules;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAcces.Abstract;
using Northwind.DataAcces.Concrete.EntityFramework;
using Northwind.DataAcces.Concrete.EntıtyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.DependecyResolves.Ninject
{
    public class BussinesModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

        }

    }
}

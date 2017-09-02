using FCK.Studio.Core;
using FCK.Studio.Repositories;

namespace FCK.Studio.Application
{
    public class ProductsService : FCKStudioAppBase
    {
        public readonly Repository<Products, long> Reposity;
        public ProductsService()
        {
            Reposity = new Repository<Products, long>(dbContext, dbContext.Products);
        }
    }
}

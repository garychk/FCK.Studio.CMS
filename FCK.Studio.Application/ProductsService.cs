using FCK.Studio.Core;
using FCK.Studio.Repositories;

namespace FCK.Studio.Application
{
    public class ProductsService : FCKStudioAppBase
    {
        public readonly Repository<Products, int> Reposity;
        public ProductsService()
        {
            Reposity = new Repository<Products, int>(dbContext, dbContext.Products);
        }
    }
}

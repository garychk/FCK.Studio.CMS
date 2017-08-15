using FCK.Studio.Core;
using FCK.Studio.Repositories;

namespace FCK.Studio.Application
{
    public class CategoriesService: FCKStudioAppBase
    {
        public readonly Repository<Categories, int> Reposity;
        public CategoriesService()
        {
            Reposity = new Repository<Categories, int>(dbContext, dbContext.Categories);
        }
    }
}

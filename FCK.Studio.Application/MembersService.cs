using FCK.Studio.Core;
using FCK.Studio.Repositories;

namespace FCK.Studio.Application
{
    public class MembersService: FCKStudioAppBase
    {
        public readonly IRepository<Members, int> Reposity;
        public MembersService()
        {
            Reposity = new Repository<Members, int>(dbContext);
        }
    }
}

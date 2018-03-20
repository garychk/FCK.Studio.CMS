using FCK.Studio.Core;
using FCK.Studio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCK.Studio.Application
{
    public class CommentsService : FCKStudioAppBase
    {
        public readonly IRepository<Comments, long> Reposity;
        public CommentsService()
        {
            Reposity = new Repository<Comments, long>(dbContext);
        }
    }
}

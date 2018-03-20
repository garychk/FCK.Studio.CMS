using FCK.Studio.Core;
using FCK.Studio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCK.Studio.Application
{
    public class TenantsService: FCKStudioAppBase
    {
        public readonly IRepository<Tenants, int> Reposity;
        public TenantsService()
        {
            Reposity = new Repository<Tenants, int>(dbContext);
        }
    }
}

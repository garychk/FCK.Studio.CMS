using System;

namespace FCK.Studio.Application
{
    public class FCKStudioAppBase: IDisposable
    {
        protected EntityFramework.FCKStudioDbContext dbContext;
        public FCKStudioAppBase()
        {
            dbContext = new EntityFramework.FCKStudioDbContext("FCKStudioDbContext");
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }

}

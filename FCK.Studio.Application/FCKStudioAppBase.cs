namespace FCK.Studio.Application
{
    public class FCKStudioAppBase
    {
        protected EntityFramework.FCKStudioDbContext dbContext;
        public FCKStudioAppBase()
        {
            dbContext = new EntityFramework.FCKStudioDbContext("FCKStudioDbContext");
        }
        ~FCKStudioAppBase()
        {
            dbContext.Dispose();
        }
    }

}

namespace FCK.Studio.Application
{
    public class FCKStudioAppBase
    {
        protected EntityFramework.FCKStudioDbContext dbContext = new EntityFramework.FCKStudioDbContext();
        ~FCKStudioAppBase()
        {
            dbContext.Dispose();
        }
    }
    
}

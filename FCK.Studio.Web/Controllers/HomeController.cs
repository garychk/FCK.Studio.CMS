using FCK.Studio.Application;
using FCK.Studio.Core;
using System.Web.Mvc;

namespace FCK.Studio.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //CategoriesService Category = new CategoriesService();
            //Categories obj = Category.Reposity.Get(1);
            //obj.CategoryIndex = "A";
            //obj.Layout = "Article";
            //Category.Reposity.Update(obj);
            //var model = Category.Reposity.Get(1);

            ArticlesService Article = new ArticlesService();
            Articles obj = new Articles();
            var modle = Article.Reposity.GetAsync(1);
            //obj.CategoryId = 1;
            //obj.Contents = "";
            //obj.Title = "test";
            //Article.Reposity.Insert(obj);
            var lists = Article.GetArticleWithCate(1, 10, (A => A.CategoryId == 1));
            Utility.MailHelper oMail = new Utility.MailHelper("","","");
            return View(lists);
        }
    }
}
using AutoMapper;
using FCK.Studio.Application;
using FCK.Studio.Core;
using FCK.Studio.Web.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCK.Studio.Web.Controllers
{
    public class ArticlesController : Controller
    {
        // GET: Articles
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetModel(int id)
        {
            using (ArticlesService Article = new ArticlesService())
            {
                Articles model = new Articles();
                var result = Article.Reposity.FirstOrDefault(id);
                if (result != null)
                    model = result;
                return Json(model);
            }
        }
        public JsonResult InsertOrUpdate(ArticleInput input)
        {
            using (ArticlesService Article = new ArticlesService())
            {
                Mapper.Initialize(x => x.CreateMap<Articles, ArticleInput>());
                var entity = Mapper.Map<Articles>(input);
                var result = Article.Reposity.InsertOrUpdate(entity);
                return Json(result);
            }
        }

        public JsonResult GetLists(int page, int pageSize)
        {
            using (ArticlesService Article = new ArticlesService())
            {
                var result = Article.Reposity.GetPageList(page, pageSize);
                return Json(result);
            }
        }
    }
}
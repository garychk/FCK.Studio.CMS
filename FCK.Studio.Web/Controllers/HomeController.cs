using AutoMapper;
using FCK.Studio.Application;
using FCK.Studio.Core;
using FCK.Studio.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FCK.Studio.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ArticlesService Article = new ArticlesService();            
            //Task.Run(async () =>
            //{
            //    var modle = await Article.Reposity.GetAsync(1);
            //});
            //Articles obj = new Articles();
            //obj.CategoryId = 1;
            //obj.Contents = "Contents" + DateTime.Now.ToString();
            //obj.Title = "Test" + DateTime.Now.ToString();
            //Article.Reposity.Insert(obj);
            var result = Article.GetArticleWithCate(1, 10, (A => A.CategoryId == 1));

            //Mapper.Initialize(x => x.CreateMap<Articles, Dto.Articles>());
            //var lists = Mapper.Map<ResultDto<List<Dto.Articles>>>(result);

            return View(result);
        }
    }
}
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
            return View();
        }

        public void Test()
        {
            //所有的业务逻辑都是通过调用数据仓储服务Reposity，写在Controller里，如下示例：
            //定义一个数据仓储服务，它将继承数据仓储Reposity的所有增删查改方法
            CategoriesService Categ = new CategoriesService();
            //新建对象，通常是定义一个DTO对象，然后将其映射成真实的模型
            Categories obj = new Categories();
            obj.CategoryIndex = "News";
            obj.CategoryName = "News";
            obj.Childs = 0;
            obj.Layout = "Articles";
            obj.TenantId = 1;
            //调用数据仓储服务Reposity的Insert方法
            Categ.Reposity.Insert(obj);
            //调用数据仓储服务Reposity的同步方法GetAllList
            var result = Categ.Reposity.GetAllList();
            //调用数据仓储服务Reposity的异步方法GetAllListAsync
            Task.Run(async () =>
            {
                var lists = await Categ.Reposity.GetAllListAsync();
            });

            ArticlesService Article = new ArticlesService();
            //调用Service自身的函数
            var articleList = Article.GetArticleWithCate(1, 10, (A => A.CategoryId == 1));

            //Mapper.Initialize(x => x.CreateMap<Articles, Dto.Articles>());
            //var lists = Mapper.Map<ResultDto<List<Dto.Articles>>>(result);
        }

        public JsonResult TestJsonResult()
        {
            using (ArticlesService Article = new ArticlesService())
            {
                //调用Service自身的函数
                var result = Article.GetArticleWithCate(1, 10, (A => A.CategoryId == 1));
                //以JSON格式返回数据到View
                return Json(result);
            }
        }
    }
}
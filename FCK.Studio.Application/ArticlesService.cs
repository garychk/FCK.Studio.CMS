using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FCK.Studio.Core;
using FCK.Studio.Dto;
using FCK.Studio.Repositories;
using System.Linq;
using System.Data.Entity;

namespace FCK.Studio.Application
{
    public class ArticlesService: FCKStudioAppBase, IArticlesService
    {
        public readonly Repository<Articles, long> Reposity;
        public ArticlesService()
        {
            Reposity = new Repository<Articles, long>(dbContext, dbContext.Articles);
        }
        
        public async Task<ResultDto<List<Articles>>> GetArticleWithCate(int PageIndex, int PageSize, Expression<Func<Articles, bool>> predicate)
        {
            ResultDto<List<Articles>> result = new ResultDto<List<Articles>>();
            var query = await Reposity.GetPageListAsync(PageIndex, PageSize, predicate);
            result.pages = query.pages;
            result.total = query.total;
            result.datas = query.datas.AsQueryable()
                .OrderByDescending(entity => entity.CreationTime)
                .Include(entity => entity.CategoryId)
                .ToList();
            return result;

        }
    }

}

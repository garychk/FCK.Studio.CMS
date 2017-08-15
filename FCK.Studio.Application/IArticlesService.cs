using FCK.Studio.Core;
using FCK.Studio.Dto;
using FCK.Studio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FCK.Studio.Application
{
    public interface IArticlesService
    {
        Task<ResultDto<List<Articles>>> GetArticleWithCate(int PageIndex,int PageSize, Expression<Func<Articles, bool>> predicate);
    }
}

using FCK.Studio.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCK.Studio.WebApi
{
    public class FCKStudioWebApiBase
    {
        private ArticlesService _IArticle { get; set; }
        private ProductsService _IProduct { get; set; }
        public FCKStudioWebApiBase()
        {
            _IArticle = new ArticlesService();
            _IProduct = new ProductsService();
            
        }
    }
}

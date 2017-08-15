using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCK.Studio.Dto
{
    public class ResultDto<T>
    {
        public int code { get; set; }
        public string message { get; set; }
        public int pages { get; set; }
        public int total { get; set; }
        public T datas { get; set; }
    }
}

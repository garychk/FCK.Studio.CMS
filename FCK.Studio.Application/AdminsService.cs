using FCK.Studio.Core;
using FCK.Studio.Dto;
using FCK.Studio.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCK.Studio.Application
{
    public class AdminsService : FCKStudioAppBase
    {
        public readonly Repository<Admins, int> Reposity;
        public AdminsService()
        {
            Reposity = new Repository<Admins, int>(dbContext, dbContext.Admins);
        }

        public async Task<ResultDto<string>> Login(string LoginName, string Password, int IP)
        {
            ResultDto<string> result = new ResultDto<string>();
            try
            {
                var query = await Reposity.GetAllListAsync(entity => entity.LoginName == LoginName);
                var model = query.FirstOrDefault();
                if (model == null)
                {
                    result.code = 101;
                    result.message = "No exist";                    
                }
                else
                {
                    if (new PasswordHasher().HashPassword(Password) == model.Password)
                    {
                        result.code = 100;
                        result.message = "Success";
                        result.datas = model.LoginName;
                    }
                    else
                    {
                        result.code = 102;
                        result.message = "Password error";
                    }
                }
            }
            catch (Exception e)
            {
                result.code = 103;
                result.message = e.Message;
            }
            return result;
        }
    }
}

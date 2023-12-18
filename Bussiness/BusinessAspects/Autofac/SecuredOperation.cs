using Bussiness.Constants;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;


namespace Bussiness.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        //JWT için
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        //jwt ile her bir istek için httpcontext oluşur


        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); //metni senin belirlediğin karakterlere göre virgülle ayırıyor
            //array haline geliyor
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}

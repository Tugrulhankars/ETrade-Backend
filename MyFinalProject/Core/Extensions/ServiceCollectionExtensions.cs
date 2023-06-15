using Core.Utilities.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //bu yapı bizimm ekleyeceğimiz tüm injectionları burada kontrol ederiz
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceColection, ICoreModule[]
            modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceColection);
            }

            return ServiceTool.Create(serviceColection);
        }
    }
}

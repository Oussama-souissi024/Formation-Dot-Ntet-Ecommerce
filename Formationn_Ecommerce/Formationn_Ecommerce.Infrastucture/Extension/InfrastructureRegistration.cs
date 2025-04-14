using Formationn_Ecommerce.Core.Interfaces.Repositories;
using Formationn_Ecommerce.Core.Interfaces.Repositories.Base;
using Formationn_Ecommerce.Infrastucture.Persistence.Repository;
using Formationn_Ecommerce.Infrastucture.Persistence.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Formationn_Ecommerce.Infrastucture.Extension
{
    public static class InfrastructureRegistration
    {
        
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            //Register repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<ICouponRepository, CouponRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }

        
    }
}

using Formationn_Ecommerce.Application.Categories.Interfaces;
using Formationn_Ecommerce.Application.Categories.Mapping;
using Formationn_Ecommerce.Application.Categories.Services;
using Formationn_Ecommerce.Application.Coupons.Interfaces;
using Formationn_Ecommerce.Application.Coupons.Mapping;
using Formationn_Ecommerce.Application.Coupons.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Formationn_Ecommerce.Application.Common.Extension
{
    public static class ServicesRegistration
    {
        public static void AddServiceRegistraion(this IServiceCollection services)
        {
            services.AddScoped<ICouponService,CouponServices>();
            services.AddScoped<ICategoryService,CategoryServices>();

            services.AddAutoMapper(typeof(CouponProfile));
            services.AddAutoMapper(typeof(CategoryProfile));
        }
    }
}

using AutoMapper;
using BrentWiels.Data;
using BrentWiels.Data.Interfaces;
using BrentWiels.Mappings;
using DataLayer.Interfaces.Repositories;
using DataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrentWiels.Extensions
{
    public static class Dependencies
    {
        public static void AddServices (this IServiceCollection services)
        {
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IKlantenRepository, KlantenRepository>();
            services.AddScoped<IKlantenDataService, KlantenDataService>();

            //Automapper
            var klantenConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new KlantenMapping());
            });

            IMapper mapper = klantenConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

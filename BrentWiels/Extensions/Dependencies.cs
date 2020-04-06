﻿using AutoMapper;
using BrentWiels.Data;
using BrentWiels.Data.Interfaces;
using BrentWiels.Mappings;
using BrentWiels.Services;
using DataLayer.Interfaces.Repositories;
using DataLayer.Repositories;
using Documents;
using Documents.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BrentWiels.Extensions
{
    public static class Dependencies
    {
        public static void AddServices (this IServiceCollection services)
        {
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IKlantenRepository, KlantenRepository>();
            services.AddScoped<IKlantenDataService, KlantenDataService>();
            services.AddScoped<IOfferteRepository, OfferteRepository>();
            services.AddScoped<IOfferteDataService, OfferteDataService>();
            services.AddScoped<IOfferteGenerator, OfferteGenerator>();
            services.AddScoped<ModalService>();

            //Automapper
            var klantenConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new KlantenMapping());
                mc.AddProfile(new OfferteMappings());
            });

            var mapper = klantenConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

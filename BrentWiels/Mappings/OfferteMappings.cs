using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BrentWiels.Viewmodels;
using DataLayer.Entities;

namespace BrentWiels.Mappings
{
    public class OfferteMappings : Profile
    {
        public OfferteMappings()
        {
            CreateMap<OfferteViewModel, Offerte>()
                .ForMember(x => x.Werklijnen, y => y.MapFrom(z => z.Werklijnen))
            CreateMap<WerkLineViewModel, WerkLine>();
        }
    }

    #region Converters


    #endregion
}

using Equipment.Rental.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Equipment.Rental.WebApi.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Register(HttpConfiguration config)
        {
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<List<Models.Equipment>, List<EquipmentDto>>();
            });
        }
    }
}
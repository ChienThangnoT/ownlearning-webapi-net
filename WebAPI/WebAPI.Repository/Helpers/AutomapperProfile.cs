using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Repository.Data;
using WebAPI.Repository.Models;

namespace WebAPI.Repository.Helpers
{
    public class AutomapperProfile  : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<AccountModel, TblAccount>().ReverseMap();
        }
    }
}

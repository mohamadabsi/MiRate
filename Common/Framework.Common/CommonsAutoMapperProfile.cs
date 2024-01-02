using AutoMapper;
using Framework.Core.CommonTables.VM;
using Framework.Core.CommonTables.Entities;
using Framework.Core.Contracts;

namespace Framework.Core.CommonTables
{
    public class CommonsAutoMapperProfile : Profile
    {
        public CommonsAutoMapperProfile()
        {
            this.CreateMap<SystemSetting, SettingsVM>().ReverseMap();

        }
    }

}

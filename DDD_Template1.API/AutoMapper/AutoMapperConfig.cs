using AutoMapper;
using System;
using System.Linq;

namespace DDD_Template1.API.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration CreateMapperConfiguration()
        {
            return new MapperConfiguration(p =>
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains("DDD_Template1."));

                p.AddProfiles(assemblies);
            });
        }
    }
}
using DDD_Template1.UI.MVC.AutoMapper;
using Xunit;

namespace DDD_Template1.UI.MVC.Tests.AutoMapper
{
    [Collection(nameof(AutoMapperCollection))]
    public class AutoMapperConfigTests
    {
        [Trait("", "Others/AutoMapper")]
        [Fact(DisplayName = "Web - AutoMapper - Configuration")]
        public void AutoMapper_Validate_Configuration()
        {
            var mapperConfiguration = AutoMapperConfig.CreateMapperConfiguration();

            mapperConfiguration.AssertConfigurationIsValid();
        }
    }
}
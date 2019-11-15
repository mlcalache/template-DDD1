using Xunit;

namespace DDD_Template1.UI.MVC.Tests.AutoMapper
{
    [CollectionDefinition(nameof(AutoMapperCollection))]
    public class AutoMapperCollection : ICollectionFixture<AutoMapperTestsFixture>
    {
    }

    public class AutoMapperTestsFixture { }
}
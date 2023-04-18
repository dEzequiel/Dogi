using AutoFixture;

namespace Test.Utils.Customizations
{
    internal class AutoMapperCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register(() =>
            {
                return AutomapperTestHelper.CreateAutoMapperConfiguration();
            });
        }
    }
}

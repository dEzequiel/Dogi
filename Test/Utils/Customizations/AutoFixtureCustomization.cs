using AutoFixture;
using AutoFixture.AutoMoq;


namespace Test.Utils.Customizations
{
    public class AutoFixtureCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize(new AutoMoqCustomization());
        }
    }
}

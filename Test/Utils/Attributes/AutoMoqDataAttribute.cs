using AutoFixture;
using AutoFixture.Xunit2;
using Test.Utils.Customizations;

namespace Test.Utils.Attributes
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            :base(() => new Fixture().Customize(new AutoFixtureCustomization())){ }
    }
}

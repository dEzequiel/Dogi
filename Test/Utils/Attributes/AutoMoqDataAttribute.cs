﻿using AutoFixture;
using AutoFixture.Xunit2;
using Test.Utils.Customizations;

namespace Test.Utils.Attributes
{
    /// <summary>
    /// Configuration with the purpose to generate parametrized data for testing.
    /// </summary>
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            :base(() => new Fixture().Customize(new AutoFixtureCustomization())){ }
    }
}

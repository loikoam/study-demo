using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightsLibrary;

namespace TrafficLightsLibrary.Test
{
    [TestFixture]
    class SourceOfPowerTest
    {
        SourceOfPower _sourceOfPower;
        [SetUp]
        public void SetUp_Source_Of_Power()
        {
            _sourceOfPower = new SourceOfPower();
        }

        [Test]
        public void Get_Status_Test()
        {
            //bool active = _sourceOfPower.GetActiveState();

            //active.Should().Be(_sourceOfPower.SourceOfPowerSwitchOn, because: $"Source of Power should be state = {_sourceOfPower.SourceOfPowerSwitchOn}");
        }

    }
}

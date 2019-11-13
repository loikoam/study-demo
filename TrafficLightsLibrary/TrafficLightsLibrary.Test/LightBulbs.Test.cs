using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightsLibrary.Test
{
    [TestFixture]
    class LightBulbsTest
    {
        LightBulbs _lightBulbs;
        [SetUp]
        public void Set_Up_LightBulbs()
        {
            _lightBulbs = new LightBulbs(TrafficLightsLibrary.LightBulbs.ColorLightBulbs.Green);
        }

        [TestCase(LightBulbs.StateBulb.SwitchOn)]
        [TestCase(LightBulbs.StateBulb.SwitchOff)]
        [TestCase(LightBulbs.StateBulb.Blink)]
        public void Set_Cur_State_Test(LightBulbs.StateBulb newState)
        {
            _lightBulbs.SetStateBulb(newState);
            _lightBulbs.CurrentState.Should().Be(newState, because: $"Light bulb state should be {newState}");

        }
    }
}

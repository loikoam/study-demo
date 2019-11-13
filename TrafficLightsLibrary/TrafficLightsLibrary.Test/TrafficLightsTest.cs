using System;
using Bogus;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;

namespace TrafficLightsLibrary.Test
{
    [TestFixture]
    public class TrafficLightsTest
    {
        TrafficLight _trafficLight;

        //[SetUp]
        [OneTimeSetUp]
        public void Traffic_Lights_SetUp()
        {
            //use Bogus - внутри находится очень много данных для фейка
            var faker = new Faker<SourceOfPower>();

            faker.RuleFor(_ => _.SourceOfPowerSwitchOn, f => f.Random.Bool());
           // faker.RuleFor(_ => _.LastName, f => f.Person.LastName);

            var sourceOfPowers = faker.Generate();
            _trafficLight = new TrafficLight(sourceOfPowers);
        }

        [Test]
        public void Get_Status_Test()
        {
            TrafficLight.TrafficLightStatus curStatus = _trafficLight.GetStatus();
            curStatus.Should().Be(_trafficLight._trafficLightStatus, because: $"Current traffic light status should be {_trafficLight._trafficLightStatus}");
        }

        //TODO нужно замокать метод проверки батареии
        [TestCase(TrafficLight.TrafficLightStatus.Stop)]
        [TestCase(TrafficLight.TrafficLightStatus.Ready)]
        [TestCase(TrafficLight.TrafficLightStatus.Go)]
        [TestCase(TrafficLight.TrafficLightStatus.Error)]
        public void Set_Status_Test(TrafficLight.TrafficLightStatus newStatus)
        {
            _trafficLight.SetStatus(newStatus);
            if (1==1)//_trafficLight._sourceOfPower._active)
                _trafficLight._trafficLightStatus.Should().Be(newStatus, because: $"New traffic light status should be {newStatus}");
            else
                _trafficLight._trafficLightStatus.Should().Be(TrafficLight.TrafficLightStatus.Error, because: $"An error occurred in the power supply");
        }

        //////Arange
        ////Calculator calc = new Calculator();
        //////Act
        ////var actual = calc.Sum(1, 2);
        //////Assert
        ////Assert.That(actual, Is.EqualTo(3));


        //var mock = new Mock<CalculatorLib.ILogger>();
        ////mock.Setup - позволяет настроить перехватчики, которые будут реагировать на вызов
        ////mock.Opject - превращается в нужный объект
        ////mock.Verify - чтобы верифицировать или проверить прокси объект

        //mock.Setup((Logger) => Logger.Log(It.IsAny<string>())).Callback(() => 

        //    System.Console.WriteLine("Called log method"));


        //    //use Bogus - внутри находится очень много данных для фейка
        //    var faker = new Faker<CalculatorLib.Person>();

        //faker.RuleFor(_ => _.FirstName, f => f.Person.FirstName);
        //    faker.RuleFor(_ => _.LastName, f => f.Person.LastName);

        //    var persons = faker.Generate(20);

    }
}

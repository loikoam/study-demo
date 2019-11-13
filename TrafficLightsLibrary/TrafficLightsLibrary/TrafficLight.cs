using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightsLibrary
{
    abstract public class TrafficLightAbstract
    {
        public enum TrafficLightStatus { Stop, Ready, Go, Error }

        public TrafficLightStatus _trafficLightStatus;

        public TrafficLightAbstract()
        {
            _trafficLightStatus = TrafficLightStatus.Error;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStatus"></param>
        public void SetStatus(TrafficLightStatus newStatus)
        {
            this._trafficLightStatus = newStatus;
        }

        public TrafficLightStatus GetStatus()
        {
            return this._trafficLightStatus;
            //throw new NotImplementedException();
        }
    }

    public class TrafficLight : TrafficLightAbstract
    {
        private readonly SourceOfPower _sourceOfPower;
        LightBulbs _greenLightBulb;
        LightBulbs _yellowLightBulb;
        LightBulbs _redLightBulb;

        public TrafficLight(SourceOfPower sourceOfPower)// : base(sourceOfPower)
        {
            this._sourceOfPower = sourceOfPower;
            _greenLightBulb = new LightBulbs(LightBulbs.ColorLightBulbs.Green);
            _yellowLightBulb = new LightBulbs(LightBulbs.ColorLightBulbs.Yellow);
            _redLightBulb = new LightBulbs(LightBulbs.ColorLightBulbs.Red);

            _greenLightBulb.SetStateBulb(LightBulbs.StateBulb.SwitchOff);
            _yellowLightBulb.SetStateBulb(LightBulbs.StateBulb.SwitchOff);
            _redLightBulb.SetStateBulb(LightBulbs.StateBulb.SwitchOff);
        }

        new public void SetStatus(TrafficLightStatus newStatus)
        {
            if (_sourceOfPower.SourceOfPowerSwitchOn)
            {
                this._trafficLightStatus = newStatus;
                SetStateLightBulbs(newStatus);
            }
            else
            {
                this._trafficLightStatus = TrafficLightStatus.Error;
                SetStateLightBulbs(TrafficLightStatus.Error);
            }
        }

        private void SetStateLightBulbs(TrafficLightStatus statusTrafficLights)
        {
            switch(statusTrafficLights)
            {
                case TrafficLightStatus.Error:
                    {
                        _greenLightBulb.SetStateBulb(LightBulbs.StateBulb.SwitchOff);
                        _yellowLightBulb.SetStateBulb(LightBulbs.StateBulb.Blink);
                        _redLightBulb.SetStateBulb(LightBulbs.StateBulb.SwitchOff);
                        break;
                    }
                case TrafficLightStatus.Go:
                    {
                        _greenLightBulb.SetStateBulb(LightBulbs.StateBulb.SwitchOn);
                        _yellowLightBulb.SetStateBulb(LightBulbs.StateBulb.SwitchOff);
                        _redLightBulb.SetStateBulb(LightBulbs.StateBulb.SwitchOff);
                        break;
                    }
                case TrafficLightStatus.Ready:
                    {
                        _greenLightBulb.SetStateBulb(LightBulbs.StateBulb.SwitchOff);
                        _yellowLightBulb.SetStateBulb(LightBulbs.StateBulb.SwitchOn);
                        _redLightBulb.SetStateBulb(LightBulbs.StateBulb.SwitchOn);
                        break;
                    }
                case TrafficLightStatus.Stop:
                    {
                        _greenLightBulb.SetStateBulb(LightBulbs.StateBulb.SwitchOff);
                        _yellowLightBulb.SetStateBulb(LightBulbs.StateBulb.SwitchOff);
                        _redLightBulb.SetStateBulb(LightBulbs.StateBulb.SwitchOn);
                        break;
                    }
                default: break;
            }
        }
    }
}

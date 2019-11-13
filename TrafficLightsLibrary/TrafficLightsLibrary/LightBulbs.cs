using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightsLibrary
{
    public class LightBulbs
    {
        public enum StateBulb { SwitchOn, SwitchOff, Blink}
        public enum ColorLightBulbs { Green, Yellow, Red}
        private ColorLightBulbs ColorLightBulb { get; set; }
        public StateBulb CurrentState {  get; private set; }

        public LightBulbs(ColorLightBulbs colorLightBulb)
        {
            ColorLightBulb = colorLightBulb;
            CurrentState = StateBulb.SwitchOff;
        }

        public void SetStateBulb(StateBulb newState)
        {
            this.CurrentState = newState;
        }
    }
}

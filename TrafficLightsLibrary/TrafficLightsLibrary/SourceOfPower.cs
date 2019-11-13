using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightsLibrary
{
    public class SourceOfPower
    {
        public bool SourceOfPowerSwitchOn { get; private set; }

        public SourceOfPower()
        {
            SourceOfPowerSwitchOn = true;
        }

        private void SetActiveState(bool newState)
        {
            this.SourceOfPowerSwitchOn = newState;
        }
    }
}

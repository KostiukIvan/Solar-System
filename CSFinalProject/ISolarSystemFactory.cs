using System;
using System.Collections.Generic;
using System.Text;

namespace CSFinalProject
{
    interface ISolarSystemFactory
    {
        SolarSystem CreateSunSolarSystem();
        SolarSystem CreateAuroraSolarSystem();
    }
}

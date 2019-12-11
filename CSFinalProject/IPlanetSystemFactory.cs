using System;
using System.Collections.Generic;
using System.Text;

namespace CSFinalProject
{
    interface IPlanetSystemFactory
    {

        PlanetSystem GetMercury();
        PlanetSystem GetVenus();
        PlanetSystem GetEarth();
        PlanetSystem GetMars();
        PlanetSystem GetJupiter();
        PlanetSystem GetSaturn();
        PlanetSystem GetUranus();
        PlanetSystem GetNeptune();
        PlanetSystem GetPluto();

    }
}

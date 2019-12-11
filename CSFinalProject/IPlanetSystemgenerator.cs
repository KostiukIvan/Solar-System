using System;
using System.Collections.Generic;
using System.Text;

namespace CSFinalProject
{
    interface IPlanetSystemGenarator
    {
        Planet CreatePlanet(Tuple<double, double> coord, double diameter, double mass, double ellipseParameterA,
                        double ellipseParameterB, double speed, double orbitalPeriod, Tuple<double, double> coordinatesOfEllipseCenter);
        Moon CreateMoon(Tuple<double, double> coord, double diameter, double mass, double ellipseParameterA, double ellipseParameterB,
                        double speed, Tuple<double, double> coordinatesOfElipseCenter);
        PlanetSystem CreatePlanetSystem(Planet planet, List<Moon> moons);

    }
}

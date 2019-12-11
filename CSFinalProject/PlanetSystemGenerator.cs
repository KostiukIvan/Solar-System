using System;
using System.Collections.Generic;
using System.Text;

namespace CSFinalProject
{
    class PlanetSystemGenarator : IPlanetSystemGenarator
    {
        public Moon CreateMoon(Tuple<double, double> coord, double diameter, double mass, double ellipseParameterA, double ellipseParameterB, double speed, Tuple<double, double> coordinatesOfElipseCenter)
        {
            try
            {
                return new Moon(coord, diameter, mass, ellipseParameterA, ellipseParameterB, speed, coordinatesOfElipseCenter);
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }

        public Planet CreatePlanet(Tuple<double, double> coord, double diameter, double mass, double ellipseParameterA, double ellipseParameterB, double speed, double orbitalPeriod, Tuple<double, double> coordinatesOfEllipseCenter)
        {
            try
            {
                return new Planet(coord, diameter, mass, ellipseParameterA, ellipseParameterB, speed, orbitalPeriod, coordinatesOfEllipseCenter);
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }

        public PlanetSystem CreatePlanetSystem(Planet planet, List<Moon> moons)
        {
            try
            {
                if(moons == null)
                {
                    return new PlanetSystem(planet);
                }
                else
                {
                    return new PlanetSystem(planet, moons);
                }
                
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
    }
}

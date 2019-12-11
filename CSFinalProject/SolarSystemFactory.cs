using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSFinalProject
{
    class SolarSystemFactory : ISolarSystemFactory
    {
        IPlanetSystemFactory factoryPlanetSystem = new PlanetSystemFactory();
        ISunFactory factorySun = new SunFactory();
        public SolarSystem CreateSunSolarSystem()
        {
            try
            {
                List<PlanetSystem> planets = new List<PlanetSystem>();
                //Coordinates 1 is equal 1*10^6 KM
                //Diameter = (KM)
                //Mass = (10^24 kg)
                //Aphelion = (10^6 km)
                //Perihelion = (10^6 km)
                //Speed = (km/s)

                planets.Add(factoryPlanetSystem.GetMercury());
                //VENUS
                planets.Add(factoryPlanetSystem.GetVenus());
                //EARTH
                planets.Add(factoryPlanetSystem.GetEarth());
                //MARS
                planets.Add(factoryPlanetSystem.GetMars());
                //JUPITER
                planets.Add(factoryPlanetSystem.GetJupiter());
                //SATURN
                planets.Add(factoryPlanetSystem.GetSaturn());
                //URANUS
                planets.Add(factoryPlanetSystem.GetUranus());
                //NEPTUNE
                planets.Add(factoryPlanetSystem.GetNeptune());
                //PLUTO
                planets.Add(factoryPlanetSystem.GetPluto());

                var result = new SolarSystem(planets, factorySun.GetNewNormalSun());
                result.Coordinates = new Tuple<double, double>(400, -260);
                result.Vector = new Tuple<double, double>(8, 8);
                result.Speed = 4;
                result.Name = "Sun Solar System";
                return result;
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public SolarSystem CreateAuroraSolarSystem()
        {
            try
            {
                List<PlanetSystem> planets = new List<PlanetSystem>();
                //Coordinates 1 is equal 1*10^6 KM
                //Diameter = (KM)
                //Mass = (10^24 kg)
                //Aphelion = (10^6 km)
                //Perihelion = (10^6 km)
                //Speed = (km/s)

                //JUPITER
                planets.Add(factoryPlanetSystem.GetJupiter());
                //SATURN
                planets.Add(factoryPlanetSystem.GetSaturn());
                //URANUS
                planets.Add(factoryPlanetSystem.GetUranus());
                //NEPTUNE
                planets.Add(factoryPlanetSystem.GetNeptune());
                //PLUTO
                planets.Add(factoryPlanetSystem.GetPluto());

                var result = new SolarSystem(planets, factorySun.GetNewRedSun());
                result.Coordinates = new Tuple<double, double>(-223, -260);
                result.Vector = new Tuple<double, double>(20, 8);
                result.Speed = 4;
                result.Name = "Aurora Solar System";
                return result;
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }

    }
    [TestFixture]
    public class TestSolarSystemFactory
    {
        [Test]
        public void GetSolarSystem()
        {
            SolarSystemFactory factory = new SolarSystemFactory();
            Assert.AreEqual(factory.CreateSunSolarSystem().Name.ToString(), "Sun Solar System");
            Assert.AreEqual(factory.CreateAuroraSolarSystem().Name.ToString(), "Aurora Solar System");
        }
    }
}

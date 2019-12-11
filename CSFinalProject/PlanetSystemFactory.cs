using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSFinalProject
{
    class PlanetSystemFactory : IPlanetSystemFactory
    {
        //Coordinates 1 is equal 1*10^6 KM
        //Diameter = (KM)
        //Mass = (10^24 kg)
        //Aphelion = (10^6 km)
        //Perihelion = (10^6 km)
        //Speed = (km/s)
        IPlanetSystemGenarator generator = new PlanetSystemGenarator();
        public PlanetSystem GetMercury()
        {
            try
            {
                //var Mercury = generator.CreatePlanet(new Tuple<double, double>(69.8, 0), 4878, 0.33, 69.8, 46.0, 47.4, 88.0, new Tuple<double, double>(101, 101));
                //Mercury.Name = "Mercury";
                //return generator.CreatePlanetSystem(Mercury, null);
                var Mercury = new Planet();
                Mercury.Name = "Mercury";
                Mercury.Coordinates = new Tuple<double, double>(69.8, 0);
                Mercury.Diametr = 4878;
                Mercury.Mass = 0.33;
                Mercury.ELlipseParamA = 69.8;
                Mercury.ELlipseParamB = 46.0;
                Mercury.Speed = 47.4;
                Mercury.OrbitalPeriod = 88.0;
                Mercury.EllipseCenter = new Tuple<double, double>(101, 101);
                return generator.CreatePlanetSystem(Mercury, null);
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public PlanetSystem GetVenus()
        {
            try
            {
                //var Venus = generator.CreatePlanet(new Tuple<double, double>(108.9, 0), 12101, 4.87, 108.9, 107.5, 35.0, 224.7, new Tuple<double, double>(101, 101));
                //Venus.Name = "Venus";
                //return generator.CreatePlanetSystem(Venus, null);
                var Venus = new Planet();
                Venus.Name = "Venus";
                Venus.Coordinates = new Tuple<double, double>(108.9, 0);
                Venus.Diametr = 12101;
                Venus.Mass = 4.87;
                Venus.ELlipseParamA = 108.9;
                Venus.ELlipseParamB = 107.5;
                Venus.Speed = 35.0;
                Venus.OrbitalPeriod = 224.7;
                Venus.EllipseCenter = new Tuple<double, double>(101, 101);
                return generator.CreatePlanetSystem(Venus, null);
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public PlanetSystem GetEarth()
        {
            try
            {
                //var Earth = generator.CreatePlanet(new Tuple<double, double>(152.1, 0), 12756, 5.97, 152.1, 147.1, 29.8, 365.2, new Tuple<double, double>(101, 101));
                //List<Moon> moons = new List<Moon>() { generator.CreateMoon(new Tuple<double, double>(150, 0), 3475, 0.73, 0.406, 0.363, 1.0, Earth.Coordinates) };
                //Earth.Name = "Earth";
                //return generator.CreatePlanetSystem(Earth, moons);
                var Earth = new Planet();
                Earth.Name = "Earth";
                Earth.Coordinates = new Tuple<double, double>(152.1, 0);
                Earth.Diametr = 12756;
                Earth.Mass = 5.97;
                Earth.ELlipseParamA = 152.1;
                Earth.ELlipseParamB = 147.1;
                Earth.Speed = 29.8;
                Earth.OrbitalPeriod = 365.2;
                Earth.EllipseCenter = new Tuple<double, double>(101, 101);
                var Moon = new Moon();
                Moon.CreateMoon();
                return generator.CreatePlanetSystem(Earth, new List<Moon> { Moon });
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public PlanetSystem GetMars()
        {
            try
            {
                //var Mars = generator.CreatePlanet(new Tuple<double, double>(249.2, 0), 6792, 0.642, 249.2, 206.6, 24.1, 687.0, new Tuple<double, double>(101, 101));
                //Mars.Name = "Mars";
                //return generator.CreatePlanetSystem(Mars, null);
                var Mars = new Planet();
                Mars.Name = "Mars";
                Mars.Coordinates = new Tuple<double, double>(249.2, 0);
                Mars.Diametr = 6752;
                Mars.Mass = 0.642;
                Mars.ELlipseParamA = 249.2;
                Mars.ELlipseParamB = 206.6;
                Mars.Speed = 24.1;
                Mars.OrbitalPeriod = 687.0;
                Mars.EllipseCenter = new Tuple<double, double>(101, 101);
                return generator.CreatePlanetSystem(Mars, null);
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public PlanetSystem GetJupiter()
        {
            try
            {
                //var Jupiter = generator.CreatePlanet(new Tuple<double, double>(816.6, 0), 142984, 1898, 816.6, 740.5, 13.1, 4331, new Tuple<double, double>(101, 101));
                //Jupiter.Name = "Jupiter";
                //return generator.CreatePlanetSystem(Jupiter, null);
                var Jupiter = new Planet();
                Jupiter.Name = "Jupiter";
                Jupiter.Coordinates = new Tuple<double, double>(816.6, 0);
                Jupiter.Diametr = 142984;
                Jupiter.Mass = 1898;
                Jupiter.ELlipseParamA = 816.6;
                Jupiter.ELlipseParamB = 740.5;
                Jupiter.Speed = 13.1;
                Jupiter.OrbitalPeriod = 433.1;
                Jupiter.EllipseCenter = new Tuple<double, double>(101, 101);
                return generator.CreatePlanetSystem(Jupiter, null);
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public PlanetSystem GetSaturn()
        {
            try
            {
                //var Saturn = generator.CreatePlanet(new Tuple<double, double>(1514.5, 0), 120537, 568, 1514.5, 1352.6, 9.7, 10747, new Tuple<double, double>(101, 101));
                //Saturn.Name = "Saturn";
                //return generator.CreatePlanetSystem(Saturn, null);
                var Saturn = new Planet();
                Saturn.Name = "Saturn";
                Saturn.Coordinates = new Tuple<double, double>(1514.5, 0);
                Saturn.Diametr = 120537;
                Saturn.Mass = 568;
                Saturn.ELlipseParamA = 1514.5;
                Saturn.ELlipseParamB = 1352.6;
                Saturn.Speed = 9.7;
                Saturn.OrbitalPeriod = 10747;
                Saturn.EllipseCenter = new Tuple<double, double>(101, 101);
                return generator.CreatePlanetSystem(Saturn, null);
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public PlanetSystem GetUranus()
        {
            try
            {
                //var Uranus = generator.CreatePlanet(new Tuple<double, double>(3003.6, 0), 51118, 86.6, 3003.6, 2741.3, 6.8, 30589, new Tuple<double, double>(101, 101));
                //
                //return generator.CreatePlanetSystem(Uranus, null);
                var Uranus = new Planet();
                Uranus.Name = "Uranus";
                Uranus.Coordinates = new Tuple<double, double>(3003.6, 0);
                Uranus.Diametr = 51118;
                Uranus.Mass = 86.6;
                Uranus.ELlipseParamA = 3003.6;
                Uranus.ELlipseParamB = 2741.3;
                Uranus.Speed = 6.8;
                Uranus.OrbitalPeriod = 30589;
                Uranus.EllipseCenter = new Tuple<double, double>(101, 101);
                return generator.CreatePlanetSystem(Uranus, null);
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public PlanetSystem GetNeptune()
        {
            try
            {
                //var Neptune = generator.CreatePlanet(new Tuple<double, double>(4545.7, 0), 4952.8, 102, 4545.7, 4444.5, 5.4, 59800, new Tuple<double, double>(101, 101));
                //Neptune.Name = "Neptune";
                //return generator.CreatePlanetSystem(Neptune, null);
                var Neptune = new Planet();
                Neptune.Name = "Neptune";
                Neptune.Coordinates = new Tuple<double, double>(4545.7, 0);
                Neptune.Diametr = 4952.8;
                Neptune.Mass = 102;
                Neptune.ELlipseParamA = 4545.7;
                Neptune.ELlipseParamB = 4444.5;
                Neptune.Speed = 5.4;
                Neptune.OrbitalPeriod = 59800;
                Neptune.EllipseCenter = new Tuple<double, double>(101, 101);
                return generator.CreatePlanetSystem(Neptune, null);
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public PlanetSystem GetPluto()
        {
            try
            {
                //var Pluto = generator.CreatePlanet(new Tuple<double, double>(7375.9, 0), 2370, 0.0146, 7375.9, 4436.8, 4.7, 90560, new Tuple<double, double>(101, 101));
                //Pluto.Name = "Pluto";
                //return generator.CreatePlanetSystem(Pluto, null);
                var Pluto = new Planet();
                Pluto.Name = "Pluto";
                Pluto.Coordinates = new Tuple<double, double>(7375.9, 0);
                Pluto.Diametr = 2370;
                Pluto.Mass = 0.0146;
                Pluto.ELlipseParamA = 7375.9;
                Pluto.ELlipseParamB = 4436.8;
                Pluto.Speed = 4.7;
                Pluto.OrbitalPeriod = 90560;
                Pluto.EllipseCenter = new Tuple<double, double>(101, 101);
                return generator.CreatePlanetSystem(Pluto, null);
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }

    }
    [TestFixture]
    public class TestPlanetSystemFactory
    {
        [Test]
        public void GetPlanet()
        {
            PlanetSystem p;
            PlanetSystemFactory factory = new PlanetSystemFactory();
            Assert.AreEqual(factory.GetMercury().Planet.Name.ToString(), "Mercury");
            Assert.AreEqual(factory.GetVenus().Planet.Name.ToString(), "Venus");
            Assert.AreEqual(factory.GetEarth().Planet.Name.ToString(), "Earth");
            Assert.AreEqual(factory.GetMars().Planet.Name.ToString(), "Mars");
            Assert.AreEqual(factory.GetJupiter().Planet.Name.ToString(), "Jupiter");
            Assert.AreEqual(factory.GetSaturn().Planet.Name.ToString(), "Saturn");
            Assert.AreEqual(factory.GetUranus().Planet.Name.ToString(), "Uranus");
            Assert.AreEqual(factory.GetNeptune().Planet.Name.ToString(), "Neptune");
            Assert.AreEqual(factory.GetPluto().Planet.Name.ToString(), "Pluto");

        }
    }
}

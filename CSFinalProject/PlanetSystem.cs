using System;
using System.Collections.Generic;
using System.Text;

namespace CSFinalProject
{
    public class PlanetSystem : IPlanetSystem
    {

        readonly private List<Moon> _moons;
        private readonly int _amountOfMoons;
        readonly private Planet _planet;
        private double _angle;
        public Planet Planet
        {
            get { return _planet; }
        }
        public Tuple<double, double> Coordinates
        {
            set { _planet.Coordinates = value; }
            get { return _planet.Coordinates; }

        }
        public double Speed
        {
            get { return _planet.Speed; }
            set { _planet.Speed = value; }
        }
        public double ELlipseParamA
        {
            get { return _planet.ELlipseParamA; }
            set { _planet.ELlipseParamA = value; }
        }
        public double ELlipseParamB
        {
            get { return _planet.ELlipseParamB; }
            set { _planet.ELlipseParamB = value; }
        }
        public double OrbitalPeriod
        {
            set { _planet.OrbitalPeriod = value; }
            get { return _planet.OrbitalPeriod; }
        }
        public Tuple<double, double> EllipseCenter
        {
            get { return _planet.EllipseCenter; }
            set { _planet.EllipseCenter = value; }
        }
        public double Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }
        public int Months
        {
            get { return _amountOfMoons; }
        }
        public PlanetSystem(Planet planet, List<Moon> moons)
        {
            _moons = moons;
            _planet = planet;
        }
        public PlanetSystem(Planet planet)
        {
            _planet = planet;
        }
        public PlanetSystem()
        {
            
        }


    }
}

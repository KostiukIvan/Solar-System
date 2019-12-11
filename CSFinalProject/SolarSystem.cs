using System;
using System.Collections.Generic;
using System.Text;

namespace CSFinalProject
{
    public class SolarSystem : ISolarSystem
    {
        private string _name;
        private List<PlanetSystem> _planets;
        private Sun _sun;
        private Tuple<double,double> _coordinates;
        private Tuple<double, double> _vector;
        private double _speed;
        public Sun SunProp { get { return _sun; } }
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        public Tuple<double, double> Coordinates
        {
            set { _coordinates = value; }
            get { return _coordinates; }

        }
        public double Speed
        {
            set { _speed = value; }
            get { return _speed; }
        }
        public Tuple<double, double> Vector
        {
            set { _vector = value; }
            get { return _vector; }
        }
        public List<PlanetSystem> Planets
        {
            get { return _planets; }
        }
        public SolarSystem(List<PlanetSystem> planets, Sun sun)
        {
            _planets = planets;
            _sun = sun;
        }
    }
}

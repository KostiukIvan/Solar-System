using System;
using System.Collections.Generic;
using System.Text;

namespace CSFinalProject
{
    public class Planet : IPlanet
    {
        public Tuple<double, double> Coordinates { get; set; }
        private string _name;
        private double _diameter;
        private double _mass;
        private double _orbitalPeriod;
        private double _ellipseParameterA;
        private double _ellipseParameterB;
        private Tuple<double, double> _coordinatesOfEllipseCenter;
        public string Name { get { return _name; } set { _name = value; } }
        public double Speed { get; set; }
        public double ELlipseParamA
        {
            get { return _ellipseParameterA; }
            set { _ellipseParameterA = value; }
        }
        public double ELlipseParamB
        {
            get { return _ellipseParameterB; }
            set { _ellipseParameterB = value; }
        }
        public Tuple<double, double> EllipseCenter
        {
            get { return _coordinatesOfEllipseCenter; }
            set { _coordinatesOfEllipseCenter = value; }
        }
        public double OrbitalPeriod
        {
            set { _orbitalPeriod = value; }
            get { return _orbitalPeriod; }
        }
        public double Mass
        {
            set { _mass = value; }
            get { return _mass; }
        }
        public double Diametr
        {
            set { _diameter = value; }
            get { return _diameter; }
        }

        public Planet(Tuple<double, double> coord, double diameter, double mass, double ellipseParameterA,
                        double ellipseParameterB, double speed, double orbital, Tuple<double, double> coordinatesOfEllipseCenter)
        {
            Coordinates = coord;
            _diameter = diameter;
            _mass = mass;
            _ellipseParameterA = ellipseParameterA;
            _ellipseParameterB = ellipseParameterB;
            Speed = speed;
            _orbitalPeriod = orbital;
            _coordinatesOfEllipseCenter = coordinatesOfEllipseCenter;
        }
        public Planet()
        {

        }


    }
}

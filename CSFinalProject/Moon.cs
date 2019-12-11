using System;
using System.Collections.Generic;
using System.Text;

namespace CSFinalProject
{
    public class Moon : IMoon
    {

        private Tuple<double, double> _coordinates;
        private double _diameter;
        private double _mass;
        private double _ellipseParameterA;
        private double _ellipseParameterB;
        private double _speed;
        private Tuple<double, double> _coordinatesOfEllipseCenter;
        public Tuple<double, double> Coordinates
        {
            get { return _coordinates; }
            set { _coordinates = value; }
        }
        public double Diametr
        {
            get { return _diameter; }
            set { _diameter = value; }
        }
        public double Mass
        {
            get { return _mass; }
            set { _mass = value; }
        }
        public double EllipseA
        {
            get { return _ellipseParameterA; }
            set { _ellipseParameterA = value; }
        }
        public double EllipseB
        {
            get { return _ellipseParameterB; }
            set { _ellipseParameterB = value; }
        }
        public double Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Moon(Tuple<double, double> coord, double diameter, double mass, double ellipseParameterA, double ellipseParameterB,
                        double speed, Tuple<double, double> coordinatesOfElipseCenter)
        {
            _coordinates = coord;
            _diameter = diameter;
            _mass = mass;
            _ellipseParameterA = ellipseParameterA;
            _ellipseParameterB = ellipseParameterB;
            _speed = speed;
            _coordinatesOfEllipseCenter = coordinatesOfElipseCenter;
        }
        public void CreateMoon()
        {
            _coordinates = new Tuple<double, double>(33,33);
            _diameter = 333;
            _mass = 333;
            _ellipseParameterA = 3334;
            _ellipseParameterB = 3334;
            _speed = 3333;
            _coordinatesOfEllipseCenter = new Tuple<double, double>(33, 33);
        }
        public Moon()
        {

        }
    }
}

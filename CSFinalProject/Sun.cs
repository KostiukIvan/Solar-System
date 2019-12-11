using System;
using System.Collections.Generic;
using System.Text;

namespace CSFinalProject
{
    public class Sun : ISun
    {
        public Tuple<double, double> Coordinates { get; set; }
        readonly private string _name;
        readonly private double _mass;
        readonly private double _temperature;
        readonly private string _color;
        readonly private double _luminosity;
        public string Name { get { return _name; }}
        public double Speed { get; set; }
        public Tuple<double, double> Vector { get; set; }

        public double Mass
        {
            get { return _mass; }
        }
        public double Tempertura
        {
            get { return _temperature; }
        }
        public string Color
        {
            get { return _color; }
        }
        public double Luminiosity
        {
            get { return _luminosity; }
        }


        public Sun(Tuple<double, double> coord, string name, double mass, double temperature, string color, double luminosity,
                    double speed)
        {
            Coordinates = coord;
            _name = name;
            _mass = mass;
            _temperature = temperature;
            _color = color;
            _luminosity = luminosity;
            Speed = speed;
            // _vector = vectro;
        }
    }
}

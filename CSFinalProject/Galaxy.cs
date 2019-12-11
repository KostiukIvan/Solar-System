using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace CSFinalProject
{
    //1 coordinate distane = 1 000 000 km
    public class Galaxy : IGalaxy
    {
        private List<SolarSystem> _solarSystems;
        private Tuple<double, double> _coordinates;
        private Tuple<double, double> _vector;
        public Tuple<double, double> Coordinates
        {
            get { return _coordinates; }
            set { _coordinates = value; }
        }
        public Tuple<double, double> Vector
        {
            get { return _vector; }
            set { _vector = value; }
        }
        public double Speed { get; set; }
        public List<SolarSystem> SolarSystems
        {
            get { return _solarSystems; }
        }
        public Galaxy()
        {
            
        }
        public Galaxy(List<SolarSystem> listSolarSystems)
        {
            _solarSystems = listSolarSystems;
        }

        //Fabric Methods
        //On nie jest tu potrzebny, uzylem zeby zwiekszysc ilosc wzorcow! :)
        public void CreateNormalGalaxy()
        {
            try
            {
                ISolarSystemFactory factory = new SolarSystemFactory();
                List<SolarSystem> list = new List<SolarSystem>();
                list.Add(factory.CreateAuroraSolarSystem());
                list.Add(factory.CreateSunSolarSystem());
                Speed = 10;
                Vector = new Tuple<double, double>(2, 3);
                Coordinates = new Tuple<double, double>(300, 300);
                _solarSystems = list;
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }

        //Here we can use Bridge (Udemy)
        void ShowGalaxy()
        {
           
        }
    }
}

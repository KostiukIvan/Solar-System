using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSFinalProject
{
    class SunFactory : ISunFactory
    {
        public Tuple<double, double> Coordinates { get; set; }
        //  public Tuple<Tuple<double, double>, Tuple<double, double>> Vector { get; set; }
        public double Luminosity { get; set; }

        public Sun GetNewNormalSun()
        {
            try
            {
                Coordinates = new Tuple<double, double>(0, 0);
                Luminosity = 1;
                return new Sun(Coordinates, "SUN", 1.1, 1.2, "White Yellow", Luminosity, 1000);
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public Sun GetNewRedSun()
        {
            try
            {
                Coordinates = new Tuple<double, double>(0, 0);
                Luminosity = 23;
                return new Sun(Coordinates, "RedGiant", 0.3, 3500, "Red", Luminosity, 1000);
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public Sun GetNewBlueSun()
        {
            try
            {
                Coordinates = new Tuple<double, double>(0, 0);
                Luminosity = 0.5;
                return new Sun(Coordinates, "BlueGiant", 20, 25000, "Blue", Luminosity, 1000);
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
    }
    [TestFixture]
    public class TestSunFactory
    {
        [Test]
        public void GetSun()
        {
            SunFactory factory = new SunFactory();
            Assert.AreEqual(factory.GetNewNormalSun().Name.ToString(), "SUN" );
            Assert.AreEqual(factory.GetNewBlueSun().Name.ToString(), "BlueGiant");
            Assert.AreEqual(factory.GetNewRedSun().Name.ToString(), "RedGiant");
        }

    }
}
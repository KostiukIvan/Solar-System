using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CSFinalProject
{
    public class DateAndTime : IDateAndTime
    {
        CoordinatesTriger _triger;
        DateTime _data;
        public DateAndTime()
        {
            _triger = new CoordinatesTriger();
            _data = new DateTime(2492, 5, 6, 1, 0, 0);
        }

        public void MakeOneDayFoward(Galaxy galaxy)
        {
            foreach (var solarSys in galaxy.SolarSystems)
            {
                _triger.ChangeCoordinatesOfSolarSystemByOneDay(solarSys);
                foreach (var planet in solarSys.Planets)
                {
                    _triger.ChangeCoordinatesOfPlanetSystemByOneDay(planet, solarSys);
                }
            }
        }
        public void MakeOneDayBackward(Galaxy galaxy)
        {
            foreach (var solarSys in galaxy.SolarSystems)
            {
                _triger.ChangeCoordinatesOfSolarSystemByOneDayBefore(solarSys);
                foreach (var planet in solarSys.Planets)
                {
                    _triger.ChangeCoordinatesOfPlanetSystemByOneDayBefore(planet, solarSys);
                }
            }
        }
        public DateTime AddYears(Galaxy galaxy, int year)
        {
            try
            {
                _data = _data.AddYears(year);
                for (int k = 0; k < year; k++)
                {
                    for (int i = 0; i < 365; i++)
                    {
                        MakeOneDayFoward(galaxy);
                    }
                }
                return this._data;
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public DateTime AddMonths(Galaxy galaxy, int months)
        {
            try
            {
                _data = _data.AddMonths(months);
                for (int k = 0; k < months; k++)
                {
                    for (int i = 0; i < 365 / 12; i++)
                    {
                        MakeOneDayFoward(galaxy);
                    }
                }
                return this._data;
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public DateTime AddDays(Galaxy galaxy, int days)
        {
            try
            {
                _data = _data.AddDays(days);
                for (int i = 0; i < days; i++)
                {
                    MakeOneDayFoward(galaxy);
                }
                return this._data;
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public DateTime SubtractYears(Galaxy galaxy,int year)
        {
            try
            {
                _data = _data.AddYears(-year);
                for (int k = 0; k < year; k++)
                {
                    for (int i = 0; i < 365; i++)
                    {
                        MakeOneDayBackward(galaxy);
                    }
                }
                return this._data;
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public DateTime SubtractMonths(Galaxy galaxy,int months)
        {
            try
            {
                _data = _data.AddMonths(-months);
                for (int k = 0; k < months; k++)
                {
                    for (int i = 0; i < 365 / 12; i++)
                    {
                        MakeOneDayBackward(galaxy);
                    }
                }
                return this._data;
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public DateTime SubtractDays(Galaxy galaxy,int days)
        {
            try
            {
                _data = _data.AddDays(-days);
                for (int k = 0; k < days; k++)
                {
                    MakeOneDayBackward(galaxy);
                }
                return this._data;
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public override string ToString()
        {
            return _data.ToString();
        }
    }
    [TestFixture]
    public class TestDataAndTime
    {
        [Test]
        public void ForwardDayChangesInPlanet_AddDays()
        {
            IDateAndTime date = new DateAndTime();
            Galaxy g = new Galaxy();
            g.CreateNormalGalaxy();
            //One day changes
            DateTime result = date.AddDays(g, 1);
            Assert.AreEqual(result, new DateTime(2492, 5, 7, 1, 0, 0));
            //0 days changes
            result = date.AddDays(g, 0);
            Assert.AreEqual(result, new DateTime(2492, 5, 7, 1, 0, 0));

        }

        [Test]
        public void ForwardDayChangesInPlanet_AddMonth()
        {
            IDateAndTime date = new DateAndTime();
            Galaxy g = new Galaxy();
            g.CreateNormalGalaxy();
            //One day changes
            DateTime result = date.AddMonths(g, 1);
            Assert.AreEqual(result, new DateTime(2492, 6, 6, 1, 0, 0));
            //0 days changes
            result = date.AddMonths(g, 0);
            Assert.AreEqual(result, new DateTime(2492, 6, 6, 1, 0, 0));
        }
        
        [Test]
        public void ForwardDayChangesInPlanet_AddYears()
        {
            IDateAndTime date = new DateAndTime();
            Galaxy g = new Galaxy();
            g.CreateNormalGalaxy();
            //One day changes
            DateTime result = date.AddYears(g, 1);
            Assert.AreEqual(result, new DateTime(2493, 5, 6, 1, 0, 0));
            //0 days changes
            result = date.AddYears(g, 0);
            Assert.AreEqual(result, new DateTime(2493, 5, 6, 1, 0, 0));

        }

        [Test]
        public void BackwardDayChangesInPlanet_SubDays()
        {
            IDateAndTime date = new DateAndTime();
            Galaxy g = new Galaxy();
            g.CreateNormalGalaxy();
            //One day changes
            DateTime result = date.SubtractDays(g, 1);
            Assert.AreEqual(result, new DateTime(2492, 5, 5, 1, 0, 0));
            //0 days changes
            result = date.SubtractDays(g, 0);
            Assert.AreEqual(result, new DateTime(2492, 5, 5, 1, 0, 0));

        }

        [Test]
        public void BackwardDayChangesInPlanet_SubMonth()
        {
            IDateAndTime date = new DateAndTime();
            Galaxy g = new Galaxy();
            g.CreateNormalGalaxy();
            //One day changes
            DateTime result = date.SubtractMonths(g, 1);
            Assert.AreEqual(result, new DateTime(2492, 4, 6, 1, 0, 0));
            //0 days changes
            result = date.SubtractMonths(g, 0);
            Assert.AreEqual(result, new DateTime(2492, 4, 6, 1, 0, 0));
        }

        [Test]
        public void BackwardDayChangesInPlanet_SubYears()
        {
            IDateAndTime date = new DateAndTime();
            Galaxy g = new Galaxy();
            g.CreateNormalGalaxy();
            //One day changes
            DateTime result = date.SubtractYears(g, 1);
            Assert.AreEqual(result, new DateTime(2491, 5, 6, 1, 0, 0));
            //0 days changes
            result = date.SubtractYears(g, 0);
            Assert.AreEqual(result, new DateTime(2491, 5, 6, 1, 0, 0));

        }

    }
}

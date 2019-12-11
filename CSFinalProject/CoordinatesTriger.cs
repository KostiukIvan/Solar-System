using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CSFinalProject
{
    interface StateStrategy
    {
        Tuple<double, double> PerformeAction(Tuple<double, double> tuplia, double changes_for_X, double changes_for_Y);
    }
    class ToRightUp : StateStrategy
    {
        public Tuple<double,double> PerformeAction(Tuple<double, double> tuplia, double changes_for_X, double changes_for_Y)
        {
            return new Tuple<double, double>(tuplia.Item1 + changes_for_X, tuplia.Item2 + changes_for_Y);
        }
    }
    class ToRightDown : StateStrategy
    {
        public Tuple<double, double> PerformeAction(Tuple<double, double> tuplia, double changes_for_X, double changes_for_Y)
        {
            return new Tuple<double, double>(tuplia.Item1 - changes_for_X, tuplia.Item2 + changes_for_Y);
        }
    }
    class ToLeftDown : StateStrategy
    {
        public Tuple<double, double> PerformeAction(Tuple<double, double> tuplia, double changes_for_X, double changes_for_Y)
        {
            return new Tuple<double, double>(tuplia.Item1 - changes_for_X, tuplia.Item2 - changes_for_Y);
        }
    }
    class ToLeftUp : StateStrategy
    {
        public Tuple<double, double> PerformeAction(Tuple<double, double> tuplia, double changes_for_X, double changes_for_Y)
        {
            return new Tuple<double, double>(tuplia.Item1 + changes_for_X, tuplia.Item2 - changes_for_Y);
        }
    }
    class StrategyContext
    {
        private StateStrategy state;
        public StrategyContext()
        {

        }
        public void SetState(StateStrategy newstate)
        {
            this.state = newstate;
        }
        public Tuple<double, double> PerformeAction(Tuple<double, double> tuplia, double changes_for_X, double changes_for_Y)
        {
            return state.PerformeAction(tuplia, changes_for_X, changes_for_Y);
        }

    }

    //We will use this triger to change coordiantes of Planets and suns depends on time
    class CoordinatesTriger
    {
        StrategyContext state;
        public CoordinatesTriger()
        {
            state = new StrategyContext();
        }
        public Tuple<double,double> CoordintesChanges(Tuple<double,double> coordinates, Tuple<double,double> vector, double speed)
        {
            var oneDaydistancechanges = speed * 60 * 60 * 24 / 100000000;
            var x_changes_for_vector = coordinates.Item1 + vector.Item1;
            var y_changes_for_vector = coordinates.Item2 + vector.Item2;
            var distance_for_vector = Math.Pow((x_changes_for_vector - coordinates.Item1), 2) + Math.Pow((y_changes_for_vector - coordinates.Item2), 2);
            distance_for_vector = Math.Pow(distance_for_vector, 1 / 2);
            var changes_for_coordinates = oneDaydistancechanges / distance_for_vector;
            var changes_for_X = (x_changes_for_vector - coordinates.Item1) * changes_for_coordinates;
            var changes_for_Y = (y_changes_for_vector - coordinates.Item2) * changes_for_coordinates;
            return new Tuple<double, double>(changes_for_X, changes_for_Y);
        }
        public Tuple<double, double> ChangeCoordinatesOfPlanetSystemByOneDay(PlanetSystem planetSystem, SolarSystem solarSystem)
        {
            try
            {
                var oneDaydistancechanges = planetSystem.Speed * 60 * 60 * 24 / 1000000;
                var oneDayDegreeChanges = 180 / planetSystem.OrbitalPeriod;
                var angle = Math.PI * oneDayDegreeChanges / 180.0;
                var first_coord = (planetSystem.ELlipseParamA * Math.Cos(planetSystem.Angle += angle));
                var second_coord = (planetSystem.ELlipseParamB * Math.Sin(planetSystem.Angle += angle));
                planetSystem.Coordinates = new Tuple<double, double>(first_coord, second_coord);
                return planetSystem.Coordinates;
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public Tuple<double, double> ChangeCoordinatesOfSolarSystemByOneDay(SolarSystem solarSystem)
        {
            try
            {
                Tuple<double, double> tuple = CoordintesChanges(solarSystem.Coordinates, solarSystem.Vector, solarSystem.Speed);
                
                if (solarSystem.Vector.Item1 >= 0 && solarSystem.Vector.Item2 >= 0)
                {
                    state.SetState(new ToRightUp());
            
                }
                else if (solarSystem.Vector.Item1 >= 0 && solarSystem.Vector.Item2 <= 0)
                {
                    state.SetState(new ToLeftUp());

                }
                else if (solarSystem.Vector.Item1 <= 0 && solarSystem.Vector.Item2 >= 0)
                {
                    state.SetState(new ToRightDown());
         
                }
                else
                {
                    state.SetState(new ToLeftDown());
     
                }
                solarSystem.Coordinates = state.PerformeAction(solarSystem.Coordinates, tuple.Item1, tuple.Item2);
                return solarSystem.Coordinates;
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public Tuple<double, double> ChangeCoordinatesOfPlanetSystemByOneDayBefore(PlanetSystem planetSystem, SolarSystem solarSystem)
        {
            try
            {
                var oneDaydistancechanges = planetSystem.Speed * 60 * 60 * 24 / 1000000;
                var oneDayDegreeChanges = 180 / planetSystem.OrbitalPeriod;
                var angle = Math.PI * oneDayDegreeChanges / 180.0;
                var first_coord = (planetSystem.ELlipseParamA * Math.Cos(planetSystem.Angle -= angle));
                var second_coord = (planetSystem.ELlipseParamB * Math.Sin(planetSystem.Angle -= angle));
                planetSystem.Coordinates = new Tuple<double, double>(first_coord, second_coord);
                return planetSystem.Coordinates;
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
        public Tuple<double, double> ChangeCoordinatesOfSolarSystemByOneDayBefore(SolarSystem solarSystem)
        {
            try
            {
                Tuple<double, double> tuple = CoordintesChanges(solarSystem.Coordinates, solarSystem.Vector, solarSystem.Speed);
                if (solarSystem.Vector.Item1 >= 0 && solarSystem.Vector.Item2 >= 0)
                {
                    state.SetState(new ToLeftDown());
                }
                else if (solarSystem.Vector.Item1 >= 0 && solarSystem.Vector.Item2 <= 0)
                {
                    state.SetState(new ToRightDown());
 
                }
                else if (solarSystem.Vector.Item1 <= 0 && solarSystem.Vector.Item2 >= 0)
                {
                    state.SetState(new ToLeftUp());
                }
                else
                {
                    state.SetState(new ToRightUp());
                }
                solarSystem.Coordinates = state.PerformeAction(solarSystem.Coordinates, tuple.Item1, tuple.Item2);
                return solarSystem.Coordinates;
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
     }

    [TestFixture]
    public class TestCoordinatesTriger
    {
          [Test]
          public void ChangeCoordinatesOfPlanetSystemByOneDay()
          {
              CoordinatesTriger trg = new CoordinatesTriger();
              Galaxy g = new Galaxy();
              g.CreateNormalGalaxy();
            //One day changes
            PlanetSystem ps = g.SolarSystems.ToArray()[1].Planets.ToArray()[3];
            Tuple<double, double> result = trg.ChangeCoordinatesOfPlanetSystemByOneDay(ps, g.SolarSystems.ToArray()[1]);
            Assert.AreEqual(Math.Round(result.Item1, 3), Math.Round(249.19737775501,3));
            Assert.AreEqual(Math.Round(result.Item2, 3), Math.Round(1.8895, 3));
        }

        [Test]
        public void ChangeCoordinatesOfSolarSystemByOneDay()
        {
            CoordinatesTriger trg = new CoordinatesTriger();
            Galaxy g = new Galaxy();
            g.CreateNormalGalaxy();
            //One day changes
            SolarSystem ps = g.SolarSystems.ToArray()[1];
            Tuple<double, double> result = trg.ChangeCoordinatesOfSolarSystemByOneDay(g.SolarSystems.ToArray()[1]);
            Assert.AreEqual(Math.Round(result.Item1, 3), Math.Round(400.027648, 3));
            Assert.AreEqual(Math.Round(result.Item2, 3), Math.Round(-259.972352, 3));
            
        }
        [Test]
        public void ChangeCoordinatesOfPlanetSystemByOneDayBefore()
        {
            CoordinatesTriger trg = new CoordinatesTriger();
            Galaxy g = new Galaxy();
            g.CreateNormalGalaxy();
            //One day changes
            PlanetSystem ps = g.SolarSystems.ToArray()[1].Planets.ToArray()[3];
            Tuple<double, double> result = trg.ChangeCoordinatesOfPlanetSystemByOneDayBefore(ps, g.SolarSystems.ToArray()[1]);
            Assert.AreEqual(Math.Round(result.Item1, 3), Math.Round(249.19737775501, 3));
            Assert.AreEqual(Math.Round(result.Item2, 3), Math.Round(-1.8895, 3));
        }
        [Test]
        public void ChangeCoordinatesOfSolarSystemByOneDayBefore()
        {
            CoordinatesTriger trg = new CoordinatesTriger();
            Galaxy g = new Galaxy();
            g.CreateNormalGalaxy();
            //One day changes
            SolarSystem ps = g.SolarSystems.ToArray()[1];
            Tuple<double, double> result = trg.ChangeCoordinatesOfSolarSystemByOneDayBefore(g.SolarSystems.ToArray()[1]);
            Assert.AreEqual(Math.Round(result.Item1, 3), Math.Round(399.972352, 3));
            Assert.AreEqual(Math.Round(result.Item2, 3), Math.Round(-260.027648, 3));

        }


    }
}

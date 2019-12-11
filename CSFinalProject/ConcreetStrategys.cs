using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CSFinalProject
{
    class DataToTable
    {
        public static void AddRowsToDb(DataTable dt, IEnumerable<PlanetSystem> res)
        {
            foreach (var plan in res)
            {
                dt.Rows.Add(plan.Planet.Name, plan.Coordinates, plan.Planet.Mass, plan.Planet.Diametr, plan.ELlipseParamA,
                            plan.ELlipseParamB, plan.OrbitalPeriod, plan.Speed, plan.Months);
            }
        }
    }
    class NameStrategy : DataToTable, IStrategyPrint
    {
        public void AlgorithmInterface(DataTable dt,SolarSystem _solarSys)
        {
            try
            {
                var res = _solarSys.Planets.OrderBy(x => x.Planet.Name).Select(x => x);
                DataToTable.AddRowsToDb(dt, res);
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
    }

    class DistanceStrategy : DataToTable, IStrategyPrint

    {
        public void AlgorithmInterface(DataTable dt, SolarSystem _solarSys)
        {
            try
            {
                var res = _solarSys.Planets.OrderBy(x => Math.Pow(x.Coordinates.Item1, 2) + Math.Pow(x.Coordinates.Item2, 2))
                                               .Select(x => x);
                DataToTable.AddRowsToDb(dt, res);
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
    }

    class MoonsStrategy : DataToTable, IStrategyPrint

    {
        public void AlgorithmInterface(DataTable dt, SolarSystem _solarSys)
        {
            try
            {
                var res = _solarSys.Planets.OrderBy(x => x.Months).ThenBy(x => x.Planet.Name).Select(x => x);
                DataToTable.AddRowsToDb(dt, res);

            }
            catch(Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
    }
    class Context

    {
        private IStrategyPrint _strategy;

        // Constructor
        public Context(IStrategyPrint strategy)
        {
            this._strategy = strategy;
        }

        public void ContextInterface(DataTable dt, SolarSystem _solarSys)
        {
            try
            {
                _strategy.AlgorithmInterface(dt, _solarSys);
            }
            catch (Exception e)
            {
                throw new System.Exception($"Class {this.GetType().Name}, method {System.Reflection.MethodBase.GetCurrentMethod().Name}" + e.Message);

            }
        }
    }
}

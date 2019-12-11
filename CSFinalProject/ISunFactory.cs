using System;
using System.Collections.Generic;
using System.Text;

namespace CSFinalProject
{
    interface ISunFactory
    {
        Tuple<double, double> Coordinates { get; set; }
        // Tuple<Tuple<double, double>, Tuple<double, double>> Vector { get; set; }
        double Luminosity { get; set; }
        Sun GetNewNormalSun();
        Sun GetNewRedSun();
        Sun GetNewBlueSun();
    }
}

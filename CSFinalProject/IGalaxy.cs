using System;
using System.Collections.Generic;
using System.Text;

namespace CSFinalProject
{
    interface IGalaxy
    {
        Tuple<double, double> Coordinates { get; set; }
        Tuple<double, double> Vector { get; set; }
        double Speed { get; set; }





    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CSFinalProject
{
    interface IDateAndTime
    {
        DateTime AddYears(Galaxy galaxy, int year);
        DateTime AddMonths(Galaxy galaxy, int months);
        DateTime AddDays(Galaxy galaxy, int days);
        DateTime SubtractYears(Galaxy galaxy,int year);
        DateTime SubtractMonths(Galaxy galaxy,int months);
        DateTime SubtractDays(Galaxy galaxy,int days);
    }
}

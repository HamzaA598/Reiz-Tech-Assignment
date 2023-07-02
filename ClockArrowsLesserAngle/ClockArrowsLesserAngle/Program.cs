using System;

namespace MyApp 
{
    internal class Program
    {

        const double MINUTES_PER_HOUR = 60;
        const double HOURS_PER_CYCLE = 12;
        // there are 360 degrees around the center of the clock, degree 0 is the 12 clock mark
        const double DEGREES_PER_CYCLE = 360;

        const double MINUTES_ARROW_DEGREES_PER_MINUTE = DEGREES_PER_CYCLE / MINUTES_PER_HOUR;

        const double HOURS_ARROW_DEGREES_PER_HOUR = DEGREES_PER_CYCLE / HOURS_PER_CYCLE;
        // each minute moves the hours arrow by some degree denoted by the following constant
        const double HOURS_ARROW_DEGREES_PER_MINUTE = HOURS_ARROW_DEGREES_PER_HOUR / MINUTES_PER_HOUR;

        static void Main(string[] args)
        {
           
        }
    }
}
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

        public static double CalculateLesserAngle(int hours, int minutes)
        {
            double minutesArrowDegree = minutes * MINUTES_ARROW_DEGREES_PER_MINUTE;
            double hoursArrowDegree = hours * HOURS_ARROW_DEGREES_PER_HOUR + minutes * HOURS_ARROW_DEGREES_PER_MINUTE;

            double lesserAngle = hoursArrowDegree - minutesArrowDegree;
            if (lesserAngle < 0)
                lesserAngle += DEGREES_PER_CYCLE;
            lesserAngle = Math.Min(lesserAngle, DEGREES_PER_CYCLE - lesserAngle);

            return lesserAngle;
        }

        static void Main(string[] args)
        {
           
        }
    }
}
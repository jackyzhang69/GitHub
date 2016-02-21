using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Immigration.Utility
{
    class DateDiff
    {
        public static int age(DateTime dob)
        {

            DateTime zeroTime = new DateTime(1, 1, 1);

            TimeSpan span = DateTime.Today - dob;
            // because we start at year 1 for the Gregorian 
            // calendar, we must subtract a year here.
            return (zeroTime + span).Year - 1;

        }
    }
}

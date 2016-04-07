using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE
{
    public class Definition
    {
        public static Dictionary<string, int> singleEducationPoints = new Dictionary<string, int>
        {
            {"less than a secondary school credential",0},  //index 0
            {"secondary school credential",30},
            {"one-year post-secondary credential",90},
            {"two-year post-secondary credential",98},
            {"three-year+ post-secondary credential",120},
            {"2+ credentials & 1 being three years or more",128},
            {"master’s level",135},
            {"doctoral level",150},

        };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Immigration
{
    public static class GlobalData
    {
        public static int? CurrentPersonId;
        public static bool CurrentPersonIdReadOnly = false;
        public static int? CurrentEmployerId;
        public static bool CurrentEmployerIdReadOnly = false;
        public static int? CurrentCategoryId;
        public static bool CurrentCategoryReadOnly = false;
        public static int? CurrentStreamId;
        public static bool CurrentStreamIdReadOnly = false;
        public static int? CurrentApplicationId;
        public static bool CurrentApplicationReadOnly = false;

        public enum AppStream
        {

            LMIAPRSupportOnly = 1,
            LMIAPRandWP = 2,
            LMIAWPOnly = 3,
            BCPNPSW = 4,
            BCPNPEI = 5,
            BCPNPInternationalGraduate = 6
        }

    }
}

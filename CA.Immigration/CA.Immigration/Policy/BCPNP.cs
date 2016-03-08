using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Immigration.Policy
{
    
    // BCPNP Entreprenuer Immigration Policy
    public class BCPNP_EI_policy
    {

        // Score points policies about work experience
        public int[,] OwnerScorePolicy = new int[,] {
            // Months to months and points 
            {0,11,0},
            {12,24,4},
            {25,36,6},
            {37,48,12},
            {49,60,15},
            {61,120,20}
           };
        public int[,] SeniorManagerScorePolicy = new int[,] {
            // Months to months and points 
            {0,23,0},
            {24,48,4},
            {49,60,8},
            {61,120,12}
          };

        // Score points policies about assets
        public int[,] CurrentAssetPolicy = new int[,]
        {
            // current asset range and points, we setup the max is $1 billion
            {0,49999,0},
            {50000,199999,1},
            {200000,399999,3},
            {400000,1000000000,6}
            };

        public int[,] NetAssetPolicy = new int[,]
        {
            // Net asset rage and points, we setup the max is $1 billion
            {0,599999,0},
            {600000,799999,1},
            {800000, 1999999,3},
            {2000000,4999999,5},
            {5000000,1000000000,6}
          };

        // score points policy about eligible investment,  we setup the max is $1 billion
        public int[,] EligibleInvestPolicy = new int[,]
        {
            {0,199999,0},
            {200000,399999,6},
            {400000,999999,20},
            {1000000,1000000000,30}
         };

        // score points policy about job creation, we setup the max person is 10,000
        public int[,] JobCreationPolicy = new int[,]
            {
                // from to amount of persons, and points
               {0,0,0},
               {1,1,2},
               {2,2,6},
               {3,4,12},
               {5,6,20},
               {7,8,28},
               {9,10,32},
               {11,10000,36 }
            };



        public static int scoring(int[,] policy, int num)
        {


            for(int i = 0; i < policy.Length / 3; i++)
            {
                if(num >= policy[i, 0] && num <= policy[i, 1]) return policy[i, 2];

            }
            return -1;

        }


    }


    // BCPNP Skill Worker Policy: Version 160127

    public class BCPNP_SW_Policy
    {
        public static float lowestWage = 10.25f;
        // Top 100 NOC demaned in BC. Qualified applicant will get 10 bonus points
        public List<int> top100NOC = new List<int>(new int[] {
                                             0621,0121,0631,0711,0601,0122,0111,0013,0714,0712,
                                             0016,0213,0124,0112,0632,0731,0421,0211,1111,2171,
                                             4021,4011,2174,1114,2131,4112,2173,1122,1123,4012,
                                             4152,4163,4153,5121,1121,2133,2132,2175,2151,4165,
                                             4151,1221,1241,7271,1311,4212,6322,4214,1224,7241,
                                             6321,4311,6231,7294,5254,7311,2281,7237,6232,2242,
                                             6211,7312,7251,6332,7302,1222,1242,1225,7205,2241,
                                             2253,6222,7284,1312,4312,7231,9241,5242,7242,2263,
                                             7204,2264,7233,7371,7252,7282,7253,6421,7511,1411,
                                             1414,6513,7452,1431,6541,7521,7514,4411,7441,7513
                                            });

        // NOC to 0, A, B, C, D
        public string[,] NOC = new string[,]
        {
            { "0", "0"},// If the first number of NOC is 0, then the skill level is 0
            {"1","A" }, // if the 2nd number of NOC is 1, then the skill level is A
            {"2,3","B" },
            {"4,5","C" },
            {"6,7","D" }

        };


        // Skill level of BC Job offer. skill type char pairs with points 
        public Dictionary<char, int> jobLevel = new Dictionary<char, int> {
            { '0', 25 }, {'A',25}, {'B',10}, {'C',5}, {'D',5}
        };

        public int[,] wagePoints = new int[,]
        {
            { 100000 , 1000000,50 },
            { 97500 , 99999,38 },
            { 95000 , 97499,37 },
            { 92500 , 94999,36 },
            { 90000 , 92499,35 },
            { 87500 , 89999,34 },
            { 85000 , 87499,33 },
            { 82500 , 84999,32 },
            { 80000 , 82499,31 },
            { 77500 , 79999,30 },
            { 75000 , 77499,29 },
            { 72500 , 74999,28 },
            { 70000 , 72499,27 },
            { 67500 , 69999,26 },
            { 65000 , 67499,25 },
            { 62500 , 64999,24 },
            { 60000 , 62499,23 },
            { 57500 , 59999,22 },
            { 55000 , 57499,21 },
            { 52500 , 54999,20 },
            { 50000 , 52499,19 },
            { 47500 , 49999,18 },
            { 45000 , 47499,17 },
            { 42500 , 44999,16 },
            { 40000 , 42499,15 },
            { 38750 , 39999,14 },
            { 37500 , 38749,13 },
            { 36250 , 37499,12 },
            { 35000 , 36249,11 },
            { 33750 , 34999,10 },
            { 32500 , 33749,9 },
            { 31250 , 32499,8 },
            { 30000 , 31249,7 },
            { 28750 , 29999,6 },
            { 27500 , 28749,5 },
            { 26250 , 27499,4 },
            { 25000 , 26249,3 },
            { 0     , 25000,0 }
        };



        //Work experience points polciy. Max is setup as 100 years 
        public float[,] workExperiencePoints = new float[,]
        {
            { 5,100,15},
            { 4,5,12},
            { 3,4,9},
            { 2,3,6},
            { 1,2,3},
            {0.01f,1,1},
            {0,0,0 }
        };



        // Language points policy
        public Dictionary<int, int> CLBLevel = new Dictionary<int, int> {
            {12,30},{11,30},{ 10, 30 }, {9,26}, {8,22}, {7,18}, {6,14}, {5,10}, {4,6}, {3,0 }, {2,0 }, {1,0 }, {0,0}
        };

        // Education points policy
        public string[,] education = new string[,]
        {
            { "Doctoral or Master’s degree", "17" },
            {"Post Graduate Certificate or Diploma","11" },
            {"Bachelor’s degree","11" },
            {"Trades certification","11" },
            {"Associate Degree","4" },
            {"Non-trades certification or Diploma","2" },
            {"High School","0" }

        };
        // Education bonus points policy
        public string[,] eduBonus = new string[,]
        {
            {"  ","0" },
            {"Post-secondary education completed in B.C","8" },
            {"Post-secondary education completed in Canada (outside of B.C.)","6" },
            {"Education Credential Assessment from a qualified supplier","4" },
            {"Trades certification assessment from the Industry Training Authority","4" }

        };

        // Region points policy
        public string[,] region = new string[,]
        {
            {"Stikine","10" },
            {"Central Coast","10" },
            {"Northern Rockies","10" },
            {"Mount Waddington","10" },
            {"Skeena -Queen Charlotte","10" },
            {"Powell River","10" },
            {"Sunshine Coast","10" },
            {"Kootenay -Boundary","10" },
            {"Alberni - Clayoquot","10" },
            {"Kitimat-Stikine","8"},
            {"Bulkley -Nechako","8"},
            {"Squamish -Lillooet","8"},
            {"Strathcona","8"},
            {"Columbia - Shushwap","8"},
            {"East Kootenay","8"},
            {"Peace River","6"},
            {"Comox Valley","6"},
            {"Cariboo","6"},
            {"Central Kootenay","6"},
            {"Okanagan-Similkameen","4" },
            {"Cowichan Valley","4" },
            {"North Okanagan","4" },
            {"Fraser -Fort George","4"},
            {"Thompson-Nicola","2"},
            {"Nanaimo","2"},
            {"Central Okanagan","2"},
            {"Capital","2"},
            {"Fraser Valley","2"},
            {"Greater Vancouver","0"}

        };

        public struct Occupation
        {
            public string occupation;
            public int jobOpens;
            public float medianWage;
            public string noc;
            public char level;
        }

        // Top 100 NOC demaned in BC. Qualified applicant will get 10 bonus points
        public List<Occupation> top100NOC1 = new List<Occupation>
        {
            new Occupation() {occupation="Retail and wholesale trade managers",jobOpens=27400,medianWage=25.2000f,noc="0621",level='A'},
            new Occupation() {occupation="Insurance, real estate and financial brokerage managers",jobOpens=9400,medianWage=43.2700f,noc="0121",level='A'},
            new Occupation() {occupation="Restaurant and food service managers",jobOpens=7900,medianWage=18.5000f,noc="0631",level='A'},
            new Occupation() {occupation="Construction managers",jobOpens=7200,medianWage=39.0000f,noc="0711",level='A'},
            new Occupation() {occupation="Corporate sales managers",jobOpens=5100,medianWage=34.6200f,noc="0601",level='A'},
            new Occupation() {occupation="Banking, credit and other investment managers",jobOpens=4900,medianWage=39.4900f,noc="0122",level='A'},
            new Occupation() {occupation="Financial managers",jobOpens=4500,medianWage=36.0600f,noc="0111",level='A'},
            new Occupation() {occupation="Senior managers - financial, communications and other business services",jobOpens=4100,medianWage=48.0800f,noc="0013",level='A'},
            new Occupation() {occupation="Facility operation and maintenance managers",jobOpens=3900,medianWage=32.0000f,noc="0714",level='A'},
            new Occupation() {occupation="Home building and renovation managers",jobOpens=3600,medianWage=18.0600f,noc="0712",level='A'},
            new Occupation() {occupation="Senior managers - construction, transportation, production and utilities",jobOpens=3500,medianWage=39.1100f,noc="0016",level='A'},
            new Occupation() {occupation="Computer and information systems managers",jobOpens=3500,medianWage=45.1900f,noc="0213",level='A'},
            new Occupation() {occupation="Advertising, marketing and public relations managers",jobOpens=3300,medianWage=34.6200f,noc="0124",level='A'},
            new Occupation() {occupation="Human resources managers",jobOpens=2900,medianWage=43.2700f,noc="0112",level='A'},
            new Occupation() {occupation="Accommodation service managers",jobOpens=2800,medianWage=20.1900f,noc="0632",level='A'},
            new Occupation() {occupation="Managers in transportation",jobOpens=2300,medianWage=37.0000f,noc="0731",level='A'},
            new Occupation() {occupation="Administrators - post-secondary education and vocational training",jobOpens=2100,medianWage=36.6200f,noc="0421",level='A'},
            new Occupation() {occupation="Engineering managers",jobOpens=1200,medianWage=50.0000f,noc="0211",level='A'},
            new Occupation() {occupation="Financial auditors and accountants",jobOpens=11700,medianWage=28.8500f,noc="1111",level='A'},
            new Occupation() {occupation="Information systems analysts and consultants",jobOpens=7600,medianWage=34.6200f,noc="2171",level='A'},
            new Occupation() {occupation="College and other vocational instructors",jobOpens=7200,medianWage=33.4000f,noc="4021",level='A'},
            new Occupation() {occupation="University professors and lecturers",jobOpens=6600,medianWage=39.4200f,noc="4011",level='A'},
            new Occupation() {occupation="Computer programmers and interactive media developers",jobOpens=6200,medianWage=33.6500f,noc="2174",level='A'},
            new Occupation() {occupation="Other financial officers",jobOpens=5400,medianWage=32.9700f,noc="1114",level='A'},
            new Occupation() {occupation="Civil engineers",jobOpens=3700,medianWage=35.0000f,noc="2131",level='A'},
            new Occupation() {occupation="Lawyers and notaries",jobOpens=3500,medianWage=51.2000f,noc="4112",level='A'},
            new Occupation() {occupation="Software engineers and designers",jobOpens=3500,medianWage=39.4200f,noc="2173",level='A'},
            new Occupation() {occupation="Professional occupations in business management consulting",jobOpens=3400,medianWage=28.8500f,noc="1122",level='A'},
            new Occupation() {occupation="Professional occupations in advertising, marketing and public relations",jobOpens=3200,medianWage=25.0000f,noc="1123",level='A'},
            new Occupation() {occupation="Post-secondary teaching and research assistants",jobOpens=2800,medianWage=19.0000f,noc="4012",level='A'},
            new Occupation() {occupation="Social workers",jobOpens=2600,medianWage=31.0000f,noc="4152",level='A'},
            new Occupation() {occupation="Business development officers and marketing researchers and consultants",jobOpens=2400,medianWage=25.0000f,noc="4163",level='A'},
            new Occupation() {occupation="Family, marriage and other related counsellors",jobOpens=2300,medianWage=29.7200f,noc="4153",level='A'},
            new Occupation() {occupation="Authors and writers",jobOpens=2300,medianWage=27.8700f,noc="5121",level='A'},
            new Occupation() {occupation="Human resources professionals",jobOpens=2200,medianWage=33.0000f,noc="1121",level='A'},
            new Occupation() {occupation="Electrical and electronics engineers",jobOpens=2100,medianWage=40.0000f,noc="2133",level='A'},
            new Occupation() {occupation="Mechanical engineers",jobOpens=2000,medianWage=36.0000f,noc="2132",level='A'},
            new Occupation() {occupation="Web designers and developers",jobOpens=2000,medianWage=21.6300f,noc="2175",level='A'},
            new Occupation() {occupation="Architects",jobOpens=1800,medianWage=31.7300f,noc="2151",level='A'},
            new Occupation() {occupation="Health policy researchers, consultants and program officers",jobOpens=1500,medianWage=32.0000f,noc="4165",level='A'},
            new Occupation() {occupation="Psychologists",jobOpens=1300,medianWage=33.8600f,noc="4151",level='A'},
            new Occupation() {occupation="Administrative officers",jobOpens=19600,medianWage=21.0000f,noc="1221",level='B'},
            new Occupation() {occupation="Administrative assistants",jobOpens=16400,medianWage=20.4700f,noc="1241",level='B'},
            new Occupation() {occupation="Carpenters",jobOpens=11200,medianWage=23.5000f,noc="7271",level='B'},
            new Occupation() {occupation="Accounting technicians and bookkeepers",jobOpens=11000,medianWage=19.0000f,noc="1311",level='B'},
            new Occupation() {occupation="Social and community service workers",jobOpens=10800,medianWage=19.0000f,noc="4212",level='B'},
            new Occupation() {occupation="Cooks",jobOpens=10700,medianWage=12.1000f,noc="6322",level='B'},
            new Occupation() {occupation="Early childhood educators and assistants",jobOpens=8500,medianWage=16.0000f,noc="4214",level='B'},
            new Occupation() {occupation="Property administrators",jobOpens=6200,medianWage=20.0000f,noc="1224",level='B'},
            new Occupation() {occupation="Electricians (except industrial and power system)",jobOpens=5400,medianWage=27.0000f,noc="7241",level='B'},
            new Occupation() {occupation="Chefs",jobOpens=4300,medianWage=15.6000f,noc="6321",level='B'},
            new Occupation() {occupation="Police officers (except commissioned)",jobOpens=3800,medianWage=37.5000f,noc="4311",level='B'},
            new Occupation() {occupation="Insurance agents and brokers",jobOpens=3800,medianWage=21.6300f,noc="6231",level='B'},
            new Occupation() {occupation="Painters and decorators (except interior decorators)",jobOpens=3700,medianWage=18.0000f,noc="7294",level='B'},
            new Occupation() {occupation="Program leaders and instructors in recreation, sport and fitness",jobOpens=3500,medianWage=18.0000f,noc="5254",level='B'},
            new Occupation() {occupation="Construction millwrights and industrial mechanics",jobOpens=3400,medianWage=30.1400f,noc="7311",level='B'},
            new Occupation() {occupation="Computer network technicians",jobOpens=3400,medianWage=25.0000f,noc="2281",level='B'},
            new Occupation() {occupation="Welders and related machine operators",jobOpens=3300,medianWage=26.4000f,noc="7237",level='B'},
            new Occupation() {occupation="Real estate agents and salespersons",jobOpens=3300,medianWage=19.8400f,noc="6232",level='B'},
            new Occupation() {occupation="Electronic service technicians (household and business equipment)",jobOpens=3300,medianWage=25.0000f,noc="2242",level='B'},
            new Occupation() {occupation="Retail sales supervisors",jobOpens=3200,medianWage=18.0000f,noc="6211",level='B'},
            new Occupation() {occupation="Heavy-duty equipment mechanics",jobOpens=3100,medianWage=31.0000f,noc="7312",level='B'},
            new Occupation() {occupation="Plumbers",jobOpens=2800,medianWage=26.0000f,noc="7251",level='B'},
            new Occupation() {occupation="Bakers",jobOpens=2700,medianWage=12.5000f,noc="6332",level='B'},
            new Occupation() {occupation="Contractors and supervisors, heavy equipment operator crews",jobOpens=2700,medianWage=30.4500f,noc="7302",level='B'},
            new Occupation() {occupation="Executive assistants",jobOpens=2500,medianWage=26.3000f,noc="1222",level='B'},
            new Occupation() {occupation="Legal administrative assistants",jobOpens=2300,medianWage=23.2500f,noc="1242",level='B'},
            new Occupation() {occupation="Purchasing agents and officers",jobOpens=2200,medianWage=25.0000f,noc="1225",level='B'},
            new Occupation() {occupation="Contractors and supervisors, other construction trades, installers, repairers and servicers",jobOpens=2200,medianWage=32.0000f,noc="7205",level='B'},
            new Occupation() {occupation="Electrical and electronics engineering technologists and technicians",jobOpens=1900,medianWage=28.0000f,noc="2241",level='B'},
            new Occupation() {occupation="Drafting technologists and technicians",jobOpens=1900,medianWage=22.5000f,noc="2253",level='B'},
            new Occupation() {occupation="Retail and wholesale buyers",jobOpens=1900,medianWage=18.0000f,noc="6222",level='B'},
            new Occupation() {occupation="Plasterers, drywall installers and finishers and lathers",jobOpens=1900,medianWage=24.0000f,noc="7284",level='B'},
            new Occupation() {occupation="Insurance adjusters and claims examiners",jobOpens=1900,medianWage=26.0000f,noc="1312",level='B'},
            new Occupation() {occupation="Firefighters",jobOpens=1500,medianWage=35.0000f,noc="4312",level='B'},
            new Occupation() {occupation="Machinists and machining and tooling inspectors",jobOpens=1500,medianWage=31.2500f,noc="7231",level='B'},
            new Occupation() {occupation="Power engineers and power systems operators",jobOpens=1500,medianWage=27.0000f,noc="9241",level='B'},
            new Occupation() {occupation="Interior designers and interior decorators",jobOpens=1400,medianWage=22.0000f,noc="5242",level='B'},
            new Occupation() {occupation="Industrial electricians",jobOpens=1400,medianWage=36.0000f,noc="7242",level='B'},
            new Occupation() {occupation="Inspectors in public and environmental health and occupational health and safety",jobOpens=1300,medianWage=32.8600f,noc="2263",level='B'},
            new Occupation() {occupation="Contractors and supervisors, carpentry trades",jobOpens=1200,medianWage=30.0000f,noc="7204",level='B'},
            new Occupation() {occupation="Construction inspectors",jobOpens=1100,medianWage=36.0000f,noc="2264",level='B'},
            new Occupation() {occupation="Sheet metal workers",jobOpens=1000,medianWage=25.5000f,noc="7233",level='B'},
            new Occupation() {occupation="Crane operators",jobOpens=800,medianWage=31.0000f,noc="7371",level='B'},
            new Occupation() {occupation="Steamfitters, pipefitters and sprinkler system installers",jobOpens=700,medianWage=31.2000f,noc="7252",level='B'},
            new Occupation() {occupation="Concrete finishers",jobOpens=600,medianWage=26.0000f,noc="7282",level='B'},
            new Occupation() {occupation="Gas fitters",jobOpens=400,medianWage=27.2400f,noc="7253",level='B'},
            new Occupation() {occupation="Retail salespersons",jobOpens=33300,medianWage=12.0000f,noc="6421",level='C'},
            new Occupation() {occupation="Transport truck drivers",jobOpens=15500,medianWage=23.0000f,noc="7511",level='C'},
            new Occupation() {occupation="General office support workers",jobOpens=13200,medianWage=18.3100f,noc="1411",level='C'},
            new Occupation() {occupation="Receptionists",jobOpens=11200,medianWage=16.0000f,noc="1414",level='C'},
            new Occupation() {occupation="Food and beverage servers",jobOpens=7700,medianWage=11.0000f,noc="6513",level='C'},
            new Occupation() {occupation="Material handlers",jobOpens=7500,medianWage=17.0000f,noc="7452",level='C'},
            new Occupation() {occupation="Accounting and related clerks",jobOpens=6700,medianWage=20.0000f,noc="1431",level='C'},
            new Occupation() {occupation="Security guards and related security service occupations",jobOpens=5800,medianWage=14.9700f,noc="6541",level='C'},
            new Occupation() {occupation="Heavy equipment operators (except crane)",jobOpens=5000,medianWage=28.0000f,noc="7521",level='C'},
            new Occupation() {occupation="Delivery and courier service drivers",jobOpens=3700,medianWage=16.7000f,noc="7514",level='C'},
            new Occupation() {occupation="Home child care providers",jobOpens=3400,medianWage=10.5000f,noc="4411",level='C'},
            new Occupation() {occupation="Residential and commercial installers and servicers",jobOpens=2500,medianWage=19.0000f,noc="7441",level='C'},
            new Occupation() {occupation="Taxi and limousine drivers and chauffeurs",jobOpens=2400,medianWage=19.7700f,noc="7513",level='C'},


        };

    }
}

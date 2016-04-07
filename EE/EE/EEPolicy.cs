using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE
{
    public class Age
    {
        static Dictionary<int, int> singleAgePoints = new Dictionary<int, int>
        {
            {18,99},
            {19,105},
            {30,105},
            {31,99},
            {32,94},
            {33,88},
            {34,83},
            {35,77},
            {36,72},
            {37,66},
            {38,61},
            {39,55},
            {40,50},
            {41,39},
            {42,28},
            {43,17},
            {44 ,6}
        };
        static Dictionary<int, int> PAAgePoints = new Dictionary<int, int>
        {
            {18,90},
            {19,95},
            {30,95},
            {31,90},
            {32,85},
            {33,80},
            {34,75},
            {35,70},
            {36,65},
            {37,60},
            {38,55},
            {39,50},
            {40,45},
            {41,35},
            {42,25},
            {43,15},
            {44 ,5}
        };

        public static int getAgePoints(int age)
        {
            if(age <= 17 || age >= 45) return 0;
            if(age >= 21 && age <= 29) return 110;
            else return singleAgePoints[age];
        }

        public static int getPAAgePoints(int age)
        {
            if(age <= 17 || age >= 45) return 0;
            if(age >= 21 && age <= 29) return 100;
            else return PAAgePoints[age];
        }

    }
    public class Education
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

        static Dictionary<string, int> PAEducationPoints = new Dictionary<string, int>
        {
            {"less than a secondary school credential",0},
            {"secondary school credential",28},
            {"one-year post-secondary credential",84},
            {"two-year post-secondary credential",91},
            {"three-year+ post-secondary credential",112},
            {"2+ credentials & 1 being three years or more",119},
            {"master’s level",126},
            {"doctoral level",140}
        };
        static Dictionary<string, int> SPEducationPoints = new Dictionary<string, int>
        {
            {"less than a secondary school credential",0},
            {"secondary school credential",2},
            {"one-year post-secondary credential",6},
            {"two-year post-secondary credential",7},
            {"three-year+ post-secondary credential",8},
            {"2+ credentials & 1 being three years or more",9},
            {"master’s level ",9},
            {"doctoral level",10}

        };

        public bool oneEduMoreThanOneYear;
        public bool oneEduMoreThanThreeYear;
        public bool twoCredentialOneMoreThan3;
        public string edulevel { get; set; }

        public Education(string edu)
        {
            edulevel = edu;
            oneOrMoreYears(edulevel);
        }
        public static int getEducationPoints(string edulevel)
        {
            if(singleEducationPoints.ContainsKey(edulevel)) return singleEducationPoints[edulevel];
            else return 0;
        }
        public static int getPAEducationPoints(string edulevel)
        {
            if(PAEducationPoints.ContainsKey(edulevel)) return PAEducationPoints[edulevel];
            else return 0;
        }
        public static int getSPEducationPoints(string edulevel)
        {
            if(SPEducationPoints.ContainsKey(edulevel)) return SPEducationPoints[edulevel];
            else return 0;
        }
        public void oneOrMoreYears(string edulevel)
        {
            for(int i = 0; i < singleEducationPoints.Count; i++)
            {
                if(singleEducationPoints.ContainsKey(edulevel) && i >= 2) oneEduMoreThanOneYear = true;
                if(singleEducationPoints.ContainsKey(edulevel) && i >= 4) oneEduMoreThanThreeYear = true;
                if(singleEducationPoints.ContainsKey(edulevel) && i == 5) twoCredentialOneMoreThan3 = true;
            }
        }
    }
    public class Language
    {
        public static Dictionary<int, string> languageType = new Dictionary<int, string>
        {
            {1,"IELTS"}
        };
        public static Dictionary<int, string> secondLanguageType = new Dictionary<int, string>
        {
            {1,"TEF"}
        };
        static Dictionary<int, int> singleFirstLanguagePoints = new Dictionary<int, int>
        {
            {4,6},
            {5,6},
            {6,9},
            {7,17},
            {8,23},
            {9,31},
            {10,34},
            {11,34},
            {12,34}
        };
        static Dictionary<int, int> PAFirstLanguagePoints = new Dictionary<int, int>
        {
            {4,6},
            {5,6},
            {6,8},
            {7,16},
            {8,22},
            {9,29},
            {10,32},
            {11,32},
            {12,32}
        };
        static Dictionary<int, int> SPFirstLanguagePoints = new Dictionary<int, int>
        {
            {4,0},
            {5,1},
            {6,1},
            {7,3},
            {8,3},
            {9,5},
            {10,5},
            {11,5},
            {12,5}

        };

        static Dictionary<int, int> singleSecondLanguagePoints = new Dictionary<int, int>
        {
            {5,1},
            {6,1},
            {7,3},
            {8,3},
            {9,6},
            {10,6},
            {11,6},
            {12,6}
        };

        public static int getFirstLanguagePoints(int CLBlevel)
        {
            if(singleFirstLanguagePoints.ContainsKey(CLBlevel)) return singleFirstLanguagePoints[CLBlevel];
            else return 0;
        }
        public static int getPAFirstLanguagePoints(int CLBlevel)
        {
            if(singleFirstLanguagePoints.ContainsKey(CLBlevel)) return PAFirstLanguagePoints[CLBlevel];
            else return 0;
        }
        public static int getSPFirstLanguagePoints(int CLBlevel)
        {
            if(singleFirstLanguagePoints.ContainsKey(CLBlevel)) return SPFirstLanguagePoints[CLBlevel];
            else return 0;
        }

        public static int getSecondLanguagePoints(int CLBlevel)
        {
            if(singleSecondLanguagePoints.ContainsKey(CLBlevel)) return singleSecondLanguagePoints[CLBlevel];
            else return 0;
        }
    }
    public class CanadianWorkExperience
    {
        static Dictionary<int, int> canadianWorkExperiencePoints = new Dictionary<int, int>
        {
            { 1,40},
            { 2,53},
            { 3,64},
            { 4,72},
            { 5,80}
        };
        static Dictionary<int, int> PAcanadianWorkExperiencePoints = new Dictionary<int, int>
        {
            {1,35},
            {2,46},
            {3,56},
            {4,63},
            {5,70}
        };
        static Dictionary<int, int> SPcanadianWorkExperiencePoints = new Dictionary<int, int>
        {
            {1,5},
            {2,7},
            {3,8},
            {4,9},
            {5,10}
        };

        public static int getCanadianWorkExperiencePoints(int years)
        {
            if(canadianWorkExperiencePoints.ContainsKey(years)) return canadianWorkExperiencePoints[years];
            else if(years > 5) return 80;
            else return 0;
        }
        public static int getPACanadianWorkExperiencePoints(int years)
        {
            if(canadianWorkExperiencePoints.ContainsKey(years)) return PAcanadianWorkExperiencePoints[years];
            else if (years > 5) return 70;
            else return 0;
        }
        public static int getSPCanadianWorkExperiencePoints(int years)
        {
            if(canadianWorkExperiencePoints.ContainsKey(years)) return SPcanadianWorkExperiencePoints[years];
            else if(years > 5) return 10;
            else return 0;
        }

    }
    public class IELTS
    {
        public float Listening { get; set; }
        public float Speaking { get; set; }
        public float Reading { get; set; }
        public float Writing { get; set; }
        public IELTS(float l, float s, float r, float w)
        {
            Listening = l;
            Speaking = s;
            Reading = r;
            Writing = w;
        }
    }
    public class TEF
    {
        public int Listening { get; set; }
        public int Speaking { get; set; }
        public int Reading { get; set; }
        public int Writing { get; set; }
        public TEF(int r, int w, int l, int s)
        {
            Listening = l;
            Speaking = s;
            Reading = r;
            Writing = w;
        }
    }
    public class CLB
    {
        public static string[] TestType = new string[] { "No Test", "IELTS", "CELPIP-G 14", "CELPIP-G 13" };  // WILL do TEF LATER

        private static Dictionary<string, int> CELPIPG13 = new Dictionary<string, int>()
            {
                {"5H",10},
                {"5L",9},
                {"4H",8},
                {"4L",7},
                {"3H",6},
                {"3L",5},
                {"2H",4}
            };
        private static float[,] IELTSG = new float[,]
            {
                {10f, 8.0f,7.5f,8.5f,7.5f},
                {9f,7.0f,7.0f,8.0f,7.0f},
                {8f,6.5f,6.5f,7.5f,6.5f},
                {7f,6.0f,6.0f,6.0f,6.0f},
                {6f,5.0f,5.5f,5.5f,5.5f},
                {5f,4.0f,5.0f,5.0f,5.0f},
                {4f,3.5f,4.0f,4.5f,4.0f}
            };
        private static int[,] TEF = new int[,]  // Reading, Writing, Listening, Speaking
            {
                {10,263,277,393,415,316,333,393,415 },
                { 9,248,262, 371,392,298,315,371,392},
                { 8,233,247,349,370,280,297,349,370},
                { 7,207,232,310,348,249,279,310,348},
                { 6,181,206,271,309,217,248,271,309},
                { 5,151,180,226,270,181,216,226,270},
                { 4,121,150,181,225,145,180,181,225}
            };
        public static int TEFtoCLB(int input, int index)  //input one of 4 points of TEF
        {
            for(int i = 0; i < TEF.Length / 9; i++)
            {
                if(input >= TEF[i, index * 2 - 1] && input <= TEF[i, index * 2]) return TEF[i, 0];
            }
            return 0;
        }
        // four section sequence: Reading, Writing, Lisenting, Speaking

        //CLB <->CELPIP General, Version: After April 1, 2014
        public static int CELPIPGtoCLB(int reading, int writing, int listening, int speaking)
        {
            List<int> l = new List<int>() { reading, writing, listening, speaking };
            return l.Min();
        }
        public static List<int> CLBtoCELPIPG(int clb)
        {
            return new List<int>() { clb, clb, clb, clb };
        }

        // CLB<->CLIPIP General, Version: Before May 3, 2013
        public static int CELPIPG13toCLB(string reading, string writing, string listensing, string speaking)
        {
            List<string> scores = new List<string>() { reading, writing, listensing, speaking };

            int[] level = new int[4];


            for(int i = 0; i < 4; i++) // search for 4 string 
            {
                foreach(KeyValuePair<string, int> kvp in CELPIPG13) // in the dictionary
                {

                    if(kvp.Key == scores[i]) level[i] = kvp.Value;  // find the match and assign the level to array;
                }

            }

            return level.Min();
        }
        public static string CLBtoCELPIPG13(int clb)
        {

            string feedback = "";
            foreach(KeyValuePair<string, int> kvp in CELPIPG13)
            {
                if(kvp.Value == clb) feedback = kvp.Key;
            }

            return feedback;
        }
        //IELTS General to CLB
        public static int IELTSGtoCLB(float reading, float writing, float listening, float speaking)
        {
            int[] clb = new int[IELTSG.Length / 5];
            for(int i = 0; i < IELTSG.Length / 5; i++)
            {
                if(reading >= IELTSG[i, 1] && writing >= IELTSG[i, 2] && listening >= IELTSG[i, 3] && speaking >= IELTSG[i, 4]) clb[i] = (int)IELTSG[i, 0];

            }
            return clb.Max();
        }
        //IELTS 4 Factors to CLB ; input can be reading, writing, listening, speaking score. factor is index, 1: reading, 2:writing 3:listening 4:speaking
        //static enum clbLanuage
        //{
        //    CLB=0,
        //    Reading=1,
        //    Writing=2,
        //    Listening=3,
        //    Speaking=4
        //};
        public static int IELTSGto4CLB(float input, int factor)
        {
            int clb = 0;
            //Reading is in index 0
            for(int i = 0; i < IELTSG.Length / 5; i++)
            {
                if(input >= IELTSG[i, factor]) return clb = (int)IELTSG[i, 0];

            }
            return clb;
        }

        public static bool isOneIELTSGThanCLBN(float reading, float writing, float listening, float speaking, int n)
        {
            int[] clb = new int[IELTSG.Length / 5];
            bool result = false;
            //check Reading
            for(int i = 0; i < IELTSG.Length / 5; i++)
            {
                if(reading >= IELTSG[i, 1]) clb[i] = (int)IELTSG[i, 0];

            }
            if(clb.Max() >= n) result = true; ;
            //check writing
            for(int i = 0; i < IELTSG.Length / 5; i++)
            {
                if(writing >= IELTSG[i, 2]) clb[i] = (int)IELTSG[i, 0];

            }
            if(clb.Max() >= n) result = true;
            //check listening
            for(int i = 0; i < IELTSG.Length / 5; i++)
            {
                if(listening >= IELTSG[i, 3]) clb[i] = (int)IELTSG[i, 0];

            }
            if(clb.Max() >= n) result = true;
            //check speaking
            for(int i = 0; i < IELTSG.Length / 5; i++)
            {
                if(speaking >= IELTSG[i, 4]) clb[i] = (int)IELTSG[i, 0];

            }
            if(clb.Max() >= n) result = true;
            return result;

        }


        public static List<float> CLBtoIELTSG(int clb)
        {

            List<float> feedback = new List<float>();
            if(clb > 10) clb = 10;
            if(clb >= 4)
            {
                for(int i = 0; i < IELTSG.Length / 5; i++)
                {
                    if((int)IELTSG[i, 0] == clb)
                    {
                        return new List<float> { IELTSG[i, 1], IELTSG[i, 2], IELTSG[i, 3], IELTSG[i, 4] };
                    }

                }
            }
            else feedback = new List<float> { 0f, 0f, 0f, 0f };
            return feedback;
        }
    }
    public class Person
    {
        public bool married { get; set; }
        public string applicant { get; set; }
        public int age { get; set; }
        public Education education { get; set; }
        public IELTS ielts { get; set; }
        public TEF tef { get; set; }
        public int firstLanguageOverAll { get; set; }
        public int firstLanguageReadingPoints { get; set; }
        public int firstLanguageWritingPoints { get; set; }
        public int firstLanguageListeningPoints { get; set; }
        public int firstLanguageSpeakingPoints { get; set; }
        public int secondLanguageReadingPoints { get; set; }
        public int secondLanguageWritingPoints { get; set; }
        public int secondLanguageListeningPoints { get; set; }
        public int secondLanguageSpeakingPoints { get; set; }
        public bool isOneOverCLB9 { get; set; }
        public int canadianWorkExperience { get; set; }
        public int foreignWorkExperience { get; set; }
        public int numOfCredential { get; set; }
        public bool CofQ { get; set; }

        public int agePoints { get; set; }
        public int educationPoints { get; set; }
        public int firstLanguagePoints { get; set; }
        public int secondLanguagePoints { get; set; }
        public int canadianWorkExperiencePoints { get; set; }

        public int educationAndLanguagePoints { get; set; }
        public int educationAndCanadaWorkExperiencePoints { get; set; }
        public int languageAndForeignWorkExperiencePoints { get; set; }
        public int canadaWorkExperienceAndForeignWorkExperiencePoints { get; set; }
        public int CofQAndLauangePoints { get; set; }

        public int totalPoints { get; set; }


        public void calculate(int who) // 0 is single 1 is PA 2 is SP
        {
            int CFWEP = 0;
            int EduLangCaWE = 0;

            if(who == 0)  //single
            {
                //1. Age
                agePoints = Age.getAgePoints(age);
                //2. Education
                educationPoints = Education.getEducationPoints(education.edulevel);
                //3. Language
                //3.1 First language                                                                                 if
                if(ielts != null)
                {
                    firstLanguageOverAll = CLB.IELTSGtoCLB(ielts.Reading, ielts.Writing, ielts.Listening, ielts.Speaking);
                    firstLanguageReadingPoints = Language.getFirstLanguagePoints(CLB.IELTSGto4CLB(ielts.Reading, 1));
                    firstLanguageWritingPoints = Language.getFirstLanguagePoints(CLB.IELTSGto4CLB(ielts.Writing, 2));
                    firstLanguageListeningPoints = Language.getFirstLanguagePoints(CLB.IELTSGto4CLB(ielts.Listening, 3));
                    firstLanguageSpeakingPoints = Language.getFirstLanguagePoints(CLB.IELTSGto4CLB(ielts.Speaking, 4));
                    firstLanguagePoints = firstLanguageReadingPoints + firstLanguageWritingPoints + firstLanguageListeningPoints + firstLanguageSpeakingPoints;
                    isOneOverCLB9 = CLB.isOneIELTSGThanCLBN(ielts.Reading, ielts.Writing, ielts.Listening, ielts.Speaking, 9);
                }

                canadianWorkExperiencePoints = CanadianWorkExperience.getCanadianWorkExperiencePoints(canadianWorkExperience);
            }
            else if(who == 1)
            {
                agePoints = Age.getPAAgePoints(age);
                //2. Education
                educationPoints = Education.getPAEducationPoints(education.edulevel); // First and the highest 
                //3. Language
                //3.1 First language
                if(ielts != null)
                {
                    firstLanguageOverAll = CLB.IELTSGtoCLB(ielts.Reading, ielts.Writing, ielts.Listening, ielts.Speaking);
                    firstLanguageReadingPoints = Language.getPAFirstLanguagePoints(CLB.IELTSGto4CLB(ielts.Reading, 1));
                    firstLanguageWritingPoints = Language.getPAFirstLanguagePoints(CLB.IELTSGto4CLB(ielts.Writing, 2));
                    firstLanguageListeningPoints = Language.getPAFirstLanguagePoints(CLB.IELTSGto4CLB(ielts.Listening, 3));
                    firstLanguageSpeakingPoints = Language.getPAFirstLanguagePoints(CLB.IELTSGto4CLB(ielts.Speaking, 4));
                    firstLanguagePoints = firstLanguageReadingPoints + firstLanguageWritingPoints +
                                          firstLanguageListeningPoints + firstLanguageSpeakingPoints;
                    isOneOverCLB9 = CLB.isOneIELTSGThanCLBN(ielts.Reading, ielts.Writing, ielts.Listening, ielts.Speaking, 9);
                }


                //3.2 Second Language
                if(tef != null)
                {
                    secondLanguageReadingPoints = Language.getSecondLanguagePoints(CLB.TEFtoCLB(tef.Reading, 1));
                    secondLanguageWritingPoints = Language.getSecondLanguagePoints(CLB.TEFtoCLB(tef.Writing, 2));
                    secondLanguageListeningPoints = Language.getSecondLanguagePoints(CLB.TEFtoCLB(tef.Listening, 3));
                    secondLanguageSpeakingPoints = Language.getSecondLanguagePoints(CLB.TEFtoCLB(tef.Speaking, 4));
                    secondLanguagePoints = secondLanguageReadingPoints + secondLanguageWritingPoints +
                                           secondLanguageListeningPoints + secondLanguageSpeakingPoints;
                    secondLanguagePoints = secondLanguagePoints >= 22 ? 22 : secondLanguagePoints; //Max is 22 
                }

                // Canada work experience points
                canadianWorkExperiencePoints =
                    CanadianWorkExperience.getPACanadianWorkExperiencePoints(canadianWorkExperience);
            }
            else if(who == 2)
            {
                educationPoints = Education.getSPEducationPoints(education.edulevel); // First and the highest 
                                                                                      //3. Language
                if(ielts != null)
                {
                    firstLanguageOverAll = CLB.IELTSGtoCLB(ielts.Reading, ielts.Writing, ielts.Listening, ielts.Speaking);
                    firstLanguageReadingPoints = Language.getSPFirstLanguagePoints(CLB.IELTSGto4CLB(ielts.Reading, 1));
                    firstLanguageWritingPoints = Language.getSPFirstLanguagePoints(CLB.IELTSGto4CLB(ielts.Writing, 2));
                    firstLanguageListeningPoints = Language.getSPFirstLanguagePoints(CLB.IELTSGto4CLB(ielts.Listening, 3));
                    firstLanguageSpeakingPoints = Language.getSPFirstLanguagePoints(CLB.IELTSGto4CLB(ielts.Speaking, 4));
                    firstLanguagePoints = firstLanguageReadingPoints + firstLanguageWritingPoints + firstLanguageListeningPoints + firstLanguageSpeakingPoints;
                }                                                                         //3.1 First language

                canadianWorkExperiencePoints = CanadianWorkExperience.getSPCanadianWorkExperiencePoints(canadianWorkExperience);
            }

            if(who != 2)
            {
                // transferability points
                //if(education.years >= 1) oneEduMoreThanOneYear = true;
                //if(education.years >= 3) oneEduMoreThanThreeYear = true;
                //1. education and language
                educationAndLanguagePoints = getEduLang();
                //2. Edu and Canada work experience
                educationAndCanadaWorkExperiencePoints = getEduCanadaWE();
                //1+2 maxium is 50
                EduLangCaWE = (educationAndLanguagePoints + educationAndCanadaWorkExperiencePoints) >= 50 ? 50 : educationAndLanguagePoints + educationAndCanadaWorkExperiencePoints;

                //3. Language and foreign work experience
                languageAndForeignWorkExperiencePoints = getLangFWE();
                //4. Canada work experience and foreign work experience
                canadaWorkExperienceAndForeignWorkExperiencePoints = getCFWE();
                CFWEP = (languageAndForeignWorkExperiencePoints + canadaWorkExperienceAndForeignWorkExperiencePoints) >= 50 ? 50 : languageAndForeignWorkExperiencePoints + canadaWorkExperienceAndForeignWorkExperiencePoints;
                //5. Get CofQ Language points
                CofQAndLauangePoints = getCofQPoints();
            }
            //Total points
            totalPoints = agePoints + educationPoints + firstLanguagePoints + secondLanguagePoints + canadianWorkExperiencePoints + EduLangCaWE + CFWEP + CofQAndLauangePoints;
        }
        private int getEduLang()
        {
            int score = 0;
            if(education.oneEduMoreThanOneYear && firstLanguageOverAll >= 7 && isOneOverCLB9) score = 13;
            if(education.oneEduMoreThanOneYear && firstLanguageOverAll >= 9) score = 25;
            if(education.twoCredentialOneMoreThan3 && firstLanguageOverAll >= 7 && isOneOverCLB9) score = 25;
            if(education.twoCredentialOneMoreThan3 && firstLanguageOverAll >= 9) score = 50;

            return score;

        }
        private int getEduCanadaWE()
        {
            int score = 0;
            if(education.oneEduMoreThanOneYear && canadianWorkExperience >= 1) score = 13;
            if(education.oneEduMoreThanOneYear && canadianWorkExperience >= 2) score = 25;
            if(education.twoCredentialOneMoreThan3 && canadianWorkExperience >= 1) score = 25;
            if(education.twoCredentialOneMoreThan3 && canadianWorkExperience >= 2) score = 50;

            return score;
        }
        private int getLangFWE()
        {
            int score = 0;
            if(foreignWorkExperience >= 1 && foreignWorkExperience <= 2 && firstLanguageOverAll >= 7) score = 13;
            if(foreignWorkExperience >= 1 && foreignWorkExperience <= 2 && firstLanguageOverAll >= 9) score = 25;
            if(foreignWorkExperience >= 3 && firstLanguageOverAll >= 7 && isOneOverCLB9) score = 25;
            if(foreignWorkExperience >= 3 && firstLanguageOverAll >= 9) score = 50;
            return score;
        }
        private int getCFWE()
        {
            int score = 0;
            if(foreignWorkExperience >= 1 && foreignWorkExperience <= 2 && canadianWorkExperience >= 1) score = 13;
            if(foreignWorkExperience >= 1 && foreignWorkExperience <= 2 && canadianWorkExperience >= 2) score = 25;
            if(foreignWorkExperience >= 3 && canadianWorkExperience >= 1) score = 25;
            if(foreignWorkExperience >= 3 && canadianWorkExperience >= 2) score = 50;
            return score;
        }
        private int getCofQPoints()
        {
            int score = 0;
            if(CofQ && firstLanguageOverAll >= 5) score = 25;
            if(CofQ && firstLanguageOverAll >= 7) score = 50;
            return score;
        }
    }

}

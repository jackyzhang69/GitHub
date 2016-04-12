using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE
{
    public class Age
    {
        public int _age;
        public Age(int age)
        {
            _age = age;
        }
        public int getAgePoints()
        {
            if (_age <= 17 || _age >= 45) return 0;
            if (_age >= 21 && _age <= 29) return 110;
            else return PolicyData.singleAgePoints[_age];
        }

        public int getPAAgePoints()
        {
            if (_age <= 17 || _age >= 45) return 0;
            if (_age >= 21 && _age <= 29) return 100;
            else return PolicyData.PAAgePoints[_age];
        }

    }
    public class Education
    {
        public bool oneEduMoreThanOneYear = false;
        public bool oneEduMoreThanThreeYear = false;
        public bool twoCredentialOneMoreThan3 = false;
        public string edulevel { get; set; }

        public Education(string edu)
        {
            edulevel = edu;
            oneOrMoreYears();
        }
        public int getEducationPoints()
        {
            if (PolicyData.singleEducationPoints.ContainsKey(edulevel)) return PolicyData.singleEducationPoints[edulevel];
            else return 0;
        }
        public int getPAEducationPoints()
        {
            if (PolicyData.PAEducationPoints.ContainsKey(edulevel)) return PolicyData.PAEducationPoints[edulevel];
            else return 0;
        }
        public int getSPEducationPoints()
        {
            if (PolicyData.SPEducationPoints.ContainsKey(edulevel)) return PolicyData.SPEducationPoints[edulevel];
            else return 0;
        }
        public void oneOrMoreYears()
        {

            List<string> temp = PolicyData.singleEducationPoints.Keys.ToList();
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i] == edulevel && i >= 2) oneEduMoreThanOneYear = true;
                if (temp[i] == edulevel && i >= 4) oneEduMoreThanThreeYear = true;
                if (temp[i] == edulevel && i >= 5) twoCredentialOneMoreThan3 = true;
            }
        }
    }
    public class Language
    {
        private int _CLBlevel { get; set; }
        public Language(int CLBLevel)
        {
            _CLBlevel = CLBLevel;
        }

        public int getFirstLanguagePoints()
        {
            if (PolicyData.singleFirstLanguagePoints.ContainsKey(_CLBlevel)) return PolicyData.singleFirstLanguagePoints[_CLBlevel];
            else return 0;
        }
        public int getPAFirstLanguagePoints()
        {
            if (PolicyData.singleFirstLanguagePoints.ContainsKey(_CLBlevel)) return PolicyData.PAFirstLanguagePoints[_CLBlevel];
            else return 0;
        }
        public int getSPFirstLanguagePoints()
        {
            if (PolicyData.singleFirstLanguagePoints.ContainsKey(_CLBlevel)) return PolicyData.SPFirstLanguagePoints[_CLBlevel];
            else return 0;
        }

        public int getSecondLanguagePoints()
        {
            if (PolicyData.SecondLanguagePoints.ContainsKey(_CLBlevel)) return PolicyData.SecondLanguagePoints[_CLBlevel];
            else return 0;
        }
    }
    public class CanadaWorkExperience
    {
        public int _years;
        public CanadaWorkExperience(int years)
        {
            _years = years;
        }
        public int getCanadaWorkExperiencePoints()
        {
            if (PolicyData.canadianWorkExperiencePoints.ContainsKey(_years)) return PolicyData.canadianWorkExperiencePoints[_years];
            else if (_years > 5) return 80;
            else return 0;
        }
        public int getPACanadaWorkExperiencePoints()
        {
            if (PolicyData.canadianWorkExperiencePoints.ContainsKey(_years)) return PolicyData.PAcanadianWorkExperiencePoints[_years];
            else if (_years > 5) return 70;
            else return 0;
        }
        public int getSPCanadaWorkExperiencePoints()
        {
            if (PolicyData.canadianWorkExperiencePoints.ContainsKey(_years)) return PolicyData.SPcanadianWorkExperiencePoints[_years];
            else if (_years > 5) return 10;
            else return 0;
        }

    }

    public class Person
    {
        //Factors
        public string applicantName { get; set; }
        public bool single { get; set; }
        public Age age { get; set; }
        public Education education { get; set; }
        public CELPIP celpip { get; set; }
        public IELTS ielts { get; set; }
        public bool isOneOverCLB9 { get; set; }
        public bool isSecondLanguage { get; set; }
        public TEF tef { get; set; }
        public CanadaWorkExperience caWE { get; set; }
        public int foreignWorkExperience { get; set; }
        public bool CofQ { get; set; }

        // Points 
        public int agePoints { get; set; }
        public int educationPoints { get; set; }
        //First laguage points
        public int firstLanguageOverAll { get; set; } // General first language CLB level
        public int firstLanguagePoints { get; set; }
        public int firstLanguageReadingPoints { get; set; }
        public int firstLanguageWritingPoints { get; set; }
        public int firstLanguageListeningPoints { get; set; }
        public int firstLanguageSpeakingPoints { get; set; }

        //Second language points
        public int secondLanguageOverAll { get; set; } // General second language CLB level
        public int secondLanguagePoints { get; set; }
        public int secondLanguageReadingPoints { get; set; }
        public int secondLanguageWritingPoints { get; set; }
        public int secondLanguageListeningPoints { get; set; }
        public int secondLanguageSpeakingPoints { get; set; }

        // Canadian work experience points
        public int canadianWorkExperiencePoints { get; set; }
        //public int numOfCredential { get; set; }

        // Transferability combination points
        public int educationAndLanguagePoints { get; set; }
        public int educationAndCanadaWorkExperiencePoints { get; set; }
        public int languageAndForeignWorkExperiencePoints { get; set; }
        public int canadaWorkExperienceAndForeignWorkExperiencePoints { get; set; }
        public int CofQAndLauangePoints { get; set; }

        public int totalPoints { get; set; }



    }
    public class Calculation
    {
        public static void calculate(Person person)
        {
            int CFWEP = 0;
            int EduLangCaWE = 0;

            //1. Age
            person.agePoints = person.age.getAgePoints();
            //2. Education
            person.educationPoints = person.education.getEducationPoints();
            //3. Language
            //3.1 First language                                                                                
            if (person.ielts != null)
            {
                person.firstLanguageOverAll = person.ielts.ToCLB();
                person.firstLanguageReadingPoints = new Language(person.ielts.ToCLB(1)).getFirstLanguagePoints();
                person.firstLanguageWritingPoints = new Language(person.ielts.ToCLB(2)).getFirstLanguagePoints();
                person.firstLanguageListeningPoints = new Language(person.ielts.ToCLB(3)).getFirstLanguagePoints();
                person.firstLanguageSpeakingPoints = new Language(person.ielts.ToCLB(4)).getFirstLanguagePoints();
                person.isOneOverCLB9 = person.ielts.isOneIELTSGThanCLBN(9);
            }
            if (person.celpip != null)
            {
                person.firstLanguageOverAll = person.celpip.ToCLB();
                person.firstLanguageReadingPoints = new Language(person.celpip.ToCLB(person.celpip._Reading)).getFirstLanguagePoints();
                person.firstLanguageWritingPoints = new Language(person.celpip.ToCLB(person.celpip._Writing)).getFirstLanguagePoints();
                person.firstLanguageListeningPoints = new Language(person.celpip.ToCLB(person.celpip._Listening)).getFirstLanguagePoints();
                person.firstLanguageSpeakingPoints = new Language(person.celpip.ToCLB(person.celpip._Speaking)).getFirstLanguagePoints();
                person.isOneOverCLB9 = person.celpip.isOneIELTSGThanCLBN(9);
            }
            person.firstLanguagePoints = person.firstLanguageReadingPoints + person.firstLanguageWritingPoints + person.firstLanguageListeningPoints + person.firstLanguageSpeakingPoints;
            person.canadianWorkExperiencePoints = person.caWE.getCanadaWorkExperiencePoints();

            //3.2 Second Language
            if (person.isSecondLanguage)
            {
                person.secondLanguageReadingPoints = new Language(person.tef.ToCLB(1)).getSecondLanguagePoints();
                person.secondLanguageWritingPoints = new Language(person.tef.ToCLB(2)).getSecondLanguagePoints();
                person.secondLanguageListeningPoints = new Language(person.tef.ToCLB(3)).getSecondLanguagePoints();
                person.secondLanguageSpeakingPoints = new Language(person.tef.ToCLB(4)).getSecondLanguagePoints();
                person.secondLanguagePoints = person.secondLanguageReadingPoints + person.secondLanguageWritingPoints +
                                       person.secondLanguageListeningPoints + person.secondLanguageSpeakingPoints;
                person.secondLanguageOverAll = person.tef.ToCLB();
            }
            // transferability points
            //if(education.years >= 1) oneEduMoreThanOneYear = true;
            //if(education.years >= 3) oneEduMoreThanThreeYear = true;
            //1. education and language
            person.educationAndLanguagePoints = getEduLang(person);
            //2. Edu and Canada work experience
            person.educationAndCanadaWorkExperiencePoints = getEduCanadaWE(person);
            //1+2 maxium is 50
            EduLangCaWE = (person.educationAndLanguagePoints + person.educationAndCanadaWorkExperiencePoints) >= 50 ? 50 : person.educationAndLanguagePoints + person.educationAndCanadaWorkExperiencePoints;

            //3. Language and foreign work experience
            person.languageAndForeignWorkExperiencePoints = getLangFWE(person);
            //4. Canada work experience and foreign work experience
            person.canadaWorkExperienceAndForeignWorkExperiencePoints = getCFWE(person);
            CFWEP = (person.languageAndForeignWorkExperiencePoints + person.canadaWorkExperienceAndForeignWorkExperiencePoints) >= 50 ? 50 : person.languageAndForeignWorkExperiencePoints + person.canadaWorkExperienceAndForeignWorkExperiencePoints;
            //5. Get CofQ Language points
            person.CofQAndLauangePoints = getCofQPoints(person);
            //Total points
            if (!person.isSecondLanguage) person.secondLanguagePoints = 0;
            person.totalPoints = person.agePoints + person.educationPoints + person.firstLanguagePoints + person.secondLanguagePoints + person.canadianWorkExperiencePoints + EduLangCaWE + CFWEP + person.CofQAndLauangePoints;
        }
        public static void calculate(Person pa, Person sp)
        {
            int CFWEP = 0;
            int EduLangCaWE = 0;
            pa.agePoints = pa.age.getPAAgePoints();
            pa.educationPoints = pa.education.getPAEducationPoints();
            if (pa.ielts != null)
            {
                pa.firstLanguageOverAll = pa.ielts.ToCLB();
                pa.firstLanguageReadingPoints = new Language(pa.ielts.ToCLB(1)).getPAFirstLanguagePoints();
                pa.firstLanguageWritingPoints = new Language(pa.ielts.ToCLB(2)).getPAFirstLanguagePoints();
                pa.firstLanguageListeningPoints = new Language(pa.ielts.ToCLB(3)).getPAFirstLanguagePoints();
                pa.firstLanguageSpeakingPoints = new Language(pa.ielts.ToCLB(4)).getPAFirstLanguagePoints();
                pa.isOneOverCLB9 = pa.ielts.isOneIELTSGThanCLBN(9);
            }
            if (pa.celpip != null)
            {
                pa.firstLanguageOverAll = pa.celpip.ToCLB();
                pa.firstLanguageReadingPoints = new Language(pa.celpip.ToCLB(pa.celpip._Reading)).getFirstLanguagePoints();
                pa.firstLanguageWritingPoints = new Language(pa.celpip.ToCLB(pa.celpip._Writing)).getFirstLanguagePoints();
                pa.firstLanguageListeningPoints = new Language(pa.celpip.ToCLB(pa.celpip._Listening)).getFirstLanguagePoints();
                pa.firstLanguageSpeakingPoints = new Language(pa.celpip.ToCLB(pa.celpip._Speaking)).getFirstLanguagePoints();
                pa.isOneOverCLB9 = pa.celpip.isOneIELTSGThanCLBN(9);
            }
            pa.firstLanguagePoints = pa.firstLanguageReadingPoints + pa.firstLanguageWritingPoints +
                                          pa.firstLanguageListeningPoints + pa.firstLanguageSpeakingPoints;
            // Canada work experience points
            pa.canadianWorkExperiencePoints = pa.caWE.getPACanadaWorkExperiencePoints();

            // Spouse attribution
            sp.educationPoints = sp.education.getSPEducationPoints(); // First and the highest 
            if (sp.ielts != null)
            {
                sp.firstLanguageOverAll = sp.ielts.ToCLB();
                sp.firstLanguageReadingPoints = new Language(sp.ielts.ToCLB(1)).getSPFirstLanguagePoints();
                sp.firstLanguageWritingPoints = new Language(sp.ielts.ToCLB(2)).getSPFirstLanguagePoints();
                sp.firstLanguageListeningPoints = new Language(sp.ielts.ToCLB(3)).getSPFirstLanguagePoints();
                sp.firstLanguageSpeakingPoints = new Language(sp.ielts.ToCLB(4)).getSPFirstLanguagePoints();
                
            }
            if (sp.celpip != null)
            {
                sp.firstLanguageOverAll = sp.celpip.ToCLB();
                sp.firstLanguageReadingPoints = new Language(sp.celpip.ToCLB(sp.celpip._Reading)).getSPFirstLanguagePoints();
                sp.firstLanguageWritingPoints = new Language(sp.celpip.ToCLB(sp.celpip._Writing)).getSPFirstLanguagePoints();
                sp.firstLanguageListeningPoints = new Language(sp.celpip.ToCLB(sp.celpip._Listening)).getSPFirstLanguagePoints();
                sp.firstLanguageSpeakingPoints = new Language(sp.celpip.ToCLB(sp.celpip._Speaking)).getSPFirstLanguagePoints();
            }
                sp.firstLanguagePoints = sp.firstLanguageReadingPoints + sp.firstLanguageWritingPoints + sp.firstLanguageListeningPoints + sp.firstLanguageSpeakingPoints;
            //3.1 First language

            sp.canadianWorkExperiencePoints = sp.caWE.getSPCanadaWorkExperiencePoints();

                //3.2 Second Language
                if (pa.isSecondLanguage)
                {
                pa.secondLanguageReadingPoints = new Language(pa.tef.ToCLB(1)).getSecondLanguagePoints();
                pa.secondLanguageWritingPoints = new Language(pa.tef.ToCLB(2)).getSecondLanguagePoints();
                pa.secondLanguageListeningPoints = new Language(pa.tef.ToCLB(3)).getSecondLanguagePoints();
                pa.secondLanguageSpeakingPoints = new Language(pa.tef.ToCLB(4)).getSecondLanguagePoints();
                pa.secondLanguagePoints = pa.secondLanguageReadingPoints + pa.secondLanguageWritingPoints +
                                           pa.secondLanguageListeningPoints + pa.secondLanguageSpeakingPoints;
                pa.secondLanguagePoints = pa.secondLanguagePoints >= 22 ? 22 : pa.secondLanguagePoints; //Max is 22 
                pa.secondLanguageOverAll = pa.tef.ToCLB();
                }
            // transferability points
   
            //1. education and language
            pa.educationAndLanguagePoints = getEduLang(pa);
            //2. Edu and Canada work experience
            pa.educationAndCanadaWorkExperiencePoints = getEduCanadaWE(pa);
            //1+2 maxium is 50
            EduLangCaWE = (pa.educationAndLanguagePoints + pa.educationAndCanadaWorkExperiencePoints) >= 50 ? 50 : pa.educationAndLanguagePoints + pa.educationAndCanadaWorkExperiencePoints;

            //3. Language and foreign work experience
            pa.languageAndForeignWorkExperiencePoints = getLangFWE(pa);
            //4. Canada work experience and foreign work experience
            pa.canadaWorkExperienceAndForeignWorkExperiencePoints = getCFWE(pa);
            CFWEP = (pa.languageAndForeignWorkExperiencePoints + pa.canadaWorkExperienceAndForeignWorkExperiencePoints) >= 50 ? 50 : pa.languageAndForeignWorkExperiencePoints + pa.canadaWorkExperienceAndForeignWorkExperiencePoints;
            //5. Get CofQ Language points
            pa.CofQAndLauangePoints = getCofQPoints(pa);
                //Total points
            if (!pa.isSecondLanguage) pa.secondLanguagePoints = 0;
            pa.totalPoints = pa.agePoints + pa.educationPoints + pa.firstLanguagePoints + pa.secondLanguagePoints + pa.canadianWorkExperiencePoints + EduLangCaWE + CFWEP + pa.CofQAndLauangePoints;
            sp.totalPoints =sp.educationPoints + sp.firstLanguagePoints + sp.canadianWorkExperiencePoints;
        }
        private static  int getEduLang(Person pa)
        {
            int score = 0;
            if (pa.education.oneEduMoreThanOneYear && pa.firstLanguageOverAll >= 7 ) score = 13;
            if (pa.education.oneEduMoreThanOneYear && pa.firstLanguageOverAll >= 9) score = 25;
            if (pa.education.twoCredentialOneMoreThan3 && pa.firstLanguageOverAll >= 7) score = 25;
            if (pa.education.twoCredentialOneMoreThan3 && pa.firstLanguageOverAll >= 9) score = 50;

            return score;

        }
        private static int getEduCanadaWE(Person pa)
        {
            int score = 0;
            if (pa.education.oneEduMoreThanOneYear && pa.caWE._years >= 1) score = 13;
            if (pa.education.oneEduMoreThanOneYear && pa.caWE._years >= 2) score = 25;
            if (pa.education.twoCredentialOneMoreThan3 && pa.caWE._years >= 1) score = 25;
            if (pa.education.twoCredentialOneMoreThan3 && pa.caWE._years >= 2) score = 50;

            return score;
        }
        private static int getLangFWE(Person pa)
        {
            int score = 0;
            if (pa.foreignWorkExperience >= 1 && pa.foreignWorkExperience <= 2 && pa.firstLanguageOverAll >= 7) score = 13;
            if (pa.foreignWorkExperience >= 1 && pa.foreignWorkExperience <= 2 && pa.firstLanguageOverAll >= 9) score = 25;
            if (pa.foreignWorkExperience >= 3 && pa.firstLanguageOverAll >= 7 ) score = 25;
            if (pa.foreignWorkExperience >= 3 && pa.firstLanguageOverAll >= 9) score = 50;
            return score;
        }
        private static int getCFWE(Person pa)
        {
            int score = 0;
            if (pa.foreignWorkExperience >= 1 && pa.foreignWorkExperience <= 2 && pa.caWE._years >= 1) score = 13;
            if (pa.foreignWorkExperience >= 1 && pa.foreignWorkExperience <= 2 && pa.caWE._years >= 2) score = 25;
            if (pa.foreignWorkExperience >= 3 && pa.caWE._years >= 1) score = 25;
            if (pa.foreignWorkExperience >= 3 && pa.caWE._years >= 2) score = 50;
            return score;
        }
        private static int getCofQPoints(Person pa)
        {
            int score = 0;
            if (pa.CofQ && pa.firstLanguageOverAll >= 5) score = 25;
            if (pa.CofQ && pa.firstLanguageOverAll >= 7) score = 50;
            return score;
        }
    }
}

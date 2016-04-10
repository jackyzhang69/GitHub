using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE
{
    public class Age
    {
        private int _age;
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
            if (PolicyData.singleSecondLanguagePoints.ContainsKey(_CLBlevel)) return PolicyData.singleSecondLanguagePoints[_CLBlevel];
            else return 0;
        }
    }
    public class CanadaWorkExperience
    {
        private int _years;
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
   
   
    public class Calculation
    {
        public string applicantName { get; set; }
        public bool married { get; set; }
        public string applicant { get; set; }
        public Age age { get; set; }
        public Education education { get; set; }
        public IELTS ielts { get; set; }
        public TEF tef { get; set; }
        public int firstLanguageOverAll { get; set; }
        public int firstLanguageReadingPoints { get; set; }
        public int firstLanguageWritingPoints { get; set; }
        public int firstLanguageListeningPoints { get; set; }
        public int firstLanguageSpeakingPoints { get; set; }
        public bool isSecondLanguage { get; set; }
        public int secondLanguageOverAll { get; set; }
        public int secondLanguageReadingPoints { get; set; }
        public int secondLanguageWritingPoints { get; set; }
        public int secondLanguageListeningPoints { get; set; }
        public int secondLanguageSpeakingPoints { get; set; }
        public bool isOneOverCLB9 { get; set; }
        public int canadaWorkExperience { get; set; }
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

            if (who == 0)  //single
            {
                //1. Age
                agePoints = age.getAgePoints();
                //2. Education
                educationPoints = education.getEducationPoints();
                //3. Language
                //3.1 First language                                                                                
                if (ielts != null)
                {
                    firstLanguageOverAll = ielts.ToCLB();
                    firstLanguageReadingPoints = new Language(ielts.ToCLB(1)).getFirstLanguagePoints();
                    firstLanguageWritingPoints = new Language(ielts.ToCLB(2)).getFirstLanguagePoints();
                    firstLanguageListeningPoints = new Language(ielts.ToCLB(3)).getFirstLanguagePoints();
                    firstLanguageSpeakingPoints = new Language(ielts.ToCLB(4)).getFirstLanguagePoints();
                    firstLanguagePoints = firstLanguageReadingPoints + firstLanguageWritingPoints + firstLanguageListeningPoints + firstLanguageSpeakingPoints;
                    isOneOverCLB9 = ielts.isOneIELTSGThanCLBN(9);
                }

                canadianWorkExperiencePoints = new CanadaWorkExperience(canadaWorkExperience).getCanadaWorkExperiencePoints();
            }
            else if (who == 1)
            {
                agePoints = age.getPAAgePoints();
                //2. Education
                educationPoints = education.getPAEducationPoints(); // First and the highest 
                //3. Language
                //3.1 First language
                if (ielts != null)
                {
                    firstLanguageOverAll = ielts.ToCLB();
                    firstLanguageReadingPoints = new Language(ielts.ToCLB(1)).getPAFirstLanguagePoints();
                    firstLanguageWritingPoints = new Language(ielts.ToCLB(2)).getPAFirstLanguagePoints();
                    firstLanguageListeningPoints = new Language(ielts.ToCLB(3)).getPAFirstLanguagePoints();
                    firstLanguageSpeakingPoints = new Language(ielts.ToCLB(4)).getPAFirstLanguagePoints();
                    firstLanguagePoints = firstLanguageReadingPoints + firstLanguageWritingPoints +
                                          firstLanguageListeningPoints + firstLanguageSpeakingPoints;
                    isOneOverCLB9 = ielts.isOneIELTSGThanCLBN(9);
                }




                // Canada work experience points
                canadianWorkExperiencePoints =
                    new CanadaWorkExperience(canadaWorkExperience).getPACanadaWorkExperiencePoints();
            }
            else if (who == 2)
            {
                educationPoints = education.getSPEducationPoints(); // First and the highest 
                                                                    //3. Language
                if (ielts != null)
                {
                    firstLanguageOverAll = ielts.ToCLB();
                    firstLanguageReadingPoints = new Language(ielts.ToCLB(1)).getSPFirstLanguagePoints();
                    firstLanguageWritingPoints = new Language(ielts.ToCLB(2)).getSPFirstLanguagePoints();
                    firstLanguageListeningPoints = new Language(ielts.ToCLB(3)).getSPFirstLanguagePoints();
                    firstLanguageSpeakingPoints = new Language(ielts.ToCLB(4)).getSPFirstLanguagePoints();
                    firstLanguagePoints = firstLanguageReadingPoints + firstLanguageWritingPoints + firstLanguageListeningPoints + firstLanguageSpeakingPoints;
                }                                                                         //3.1 First language

                canadianWorkExperiencePoints = new CanadaWorkExperience(canadaWorkExperience).getSPCanadaWorkExperiencePoints();
            }

            if (who != 2)
            {
                //3.2 Second Language
                if (isSecondLanguage)
                {
                    secondLanguageReadingPoints = new Language(tef.ToCLB(1)).getSecondLanguagePoints();
                    secondLanguageWritingPoints = new Language(tef.ToCLB(2)).getSecondLanguagePoints();
                    secondLanguageListeningPoints = new Language(tef.ToCLB(3)).getSecondLanguagePoints();
                    secondLanguageSpeakingPoints = new Language(tef.ToCLB(4)).getSecondLanguagePoints();
                    secondLanguagePoints = secondLanguageReadingPoints + secondLanguageWritingPoints +
                                           secondLanguageListeningPoints + secondLanguageSpeakingPoints;
                    secondLanguagePoints = secondLanguagePoints >= 22 ? 22 : secondLanguagePoints; //Max is 22 
                    secondLanguageOverAll = tef.ToCLB();
                }
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
            if (!isSecondLanguage) secondLanguagePoints = 0;
            totalPoints = agePoints + educationPoints + firstLanguagePoints + secondLanguagePoints + canadianWorkExperiencePoints + EduLangCaWE + CFWEP + CofQAndLauangePoints;
        }
        private int getEduLang()
        {
            int score = 0;
            if (education.oneEduMoreThanOneYear && firstLanguageOverAll >= 7 && isOneOverCLB9) score = 13;
            if (education.oneEduMoreThanOneYear && firstLanguageOverAll >= 9) score = 25;
            if (education.twoCredentialOneMoreThan3 && firstLanguageOverAll >= 7 && isOneOverCLB9) score = 25;
            if (education.twoCredentialOneMoreThan3 && firstLanguageOverAll >= 9) score = 50;

            return score;

        }
        private int getEduCanadaWE()
        {
            int score = 0;
            if (education.oneEduMoreThanOneYear && canadaWorkExperience >= 1) score = 13;
            if (education.oneEduMoreThanOneYear && canadaWorkExperience >= 2) score = 25;
            if (education.twoCredentialOneMoreThan3 && canadaWorkExperience >= 1) score = 25;
            if (education.twoCredentialOneMoreThan3 && canadaWorkExperience >= 2) score = 50;

            return score;
        }
        private int getLangFWE()
        {
            int score = 0;
            if (foreignWorkExperience >= 1 && foreignWorkExperience <= 2 && firstLanguageOverAll >= 7 && isOneOverCLB9) score = 13;
            if (foreignWorkExperience >= 1 && foreignWorkExperience <= 2 && firstLanguageOverAll >= 9) score = 25;
            if (foreignWorkExperience >= 3 && firstLanguageOverAll >= 7 && isOneOverCLB9) score = 25;
            if (foreignWorkExperience >= 3 && firstLanguageOverAll >= 9) score = 50;
            return score;
        }
        private int getCFWE()
        {
            int score = 0;
            if (foreignWorkExperience >= 1 && foreignWorkExperience <= 2 && canadaWorkExperience >= 1) score = 13;
            if (foreignWorkExperience >= 1 && foreignWorkExperience <= 2 && canadaWorkExperience >= 2) score = 25;
            if (foreignWorkExperience >= 3 && canadaWorkExperience >= 1) score = 25;
            if (foreignWorkExperience >= 3 && canadaWorkExperience >= 2) score = 50;
            return score;
        }
        private int getCofQPoints()
        {
            int score = 0;
            if (CofQ && firstLanguageOverAll >= 5) score = 25;
            if (CofQ && firstLanguageOverAll >= 7) score = 50;
            return score;
        }
    }

}

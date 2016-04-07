using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EE
{
   public  class EEFormOps
    {
        public static Person PA = new Person();
        public static Person SP = new Person();

        public static void getInput(EE ee)
        {
            PA.education = new List<Education>();
            PA.applicant = "PA";
            PA.age = getIntValue(ee.txtAge.Text);
            if (ee.cmbHighestEdu.SelectedIndex != -1) PA.education.Add(new Education(getIntValue(ee.txtHighestYears.Text), ee.cmbHighestEdu.Text));
            else {
                MessageBox.Show("You must select topest education");
                return;
            }
            if (ee.chkSecondEdu.Checked && ee.cmbSecondEdu.SelectedIndex != -1) PA.education.Add(new Education(getIntValue(ee.txtSecondEduYears.Text), ee.cmbSecondEdu.Text));
            if (ee.cmbLanguageType1.Text == "IELTS") PA.ielts = new IELTS(getFloatValue(ee.txtR1.Text), getFloatValue(ee.txtW1.Text), getFloatValue(ee.txtL1.Text), getFloatValue(ee.txtS1.Text));
            if (ee.chkSecondLanguage.Checked && ee.cmbLanguageType2.Text == "TEF") PA.tef = new TEF(getIntValue(ee.txtR2.Text), getIntValue(ee.txtW2.Text), getIntValue(ee.txtL2.Text), getIntValue(ee.txtS2.Text));
            PA.canadianWorkExperience = getIntValue(ee.txtCnWe.Text);
            PA.foreignWorkExperience = getIntValue(ee.txtFnWe.Text);
           
            if (!ee.chkSingle.Checked)
            {
                PA.married = false;
            }
            else {
                SP.married = true;
                SP.applicant = "SP";
                SP.education = new List<Education>();
                if (ee.cmbSPHighestEdu.SelectedIndex != -1) SP.education.Add(new Education(getIntValue(ee.txtSPHighestYears.Text), ee.cmbSPHighestEdu.Text));
                else {
                    MessageBox.Show("You must select topest education");
                    return;
                }
                if (ee.cmbSPLanguageType.Text == "IELTS") SP.ielts = new IELTS(getFloatValue(ee.txtSPR.Text), getFloatValue(ee.txtSPW.Text), getFloatValue(ee.txtSPL.Text), getFloatValue(ee.txtSPS.Text));
                SP.canadianWorkExperience = getIntValue(ee.txtSPCaWe.Text);
                SP.calculate();
            }
            PA.calculate();
            

        }
        public static void refreshScore(EE ee)
        {
            if (ee.chkSingle.Checked)
            {
                SP.educationPoints = 0;
                SP.firstLanguagePoints = 0;
                SP.canadianWorkExperiencePoints = 0;
                SP.totalPoints = 0;
            }

            ee.txtAgeScore.Text =PA.agePoints.ToString();
            ee.txtEduScore.Text = (PA.educationPoints+SP.educationPoints).ToString();
            ee.txtLanguageScore.Text = (PA.firstLanguagePoints + PA.secondLanguagePoints+SP.firstLanguagePoints).ToString();
            ee.txtCaExpScore.Text = (PA.canadianWorkExperiencePoints+ SP.canadianWorkExperiencePoints).ToString();
            ee.txtEduLangScore.Text = PA.educationAndLanguagePoints.ToString();
            ee.txtEduCaWeScore.Text = PA.educationAndCanadaWorkExperiencePoints.ToString();
            ee.txtLangFnWeScore.Text = PA.languageAndForeignWorkExperiencePoints.ToString();
            ee.txtCaFnWeScore.Text = PA.canadaWorkExperienceAndForeignWorkExperiencePoints.ToString();
            ee.txtCofQScore.Text = PA.CofQAndLauangePoints.ToString();
            ee.lblTotalScore.Text = (PA.totalPoints+SP.totalPoints).ToString();

        }

        public static void Construct(EE ee)
        {
            foreach(KeyValuePair<string, int> kvp in Education.singleEducationPoints)
            {
                ee.cmbHighestEdu.Items.Add(kvp.Key); 
            }
            foreach (KeyValuePair<string, int> kvp in Education.singleEducationPoints)
            {
                ee.cmbSecondEdu.Items.Add(kvp.Key);
            }
            foreach (KeyValuePair<int, string> kvp in Language.languageType)
            {
                ee.cmbLanguageType1.Items.Add(kvp.Value);
            }
            foreach (KeyValuePair<int, string> kvp in Language.secondLanguageType)
            {
                ee.cmbLanguageType2.Items.Add(kvp.Value);
            }
            foreach (KeyValuePair<int, string> kvp in Language.languageType)
            {
                ee.cmbSPLanguageType.Items.Add(kvp.Value);
            }
            foreach (KeyValuePair<string, int> kvp in Education.singleEducationPoints)
            {
                ee.cmbSPHighestEdu.Items.Add(kvp.Key);
            }

            if(!ee.chkSecondEdu.Checked) ee.grpSecondEdu.Visible=false;
            if (!ee.chkSecondLanguage.Checked) ee.grpSecondLanguage.Visible = false;
            if (ee.chkSingle.Checked) ee.grpSP.Visible = false;

        }

        public static int getIntValue(string input)
        {
            int value = 0;
            if (IsInt(input)) value = int.Parse(input);
            if (input == string.Empty) value = 0;
            return value;
        }
        public static float getFloatValue(string input)
        {
            float value = 0;
            if (IsFloat(input)) value = float.Parse(input);
            if (input == string.Empty) value = 0;
            return value;
        }

        public static decimal? getDecimalValue(string input)
        {
            decimal? value = null;
            if (IsDecimal(input)) value = decimal.Parse(input);
            if (input == string.Empty) value = null;
            return value;
        }
        public static double? getDoubleValue(string input)
        {
            double? value = null;
            if (IsDouble(input)) value = double.Parse(input);
            if (input == string.Empty) value = null;
            return value;
        }

        public static bool IsInt(string value)
        {
            int intValue;
            return Int32.TryParse(value, out intValue);
        }
        public static bool IsIntInRange(string value, int low, int high)
        {
            int intValue;
            if (Int32.TryParse(value, out intValue) && intValue >= low && intValue <= high) return true;
            else return false;

        }
        public static bool IsFloat(string value)
        {
            float floatValue;
            return float.TryParse(value, out floatValue);
        }
        public static bool IsFloatInRange(string value, float low, float high)
        {
            float floatValue;
            if (float.TryParse(value, out floatValue) && floatValue >= low && floatValue <= high) return true;
            else return false;
        }
        public static bool IsDecimal(string value)
        {
            decimal decimalValue;
            return decimal.TryParse(value, out decimalValue);
        }

        public static bool IsDouble(string value)
        {
            double doubleValue;
            return double.TryParse(value, out doubleValue);
        }
    }
}

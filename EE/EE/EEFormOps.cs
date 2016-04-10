using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EE
{
    public class EEFormOps
    {
        public static Calculation PA = new Calculation();
        public static Calculation SP = new Calculation();

        public static void getInput(EE ee)
        {
            PA.married = false;
            PA.applicantName = ee.txtClientName.Text;
            PA.age = new Age(getIntValue(ee.txtAge.Text));
            if(ee.cmbHighestEdu.SelectedIndex != -1) PA.education = new Education(ee.cmbHighestEdu.Text);
            else return;
            if(ee.cmbLanguageType1.Text == "IELTS") PA.ielts = new IELTS(getFloatValue(ee.txtL1.Text), getFloatValue(ee.txtS1.Text), getFloatValue(ee.txtR1.Text), getFloatValue(ee.txtW1.Text));
            if (ee.chkSecondLanguage.Checked && ee.cmbLanguageType2.Text == "TEF")
            {
                PA.tef = new TEF(getIntValue(ee.txtL2.Text), getIntValue(ee.txtS2.Text), getIntValue(ee.txtR2.Text),
                    getIntValue(ee.txtW2.Text));
                PA.isSecondLanguage = true;
            }

            else
            {
                PA.tef = new TEF(0, 0, 0, 0);
                PA.isSecondLanguage = false;
            }
            PA.canadaWorkExperience = getIntValue(ee.txtCnWe.Text);
            PA.foreignWorkExperience = getIntValue(ee.txtFnWe.Text);
            PA.CofQ = ee.chkCofQ.Checked?true:false;
            if(!ee.chkSingle.Checked)
            {
                SP.married = true;
                PA.married = true;
                SP.applicant = "SP";
                if(ee.cmbSPHighestEdu.SelectedIndex != -1) SP.education = new Education(ee.cmbSPHighestEdu.Text);
                else return;
                if(ee.cmbSPLanguageType.Text == "IELTS") SP.ielts = new IELTS(getFloatValue(ee.txtSPR.Text), getFloatValue(ee.txtSPW.Text), getFloatValue(ee.txtSPL.Text), getFloatValue(ee.txtSPS.Text));
                SP.canadaWorkExperience = getIntValue(ee.txtSPCaWe.Text);
                SP.calculate(2);
            }
            if(ee.chkSingle.Checked) PA.calculate(0);
            else PA.calculate(1);


        }
        public static void refreshScore(EE ee)
        {
            if(ee.chkSingle.Checked)
            {
                SP.educationPoints = 0;
                SP.firstLanguagePoints = 0;
                SP.canadianWorkExperiencePoints = 0;
                SP.totalPoints = 0;
            }
            if (!PA.isSecondLanguage) PA.secondLanguagePoints = 0;

            ee.txtAgeScore.Text = PA.agePoints.ToString();
            ee.txtEduScore.Text = PA.educationPoints.ToString();
            ee.txtSPEduScore.Text = SP.educationPoints.ToString();
            ee.txtLanguageScore.Text = (PA.firstLanguagePoints + PA.secondLanguagePoints).ToString();
            ee.txtSPLangScore.Text = SP.firstLanguagePoints.ToString();
            ee.txtCaExpScore.Text = PA.canadianWorkExperiencePoints.ToString();
            ee.txtSPCaExpScore.Text = SP.canadianWorkExperiencePoints.ToString();
            ee.txtEduLangScore.Text = PA.educationAndLanguagePoints.ToString();
            ee.txtEduCaWeScore.Text = PA.educationAndCanadaWorkExperiencePoints.ToString();
            ee.txtLangFnWeScore.Text = PA.languageAndForeignWorkExperiencePoints.ToString();
            ee.txtCaFnWeScore.Text = PA.canadaWorkExperienceAndForeignWorkExperiencePoints.ToString();
            ee.txtCofQScore.Text = PA.CofQAndLauangePoints.ToString();
            ee.lblTotalScore.Text = (PA.totalPoints + SP.totalPoints).ToString();

        }
        public static void getReport() { Report.generateReport(PA, SP); }
   

        public static void Construct(EE ee)
        {
            foreach(KeyValuePair<string, int> kvp in PolicyData.singleEducationPoints)
            {
                ee.cmbHighestEdu.Items.Add(kvp.Key);
            }
            ee.cmbHighestEdu.SelectedIndex = 4;  //defalut is 3 years+ college or university

            foreach(KeyValuePair<int, string> kvp in PolicyData.languageType)
            {
                ee.cmbLanguageType1.Items.Add(kvp.Value);
            }
            ee.cmbLanguageType1.SelectedIndex = 0; //default is IELTS

            foreach (KeyValuePair<int, string> kvp in PolicyData.secondLanguageType)
            {
                ee.cmbLanguageType2.Items.Add(kvp.Value);
            }
            ee.cmbLanguageType2.SelectedIndex = 0;//default is TEF
            foreach (KeyValuePair<int, string> kvp in PolicyData.languageType)
            {
                ee.cmbSPLanguageType.Items.Add(kvp.Value);
            }
            ee.cmbSPLanguageType.SelectedIndex = 0; //default is IELTS
            foreach(KeyValuePair<string, int> kvp in PolicyData.singleEducationPoints)
            {
                ee.cmbSPHighestEdu.Items.Add(kvp.Key);
            }
            ee.cmbSPHighestEdu.SelectedIndex = 4; //defalut is 3 years+ college or university

            if (!ee.chkSecondLanguage.Checked) ee.grpSecondLanguage.Visible = false;
            ee.chkSingle.Checked = true;
            ee.grpSP.Visible = false;
            ee.grpSPFactors.Visible = false;
        }

        public static int getIntValue(string input)
        {
            int value = 0;
            if(IsInt(input)) value = int.Parse(input);
            if(input == string.Empty) value = 0;
            return value;
        }
        public static float getFloatValue(string input)
        {
            float value = 0;
            if(IsFloat(input)) value = float.Parse(input);
            if(input == string.Empty) value = 0;
            return value;
        }

        public static decimal? getDecimalValue(string input)
        {
            decimal? value = null;
            if(IsDecimal(input)) value = decimal.Parse(input);
            if(input == string.Empty) value = null;
            return value;
        }
        public static double? getDoubleValue(string input)
        {
            double? value = null;
            if(IsDouble(input)) value = double.Parse(input);
            if(input == string.Empty) value = null;
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
            if(Int32.TryParse(value, out intValue) && intValue >= low && intValue <= high) return true;
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
            if(float.TryParse(value, out floatValue) && floatValue >= low && floatValue <= high) return true;
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

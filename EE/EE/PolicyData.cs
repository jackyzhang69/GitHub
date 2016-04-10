using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE
{
    public class PolicyData
    {
        // Age points data. Key:age, Value: points
        public static Dictionary<int, int> singleAgePoints = new Dictionary<int, int> //Single points
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
        public static Dictionary<int, int> PAAgePoints = new Dictionary<int, int> //if married, PA points, SP doesn't count based age
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

        // Education points data: Key: Education level, Value: Points
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

        public static Dictionary<string, int> PAEducationPoints = new Dictionary<string, int>
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
        public static Dictionary<string, int> SPEducationPoints = new Dictionary<string, int>
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

        // Language definition
        public static Dictionary<int, string> languageType = new Dictionary<int, string>
        {
            {1,"IELTS"}
        };
        public static Dictionary<int, string> secondLanguageType = new Dictionary<int, string>
        {
            {1,"TEF"}
        };

        //Language points data  key: CLB level, Value: Points
        public static Dictionary<int, int> singleFirstLanguagePoints = new Dictionary<int, int>
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
        public static Dictionary<int, int> PAFirstLanguagePoints = new Dictionary<int, int>
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
        public static Dictionary<int, int> SPFirstLanguagePoints = new Dictionary<int, int>
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
        public static Dictionary<int, int> singleSecondLanguagePoints = new Dictionary<int, int>
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

        //Canada work experience definition Key: work years, Value:points
        public static Dictionary<int, int> canadianWorkExperiencePoints = new Dictionary<int, int>
        {
            { 1,40},
            { 2,53},
            { 3,64},
            { 4,72},
            { 5,80}
        };
        public static Dictionary<int, int> PAcanadianWorkExperiencePoints = new Dictionary<int, int>
        {
            {1,35},
            {2,46},
            {3,56},
            {4,63},
            {5,70}
        };
        public static Dictionary<int, int> SPcanadianWorkExperiencePoints = new Dictionary<int, int>
        {
            {1,5},
            {2,7},
            {3,8},
            {4,9},
            {5,10}
        };
    }
}

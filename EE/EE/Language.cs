using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE
{

    public static class LanguageData
    {
        public static Dictionary<string, int> CELPIPG13 = new Dictionary<string, int>()
            {
                {"5H",10},
                {"5L",9},
                {"4H",8},
                {"4L",7},
                {"3H",6},
                {"3L",5},
                {"2H",4}
            };
        public static float[,] IELTSG = new float[,]  //Reading, Writing, Listening, Speaking
            {
                {10f, 8.0f,7.5f,8.5f,7.5f},
                {9f,7.0f,7.0f,8.0f,7.0f},
                {8f,6.5f,6.5f,7.5f,6.5f},
                {7f,6.0f,6.0f,6.0f,6.0f},
                {6f,5.0f,5.5f,5.5f,5.5f},
                {5f,4.0f,5.0f,5.0f,5.0f},
                {4f,3.5f,4.0f,4.5f,4.0f}
            };
        public static int[,] TEF = new int[,]  // Reading, Writing, Listening, Speaking
            {
                {10,263,277,393,415,316,333,393,415 },
                { 9,248,262, 371,392,298,315,371,392},
                { 8,233,247,349,370,280,297,349,370},
                { 7,207,232,310,348,249,279,310,348},
                { 6,181,206,271,309,217,248,271,309},
                { 5,151,180,226,270,181,216,226,270},
                { 4,121,150,181,225,145,180,181,225}
            };
    }
    public class IELTS
    {
        private float _Listening { get; set; }
        private float _Speaking { get; set; }
        private float _Reading { get; set; }
        private float _Writing { get; set; }
        public IELTS(float r, float w, float l, float s)
        {
            _Reading = r;
            _Writing = w;
            _Listening = l;
            _Speaking = s;

        }
        public int ToCLB()
        {
            int[] clb = new int[LanguageData.IELTSG.Length / 5];
            for (int i = 0; i < LanguageData.IELTSG.Length / 5; i++)
            {
                if (_Reading >= LanguageData.IELTSG[i, 1] && _Writing >= LanguageData.IELTSG[i, 2] && _Listening >= LanguageData.IELTSG[i, 3] && _Speaking >= LanguageData.IELTSG[i, 4]) clb[i] = (int)LanguageData.IELTSG[i, 0];

            }
            return clb.Max();
        }
        public int ToCLB(int factorIndex) //return single factor CLB level. 0 is listening, 1 speaking 2 reading 3 writing
        {
            int clb = 0;
            //Reading is in index 0
            for (int i = 0; i < LanguageData.IELTSG.Length / 5; i++)
            {
                switch (factorIndex)
                {

                    case 1:
                        if (_Reading >= LanguageData.IELTSG[i, 1]) return clb = (int)LanguageData.IELTSG[i, 0];
                        break;
                    case 2:
                        if (_Writing >= LanguageData.IELTSG[i, 2]) return clb = (int)LanguageData.IELTSG[i, 0];
                        break;
                    case 3:
                        if (_Listening >= LanguageData.IELTSG[i, 3]) return clb = (int)LanguageData.IELTSG[i, 0];
                        break;
                    case 4:
                        if (_Speaking >= LanguageData.IELTSG[i, 4]) return clb = (int)LanguageData.IELTSG[i, 0];
                        break;
                }
            }
            return clb;
        }
        public bool isOneIELTSGThanCLBN(int n)
        {
            int[] clb = new int[LanguageData.IELTSG.Length / 5];
            bool result = false;
            //check Reading
            for (int i = 0; i < LanguageData.IELTSG.Length / 5; i++)
            {
                if (_Reading >= LanguageData.IELTSG[i, 1]) clb[i] = (int)LanguageData.IELTSG[i, 0];

            }
            if (clb.Max() >= n) result = true; ;
            //check writing
            for (int i = 0; i < LanguageData.IELTSG.Length / 5; i++)
            {
                if (_Writing >= LanguageData.IELTSG[i, 2]) clb[i] = (int)LanguageData.IELTSG[i, 0];

            }
            if (clb.Max() >= n) result = true;
            //check listening
            for (int i = 0; i < LanguageData.IELTSG.Length / 5; i++)
            {
                if (_Listening >= LanguageData.IELTSG[i, 3]) clb[i] = (int)LanguageData.IELTSG[i, 0];

            }
            if (clb.Max() >= n) result = true;
            //check speaking
            for (int i = 0; i < LanguageData.IELTSG.Length / 5; i++)
            {
                if (_Speaking >= LanguageData.IELTSG[i, 4]) clb[i] = (int)LanguageData.IELTSG[i, 0];

            }
            if (clb.Max() >= n) result = true;
            return result;

        }
    }
    public class CELPIP
    {
        private int _Listening { get; set; }
        private int _Speaking { get; set; }
        private int _Reading { get; set; }
        private int _Writing { get; set; }
        public CELPIP(int l, int s, int r, int w)
        {
            _Listening = l;
            _Speaking = s;
            _Reading = r;
            _Writing = w;
        }
        public int ToCLB()
        {
            List<int> clb = new List<int>();
            clb.Add(_Listening);
            clb.Add(_Speaking);
            clb.Add(_Reading);
            clb.Add(-_Writing);
            return clb.Min();
        }
        public int ToCLB(int factor)
        {
            return factor;
        }
    }
    public class TEF
    {
        private int _Listening { get; set; }
        private int _Speaking { get; set; }
        private int _Reading { get; set; }
        private int _Writing { get; set; }
        public TEF(int r, int w, int l, int s)
        {
            _Listening = l;
            _Speaking = s;
            _Reading = r;
            _Writing = w;
        }
        public int ToCLB(int factorIndex) //return single factor CLB level. 1 is listening, 2 speaking 3 reading 4 writing
        {
            for (int i = 0; i < LanguageData.TEF.Length / 9; i++)
            {
                switch (factorIndex)
                {
                    case 0:
                        if (_Listening >= LanguageData.TEF[i, factorIndex * 2 - 1] && _Listening <= LanguageData.TEF[i, factorIndex * 2]) return LanguageData.TEF[i, 0];
                        break;
                    case 1:
                        if (_Speaking >= LanguageData.TEF[i, factorIndex * 2 - 1] && _Speaking <= LanguageData.TEF[i, factorIndex * 2]) return LanguageData.TEF[i, 0];
                        break;
                    case 2:
                        if (_Reading >= LanguageData.TEF[i, factorIndex * 2 - 1] && _Reading <= LanguageData.TEF[i, factorIndex * 2]) return LanguageData.TEF[i, 0];
                        break;
                    case 3:
                        if (_Writing >= LanguageData.TEF[i, factorIndex * 2 - 1] && _Writing <= LanguageData.TEF[i, factorIndex * 2]) return LanguageData.TEF[i, 0];
                        break;
                }

            }
            return 0;
        }

        public int ToCLB() //return general CLB level
        {
            List<int> clb = new List<int>();
            for (int i = 1; i <= 4; i++) clb.Add(ToCLB(i));
            return clb.Min();
        }
    }
    public class CLB
    {
        private int _clbLevel;
        public CLB(int clbLevel)
        {
            _clbLevel = clbLevel;
        }
        public CELPIP CLBtoCELPIPG()
        {
            return new CELPIP(_clbLevel, _clbLevel, _clbLevel, _clbLevel);
        }
        public IELTS CLBtoIELTSG()
        {
            if (_clbLevel > 10) _clbLevel = 10;
            if (_clbLevel >= 4)
            {
                for (int i = 0; i < LanguageData.IELTSG.Length / 5; i++)
                {
                    if ((int)LanguageData.IELTSG[i, 0] == _clbLevel)
                    {
                        return new IELTS(LanguageData.IELTSG[i, 1], LanguageData.IELTSG[i, 2], LanguageData.IELTSG[i, 3], LanguageData.IELTSG[i, 4]);
                    }

                }
            }

            return new IELTS(0, 0, 0, 0);
        }
        //// CLB<->CLIPIP General, Version: Before May 3, 2013
        //public static int CELPIPG13toCLB(string reading, string writing, string listensing, string speaking)
        //{
        //    List<string> scores = new List<string>() { reading, writing, listensing, speaking };

        //    int[] level = new int[4];


        //    for (int i = 0; i < 4; i++) // search for 4 string 
        //    {
        //        foreach (KeyValuePair<string, int> kvp in CELPIPG13) // in the dictionary
        //        {

        //            if (kvp.Key == scores[i]) level[i] = kvp.Value;  // find the match and assign the level to array;
        //        }

        //    }

        //    return level.Min();
        //}
        //public static string CLBtoCELPIPG13(int clb)
        //{

        //    string feedback = "";
        //    foreach (KeyValuePair<string, int> kvp in CELPIPG13)
        //    {
        //        if (kvp.Value == clb) feedback = kvp.Key;
        //    }

        //    return feedback;
        //}
        //IELTS General to CLB

        //IELTS 4 Factors to CLB ; input can be reading, writing, listening, speaking score. factor is index, 1: reading, 2:writing 3:listening 4:speaking
        //static enum clbLanuage
        //{
        //    CLB=0,
        //    Reading=1,
        //    Writing=2,
        //    Listening=3,
        //    Speaking=4
        //};
    }
}

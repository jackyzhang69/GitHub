using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace EE
{
    public class PDFItems
    {
        // PDF English fonts define 
        public Font fontLevel1 = FontFactory.GetFont("Arial", 24, Font.BOLD, BaseColor.BLACK);
        public Font fontLevel2 = FontFactory.GetFont("Arial", 22, Font.BOLD, BaseColor.BLACK);
        public Font fontLevel3 = FontFactory.GetFont("Arial", 20, Font.BOLD, BaseColor.BLACK);
        public Font fontLevel4 = FontFactory.GetFont("Arial", 18, Font.BOLD, BaseColor.BLACK);
        public Font fontLevel5 = FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK);
        public Font fontLevel6 = FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLACK);
        public Font fontLevel7 = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK);
        public Font fontBody = FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK);
        public Font fontFoot = FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK);
        public Font fontNote = FontFactory.GetFont("Arial", 9, Font.ITALIC, BaseColor.BLUE);


        //public PDFItems() {
        //    string fontPath = @"C:\GitHub\immmanager\BCPNP-SkillWorker\bin\Debug\Cfonts\XinshuFont.ttf";
        //BaseFont bfChinese = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        //Font bfx = new Font(bfChinese, 12, Font.NORMAL);
        //public Font cxfontLevel1 = new Font(bfx, 24, Font.NORMAL);
        //public Font cxfontLevel2 = new Font(bfx, 22);
        //public Font cxfontLevel3 = new Font(bfx, 20);
        //public Font cxfontLevel4 = new Font(bfx, 18);
        //public Font cxfontLevel5 = new Font(bfx, 16);
        //public Font cxfontLevel6 = new Font(bfx, 14);
        //public Font cxfontLevel7 = new Font(bfx, 12);
        //public Font cxfontBody = new Font(bfx, 10);
        //public Font cxfontFoot = new Font(bfx, 9);
        //public Font cxfontNote = new Font(bfxi, 9);

        ////Kai bold Fonts
        //static public string cfontpath1 = @"Cfonts\kaiBoldFont.ttf";
        //static public BaseFont bf1 = BaseFont.CreateFont(cfontpath1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        //static public BaseFont bf2 = BaseFont.CreateFont(cfontpath1, BaseFont.TIMES_ITALIC, BaseFont.EMBEDDED);

        //public Font ckfontLevel1 = new Font(bf1, 24);
        //public Font ckfontLevel2 = new Font(bf1, 22);
        //public Font ckfontLevel3 = new Font(bf1, 20);
        //public Font ckfontLevel4 = new Font(bf1, 18);
        //public Font ckfontLevel5 = new Font(bf1, 16);
        //public Font ckfontLevel6 = new Font(bf1, 14);
        //public Font ckfontLevel7 = new Font(bf1, 12);
        //public Font ckfontBody = new Font(bf1, 10);
        //public Font ckfontFoot = new Font(bf1, 9);
        //public Font ckfontNote = new Font(bf2, 9);  
    //}

        // PDF Chinese fonts define

        // Kai Fonts

        // static public BaseFont bfxi = BaseFont.CreateFont(cfontpath, BaseFont.TIMES_ITALIC, BaseFont.EMBEDDED);
        
    }
}

        
    
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using iTextSharp.text.pdf;
//using iTextSharp.text;
using CA.Immigration.Data;
using System.IO;
using Aspose.Pdf;



namespace CA.Immigration.PDF
{
    public class PDFTools
    {
        //static iTextSharp.text.Font Level0 = FontFactory.GetFont("Arial", 24, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
        //static iTextSharp.text.Font Level1 = FontFactory.GetFont("Arial", 20, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
        //static iTextSharp.text.Font Level2 = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
        //static iTextSharp.text.Font Level3 = FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
        //static iTextSharp.text.Font Level4 = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
        //static iTextSharp.text.Font Level5 = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
        //static iTextSharp.text.Font Level6 = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);  // Refer as body font
        //static iTextSharp.text.Font fontNote = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.ITALIC, BaseColor.BLUE); //Refer as annotation font




        //public void generatePDF(CommonDataContext dc)
        //{

        //    Document doc = new Document(PageSize.LETTER, 72, 72, 72, 72);
        //    PdfWriter.GetInstance(doc, new FileStream(@"c:\vba\hello.pdf", FileMode.Create));

        //    doc.Open();

        //    //// add a img to pdf
        //    //Image img = Image.GetInstance(@"c:\C#\Chinesefonts\logo.jpg");
        //    //img.SetAbsolutePosition(300, 700);
        //    //doc.Add(img);

        //    Paragraph para1 = (new Paragraph(18.5f, "Subject", Level0) { SpacingAfter = 5 });
        //    para1.Alignment = Element.ALIGN_CENTER;

        //    Paragraph para2 = (new Paragraph(18.5f, "2nd subject", Level1) { SpacingAfter = 5 });
        //    para2.Alignment = Element.ALIGN_CENTER;

        //    Paragraph para3 = (new Paragraph(18.5f, "Topic", Level2) { SpacingAfter = 5 });
        //    para3.Alignment = Element.ALIGN_LEFT;
        //    Paragraph para4 = (new Paragraph(18.5f, "Topic", Level3) { SpacingAfter = 5 });
        //    para4.Alignment = Element.ALIGN_LEFT;
        //    Paragraph para5 = (new Paragraph(18.5f, "Topic", Level4) { SpacingAfter = 5 });
        //    para5.Alignment = Element.ALIGN_LEFT;
        //    Paragraph para6 = (new Paragraph(18.5f, "Topic", Level5) { SpacingAfter = 5 });
        //    para6.Alignment = Element.ALIGN_LEFT;
        //    Paragraph para7 = (new Paragraph(18.5f, "Topic", Level6) { SpacingAfter = 5 });
        //    para7.Alignment = Element.ALIGN_LEFT;
        //    Paragraph para8 = (new Paragraph(18.5f, "Topic", fontNote) { SpacingAfter = 5 });
        //    para8.Alignment = Element.ALIGN_LEFT;

        //    doc.Add(para1);
        //    doc.Add(para2);
        //    doc.Add(para3);
        //    doc.Add(para4);
        //    doc.Add(para5);
        //    doc.Add(para6);
        //    doc.Add(para7);
        //    doc.Add(para8);


        //    Paragraph para9 = (new Paragraph(18.5f, "Items", fontNote) { SpacingAfter = 5 });
        //    para9.Alignment = Element.ALIGN_LEFT;
        //    para9.IndentationRight = 20;
        //    doc.Add(para4);


        //    float[] width = new float[3] { 80f, 25f, 25f };

        //    //p.IndentationRight = 100;
        //    //            p.IndentationLeft = 100;
        //    PdfPTable table = new PdfPTable(3);
        //    table.HorizontalAlignment = Element.ALIGN_MIDDLE;
        //    table.SetWidths(width);
        //    table.GetFittingRows(18f, 0);
        //    PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns"));
        //    cell.Colspan = 3;
        //    cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
        //    table.AddCell(cell);






        //    foreach(tblMedia m in dc.tblMedias)
        //    {

        //        PdfPCell c1 = new PdfPCell(new Phrase(m.MediaName));
        //        //table.AddCell(p.Name);
        //        c1.HorizontalAlignment = 1;
        //        table.AddCell(c1);

        //        //table.AddCell(@"3000 40小时 每小时17.26");
        //        PdfPCell c2 = new PdfPCell(new Phrase(m.Id.ToString()));
        //        c2.HorizontalAlignment = 1;
        //        table.AddCell(c2);
        //        PdfPCell c3 = new PdfPCell(new Phrase(m.Scope));
        //        c3.HorizontalAlignment = 1;
        //        table.AddCell(c3);

        //    }
        //    doc.Add(table);



        //    doc.Close();



        //}
        public static void getXFAValue(Dictionary<string, string> d)
        {
            StringBuilder sb = new StringBuilder();
            Document doc1 = new Document(@"c:\vba\emp5593.pdf");


            using(TextWriter writer = File.CreateText(@"c:\vba\emp5593.txt"))
            {
                //get XFA field value
                //foreach(KeyValuePair<string, string> kvp in d)
                //{
                //    writer.Write(kvp.Key + "," + doc1.Form.XFA[kvp.Key] + "\n");
                //}
               
                writer.Write(" EMP5593_E[0].Page4[0].chkB_TradeDiploma[0]" + "\t" + doc1.Form.XFA[" EMP5593_E[0].Page4[0].chkB_TradeDiploma[0]"] + "\n");
                writer.Write("EMP5593_E[0].Page4[0].chkB_TradeDiploma[1]" + "\t" + doc1.Form.XFA["EMP5593_E[0].Page4[0].chkB_TradeDiploma[1]"] + "\n");
                //writer.Write("" + "\t" + doc1.Form.XFA[""] + "\n");
                writer.Write("EMP5593_E[0].Page4[0].chkB_Apprenticeship[0]" + "\t" + doc1.Form.XFA["EMP5593_E[0].Page4[0].chkB_Apprenticeship[0]"] + "\n");
                writer.Write("EMP5593_E[0].Page4[0].chkB_BachelorsDegree[0]" + "\t" + doc1.Form.XFA["EMP5593_E[0].Page4[0].chkB_BachelorsDegree[0]"] + "\n");
                writer.Write("EMP5593_E[0].Page4[0].chkB_CollegeLevelDiploma[0]" + "\t" + doc1.Form.XFA["EMP5593_E[0].Page4[0].chkB_CollegeLevelDiploma[0]"] + "\n");
                writer.Write("EMP5593_E[0].Page4[0].chkB_DisabilityInsurance[0]" + "\t" + doc1.Form.XFA["EMP5593_E[0].Page4[0].chkB_DisabilityInsurance[0]"] + "\n");
                writer.Write("EMP5593_E[0].Page4[0].chkB_DoctorOfMedicine[0]" + "\t" + doc1.Form.XFA["EMP5593_E[0].Page4[0].chkB_DoctorOfMedicine[0]"] + "\n");
                writer.Write("EMP5593_E[0].Page4[0].chkB_DoctoratePhd[0]" + "\t" + doc1.Form.XFA["EMP5593_E[0].Page4[0].chkB_DoctoratePhd[0]"] + "\n");
                //writer.Write("" + "\t" + doc1.Form.XFA[""] + "\n");
                //writer.Write("" + "\t" + doc1.Form.XFA[""] + "\n");
                
                writer.Write("EMP5593_E[0].Page8[0].rb_Question8[0]" + "\t" + doc1.Form.XFA["EMP5593_E[0].Page8[0].rb_Question8[0]"] + "\n");

            }



        }
    }
}


using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System;


namespace EE
{
    public class Report
    {

        public static void generateReport(Person pa, Person sp)
        {
            string[,] info = new string[,] {
                {"Factors","Your Condition","Your Points" },
                {"Age",pa.age._age.ToString(),pa.agePoints.ToString()},
                {"Education",pa.education.edulevel.ToString(),pa.educationPoints.ToString()},
                {"First Language",pa.firstLanguageOverAll.ToString(),pa.firstLanguagePoints.ToString()},
                {"Second Language",pa.secondLanguageOverAll.ToString(),pa.secondLanguagePoints.ToString()},
                {"Canada Experience",pa.caWE._years.ToString(), pa.canadianWorkExperiencePoints.ToString()},
                {"Education Language", "Combination score of education and language",pa.educationAndLanguagePoints.ToString()},
                {"Education Canada Work Experience","Education & "+pa.caWE._years+" year(s) Canada Work Experience combination score",pa.educationAndCanadaWorkExperiencePoints.ToString()},
                {"Language Foreign Work Experience","Language & "+pa.foreignWorkExperience+" year(s) Foreign work experience combination score", pa.languageAndForeignWorkExperiencePoints.ToString()},
                {"Canada and Foeign Work Experience",pa.caWE._years+" year(s) in Canada"+pa.foreignWorkExperience+" year(s) outside of Canada", pa.canadaWorkExperienceAndForeignWorkExperiencePoints.ToString()},
                {"Certificate of Qualification",pa.CofQ.ToString(),pa.CofQAndLauangePoints.ToString() },
                {"Spouse Education Score",!pa.single?sp.education.edulevel:"N/A",sp.educationPoints.ToString()},
                {"Spouse Language",!pa.single?sp.firstLanguageOverAll.ToString():"N/A",sp.firstLanguagePoints.ToString() },
                {"Spouse Canada Work Experience",!pa.single?sp.caWE._years.ToString():"N/A",sp.canadianWorkExperiencePoints.ToString() }
            };

            Document doc = new Document(PageSize.LETTER, 72, 72, 72, 72);
            
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fn = path + @"\EE Points-" + pa.applicantName + DateTime.Now.ToString("yyMMdd") + "-" + String.Format("{0:hh}", DateTime.Now) + String.Format("{0:mm}", DateTime.Now) + String.Format("{0:ss}", DateTime.Now) + ".pdf";
            PdfWriter.GetInstance(doc, new FileStream(fn, FileMode.Create));

            doc.Open();

            // add a img to pdf

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(@"Resources\logo.png");

            img.SetAbsolutePosition(toUnit(5f), toUnit(9.75f));
            // set the size to be 2.5 inch x 1.5 inch
            img.ScaleToFit(toUnit(2.5f), toUnit(1.5f));
            doc.Add(img);

            doc.Add(new Paragraph("\n\n\n"));

            PDFItems font = new PDFItems();

            Paragraph Title = (new Paragraph(18.5f, " Express Entry Scoring Anlaysis", font.fontLevel3) { SpacingAfter = 15 });
            if (pa.single) sp.totalPoints = 0;
            Paragraph paraforClient = (new Paragraph(18.5f, "For: " + pa.applicantName + "   Date: " + DateTime.Today.ToString("MMM-dd,yyyy") + "     Total Points: " + (pa.totalPoints+sp.totalPoints).ToString(), font.fontLevel6) { SpacingAfter = 10 });
            Title.Alignment = Element.ALIGN_CENTER;
            paraforClient.Alignment = Element.ALIGN_CENTER;
            ////para.IndentationRight = 10;
            doc.Add(Title);
            doc.Add(paraforClient);


            PdfPTable table = new PdfPTable(3);
            float[] sglTblHdWidths = new float[3];
            sglTblHdWidths[0] = 300f;
            sglTblHdWidths[1] = 200f;
            sglTblHdWidths[2] = 100f;
            // Set the column widths on table creation. Unlike HTML cells cannot be sized.
            table.SetWidths(sglTblHdWidths);

            table.HorizontalAlignment = Element.ALIGN_MIDDLE;
            // float[] width = new float[3] { toUnit(2.17f),toUnit(2.17f),toUnit(2.17f)};
            table.WidthPercentage = 100;
            table.GetFittingRows(18f, 0);
            PdfPCell cell = new PdfPCell(new Phrase((pa.applicantName + " Scores in detail\n"), font.fontLevel5));
            cell.Colspan = 3;

            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);


            for(int i = 0; i < info.Length / 3; i++)
            {
                table.AddCell(info[i, 0]);
                table.AddCell(info[i, 1]);
                table.AddCell(info[i, 2]);

            }

            doc.Add(table);


            Chunk thanks = new Chunk("Thanks for your enquiry.\nIf you have further requirement for how to upgrade your scores, please make an appointment with our ICCRC licensed Immigration Consultant.\n\n");
            //  sign.Leading = 36;
            doc.Add(thanks);
            //RCICSigning(doc);
            //table.SpacingAfter = 0;
            //Chunk sign = new Chunk("Jacky Zhang\nRCIC: R511623\n");
            //doc.Add(sign);

            //float curY = writer.GetVerticalPosition(false);
            //float x = doc.Left + sign.GetWidthPoint();
            //MessageBox.Show(x.ToString());

            Chunk contact1 = new Chunk("\nContact Information\nGuangson Headquarter:\n#1017 4500 Kingsway, Burnaby V5H 2A9\nEmail:info@guangson.com\tTel:+ 1 604 - 282 - 1536");
            Chunk contact2 = new Chunk("Guangson Immigration:\n#2319 4500 Kingsway, Burnaby V5H 2A9\nEmail:immigration@guangson.com\t+ 1 604-558-1536");
            //Chunk contact1 = new Chunk("\n\n\nContact Information\nJacky Zhang\nRCIC:R511623\n1411 Garibaldi Pl, Coquitlam, BC V3E 2S6\nEmail:Noah.Consultant@outlook.com\tTel:+ 1 778-321-5110");
            doc.Add(contact1);
            doc.Add(contact2);
            doc.Close();

            // Open the new created pdf
            System.Diagnostics.Process.Start(fn);


        }

        private static void RCICSigning(Document doc)
        {
            Image signature = Image.GetInstance(@"c:\vba\Signature.jpg");
            //signature.SetAbsolutePosition(toUnit(5.5f), toUnit(9.75f));
            // set the size to be 2.5 inch x 1.5 inch
            signature.ScaleToFit(toUnit(1.2f), toUnit(0.6f));
            doc.Add(signature);
        }

        public static float toUnit(float inch)
        {

            return inch * 72;
        }

    }

  
}

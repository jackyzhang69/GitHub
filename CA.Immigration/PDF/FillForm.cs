using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Aspose.Pdf;
using CA.Immigration.Data;
using Aspose.Pdf.Facades;
using System.Drawing;
using CA.Immigration.Utility;

namespace CA.Immigration.PDF
{
    public class FillForm
    {
        public static void fillForm(string formname, Dictionary<string, string> dict)
        {
            // Create a PDF license object
            Aspose.Pdf.License license = new Aspose.Pdf.License();
            // Instantiate license file
            license.SetLicense("CA.Immigration.Aspose.Pdf.lic");
            // Set the value to indicate that license will be embedded in the application
            license.Embedded = true;


            // Read the source PDF form with FileAccess of Read and Write.
            // We need ReadWrite permission because after modification,
            // we need to save the updated contents in same document/file.
            //try
            //{
            FileStream fs = new FileStream("c:/vba/" + formname + ".pdf", FileMode.Open, FileAccess.ReadWrite);
            // Instantiate Document instance
            Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document(fs);

            foreach(KeyValuePair<string, string> kvp in dict)
            {
                pdfDocument.Form.XFA[kvp.Key] = kvp.Value;
            }


            // Save the updated document in save FileStream
            pdfDocument.Save();
            // Close the File Stream object
            fs.Close();

            System.Diagnostics.Process.Start(@"c:\vba\" + formname + ".pdf");
            //string fullname = @"c:/vba/" + formname + ".pdf";
            //signForm(fullname);

            //}
            //catch(Exception e) {
            //    Console.WriteLine("Exception occured:{0}", e.Message);
            //    //Console.ReadKey();
            //}

           

        }
        public static void signForm(string filename)
        {

            string newname = StringOps.sep(filename, '.')[0];
            newname = newname + "-signed.pdf";//save output PDF file


            ////open document
            //Aspose.Pdf.Facades.Form pdfForm = new Aspose.Pdf.Facades.Form();
            //pdfForm.BindPdf(newname);
            ////flatten fields
            //pdfForm.FlattenAllFields();


            ////save output
            //pdfForm.Save(newname);

            //create PdfFileMend object to add text
            PdfFileMend mender = new PdfFileMend();
            mender.BindPdf(filename);

            //add image in the PDF file
            mender.AddImage(@"c:\vba\signature-jacky.png", 2, 235, 470, 340, 500);
            mender.AddImage(@"c:\vba\Signature-Xiangliang.png", 2, 235, 220, 340, 250);
            mender.Save(newname);
            //close PdfFileMend object
            mender.Close();
            System.Diagnostics.Process.Start(newname);
            Console.WriteLine(filename + " has been signed and saved as " + newname + " !");
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace CA.Immigration.PDF
{
    public class FillForm
    {
        public static void fillForm(string formname, Dictionary<string, string> dict)
        {

            // Get license
            Aspose.Pdf.License license = new Aspose.Pdf.License();
            license.SetLicense(@"c:\references\Aspose.Pdf.lic");



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
                System.Diagnostics.Process.Start(@"c:\vba\emp5593.pdf");
            //}
            //catch(Exception e) {
            //    Console.WriteLine("Exception occured:{0}", e.Message);
            //    //Console.ReadKey();
            //}



        }


    }
}

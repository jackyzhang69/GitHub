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
using System.Windows.Forms;

namespace CA.Immigration.PDF
{
    public class FormOPs
    {
        public static void fillForm(string filename, Dictionary<string, string> dict)
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

            try
            {
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite);
                // Instantiate Document instance
                Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document(fs);
                foreach (KeyValuePair<string, string> kvp in dict)
                {
                    pdfDocument.Form.XFA[kvp.Key] = kvp.Value;
                }
                pdfDocument.Save();
                // Close the File Stream object
                fs.Close();
                System.Diagnostics.Process.Start(filename);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        public static void signForm(string filename, List<FormSignData> fsd)
        {

            string newname = StringOps.sep(filename, '.')[0];
            newname = newname + "-signed.pdf";//save output PDF file

            //create PdfFileMend object to add text
            PdfFileMend mender = new PdfFileMend();
            mender.BindPdf(filename);

            //add image in the PDF file
            //byte[] bt = dd.tblPersons.Where(x => x.Id == 1).Select(x => x.Signature).FirstOrDefault().ToArray();
            //mender.AddImage(@"c:\vba\signature-jacky.png", 2, 235, 470, 340, 500);
            //mender.AddImage(new MemoryStream(bt), 2, 235, 220, 340, 250);

            using (CommonDataContext cdc = new CommonDataContext())
            {
                foreach (FormSignData f in fsd)
                {
                    // how to handle Null image value????
                    byte[] bt = cdc.tblPersons.Where(x => x.Id == f.SignerId).Select(x => x.theSignature).FirstOrDefault().ToArray();
                    mender.AddImage(new MemoryStream(bt), f.Page, f.x1, f.y1, f.x2, f.y2);
                }
            }
            mender.Save(newname);
            //close PdfFileMend object
            mender.Close();


            ////open document
            //Aspose.Pdf.Facades.Form pdfForm = new Aspose.Pdf.Facades.Form();
            //pdfForm.BindPdf(newname);
            ////flatten fields
            //pdfForm.FlattenAllFields();
            ////save output
            //pdfForm.Save(newname);
            System.Diagnostics.Process.Start(newname);
            //  Console.WriteLine(filename + " has been signed and saved as " + newname + " !");
        }

        public class FormSignData
        {
            public int SignerId { get; set; }
            public int Page { get; set; }
            public int x1 { get; set; }
            public int y1 { get; set; }
            public int x2 { get; set; }
            public int y2 { get; set; }

            public FormSignData(int si, int p, int x01, int y01, int x02, int y02)
            {
                SignerId = si;
                Page = p;
                x1 = x01;
                y1 = y01;
                x2 = x02;
                y2 = y02;
            }

        }
        public class IMM5476Sign
        {
            List<FormSignData> fsd = new List<FormSignData>();

            public IMM5476Sign(int[] IdList)  // Constructor with at least two Ids
            {
                if (IdList.Length >= 2)
                {
                    fsd.Add(new FormSignData(IdList[0], 2, 235, 470, 340, 500));  //RCIC Sign
                    fsd.Add(new FormSignData(IdList[1], 2, 235, 220, 340, 250));  // PA or custodian 1 sign
                    if (IdList.Length == 3) fsd.Add(new FormSignData(IdList[2], 2, 235, 170, 340, 200));  // Spouse or custodian 2 sign
                }
                else MessageBox.Show("There are at least two person's signatures needed:RCIC and PA", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // method to return FormSignData list
            public List<FormSignData> getFormData()
            {
                return fsd;
            }

        }
    }



}

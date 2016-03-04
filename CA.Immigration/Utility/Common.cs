using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA.Immigration.Utility;
using CA.Immigration.Data;
using System.IO;
using System.Drawing;

namespace CA.Immigration.Utility
{
    public class Address
    {
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public string POBox { get; set; }
        public string AptUnit { get; set; }
        public string StreetNo { get; set; }
        public string StreetName { get; set; }

        public string getStreetAddress()
        {
            if (POBox != string.Empty && AptUnit != string.Empty)
                return POBox + ", " + AptUnit + ", " + StreetNo + " " + StreetName;
            else if (POBox != string.Empty) return POBox + ", " + StreetNo + " " + StreetName;
            else if (AptUnit != string.Empty) return AptUnit + ", " + StreetNo + " " + StreetName;
            else return StreetNo + " " + StreetName;
        }

        public string getFullAddress()
        {
            if (POBox != string.Empty && AptUnit != string.Empty)
                return POBox + ", " + AptUnit + ", " + StreetNo + " " + StreetName + "," + City + ", " + Province + ", " + Country + " " + PostalCode;
            else if (POBox != string.Empty) return POBox + " " + StreetNo + " " + StreetName + "," + City + ", " + Province + ", " + Country + " " + PostalCode;
            else if (AptUnit != string.Empty) return AptUnit + " " + StreetNo + " " + StreetName + "," + City + ", " + Province + ", " + Country + " " + PostalCode;
            else return StreetNo + " " + StreetName + "," + City + ", " + Province + ", " + Country + " " + PostalCode;

        }

        public static string[,] CndProvince = new string[,] {

        {"AB","Alberta" },
        {"BC","British Columbia"},
        {"MB","Manitoba" },
        {"NB"," New Brunswick" },
        {"NL","Newfoundland and Labrador" },
        {"NS","Nova Scotia" },
        {"NT","Northwest Territories" },
        {"NU","Nunavut" },
        {"ON","Ontario"},
        {"PE","Prince Edward Island" },
        {"QC","Quebec" },
        {"SK","Saskatchewan" },
        {"YT","Yukon" }
        };
    }

    public class ContactInfo
    {
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public Address ContactAddress { get; set; }


    }


    public class Media
    {

        public string MediaName { get; set; }
        public string Type { get; set; }   // Official, Commercial website, Industrial Specific, Classfic, Social Media, Employer website,underrepresented people targeted
        public string Scope { get; set; }  // National or Local
        public float Cost { get; set; }
        public int Duration { get; set; }  // how many days the Ad will be posted
        public string Comments { get; set; }  // Comments about the media


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsPrinted { get; set; }  // Remind if the AD is printed out
        public int ProvenDuration { get; set; } // Make sure the duration is valid


    }

    public static class ExtentionMethods
    {

        public static int countryToCode(this string value)
        {

            using (CommonDataContext cd = new CommonDataContext())
            {
                return cd.tblCountries.Where(x => x.Country == value).Select(x => x.CountryCode).FirstOrDefault();


            }

        }
        public static string countryToString(this int value)
        {
            using (CommonDataContext cd = new CommonDataContext())
            {
                return cd.tblCountries.Where(x => x.CountryCode == value).Select(x => x.Country).FirstOrDefault();


            }
        }

        public static string statusCodeToName(this string code)
        {
            using (CommonDataContext cd = new CommonDataContext())
            {
                return cd.tblStatusTypes.Where(x => x.TypeCode == code).Select(x => x.StatusType).FirstOrDefault();
            }
        }
        public static string statusNameToCode(this string name)
        {
            using (CommonDataContext cd = new CommonDataContext())
            {
                return cd.tblStatusTypes.Where(x => x.StatusType == name).Select(x => x.TypeCode).FirstOrDefault();
            }
        }
        public static string genderToString(this int value)
        {
            switch (value)
            {
                case 1:
                    return "Male";

                case 2:
                    return "Female";

                default:
                    return "Unknown";
            }

        }
        public static int genderToCode(this string value)
        {
            switch (value)
            {
                case "Male":
                    return 1;

                case "Female":
                    return 2;

                default:
                    return 3;
            }
        }
    }

    public class ImageWork
    {
        public static byte[] ImageToByteArray(System.Drawing.Image imageIn, string format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                switch (format.ToUpper()) {
                    case "JPG":
                        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "PNG":
                        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case "BMP":
                        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                }
                
                return ms.ToArray();
            }
        }

        public static System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn, string format)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }
        public static Aspose.Pdf.Generator.Image ByteArrayToAsposeImage(byte[] byteArrayIn, string format)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Aspose.Pdf.Generator.Image AsposeImage = new Aspose.Pdf.Generator.Image();
                //Set the type of image using ImageFileType enumeration
                switch (format.ToUpper())
                {
                    case "JPG":
                        AsposeImage.ImageInfo.ImageFileType = Aspose.Pdf.Generator.ImageFileType.Jpeg;
                        break;
                    case "PNG":
                        AsposeImage.ImageInfo.ImageFileType = Aspose.Pdf.Generator.ImageFileType.Png;
                        break;
                    case "BMP":
                        AsposeImage.ImageInfo.ImageFileType = Aspose.Pdf.Generator.ImageFileType.Bmp;
                        break;
                }
            // Specify the image source as MemoryStream
            AsposeImage.ImageInfo.ImageStream = ms;
            return AsposeImage;
        }
    }
}




}

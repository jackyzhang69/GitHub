using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA.Immigration.Utility;
using CA.Immigration.Data;
using System.IO;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;

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

        public static string MarriageStatusIdtoString(this string MarriageId) {
            using (CommonDataContext cd = new CommonDataContext())
            {
                return cd.tblMarriageStatusTypes.Where(x => x.TypeCode == MarriageId).Select(x => x.MarriageStatusType).FirstOrDefault();
            }
        }
        public static string MarriageStatusStringtoId(this string marriagestatus)
        {
            using (CommonDataContext cd = new CommonDataContext())
            {
                return cd.tblMarriageStatusTypes.Where(x => x.MarriageStatusType == marriagestatus).Select(x => x.TypeCode).FirstOrDefault();
            }
        }
    }
    public class ImageWork
    {
        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);

                return ms.ToArray();
            }
        }

        public static System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);

                return returnImage;
            }
        }

        public static byte[] BinarytoByteArray(string input)
        {
            int numOfBytes = input.Length / 8;
            byte[] bytes = new byte[numOfBytes];
            for (int i = 0; i < numOfBytes; ++i)
            {
                bytes[i] = Convert.ToByte(input.Substring(8 * i, 8), 2);
            }
            return bytes;

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

    public static class ImageHelper
    {
        public static ImageFormat GetContentType(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes);

            using (BinaryReader br = new BinaryReader(ms))
            {
                int maxMagicBytesLength = imageFormatDecoders.Keys.OrderByDescending(x => x.Length).First().Length;

                byte[] magicBytes = new byte[maxMagicBytesLength];

                for (int i = 0; i < maxMagicBytesLength; i += 1)
                {
                    magicBytes[i] = br.ReadByte();

                    foreach (var kvPair in imageFormatDecoders)
                    {
                        if (magicBytes.StartsWith(kvPair.Key))
                        {
                            return kvPair.Value;
                        }
                    }
                }

                throw new ArgumentException("Could not recognize image format", "binaryReader");
            }
        }

        private static bool StartsWith(this byte[] thisBytes, byte[] thatBytes)
        {
            for (int i = 0; i < thatBytes.Length; i += 1)
            {
                if (thisBytes[i] != thatBytes[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static Dictionary<byte[], ImageFormat> imageFormatDecoders = new Dictionary<byte[], ImageFormat>()
    {
        { new byte[]{ 0x42, 0x4D }, ImageFormat.Bmp},
        { new byte[]{ 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 }, ImageFormat.Gif },
        { new byte[]{ 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 }, ImageFormat.Gif },
        { new byte[]{ 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, ImageFormat.Png },
        { new byte[]{ 0xff, 0xd8 }, ImageFormat.Jpeg },
    };
    }


}

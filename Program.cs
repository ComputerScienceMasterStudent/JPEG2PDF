using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace JpegToPDF
{
    class Program
    {

        public static void ConvertJpegToPdf(string imageName, string pdfName)
        {
            String currentPath = Environment.CurrentDirectory;
            string imagePath = currentPath + "\\" + imageName;
            if (File.Exists(imagePath))
            {
                Document document = new Document();
                using (var stream = new System.IO.FileStream(pdfName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();
                    using (var imageStream = new System.IO.FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        var image = Image.GetInstance(imageStream);                      
                        document.Add(image);
                    }
                    document.Close();
                }
            }
        }

        static void Main(string[] args)
        {
            String pdfName = "output.pdf";
            if(args.Length>0)
                ConvertJpegToPdf(args[0],pdfName);
        }
    }
}

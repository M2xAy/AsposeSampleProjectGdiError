using Aspose.Pdf.Devices;
using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lizenz
            var license = new Aspose.Pdf.License();
            license.SetLicense(@"License\Aspose.Total.NET.lic");

            SaveAsTiff(@"InputPdf\test.pdf", @"C:\tmp\output");
        }


        private static string SaveAsTiff(string inputFile, string outputFolder)
        {
            try
            {
                if (!File.Exists(inputFile))
                    throw new FileNotFoundException($"Die Datei {inputFile} konnte nicht gefunden werden");

                //create
                var pdfConverter = new Aspose.Pdf.Facades.PdfConverter();
                // create Resolution object with 300 as an argument
                var resolution = new Resolution(240);
                // specify the resolution value for PdfConverter object - default is 150
                pdfConverter.Resolution = resolution;
                // bind the source PDF file
                pdfConverter.BindPdf(inputFile);
                // start the conversion process
                pdfConverter.DoConvert();
                //create TiffSettings object, set Compression and ColorDepth
                var tiffSettings = new TiffSettings { Compression = CompressionType.None };

                var guid = Guid.NewGuid().ToString();
                var filepath = Path.Combine(outputFolder, $"{Path.GetFileNameWithoutExtension(guid)}.tiff");

                pdfConverter.SaveAsTIFF(filepath, tiffSettings);
                pdfConverter.Close();
                return filepath;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }
    }
}

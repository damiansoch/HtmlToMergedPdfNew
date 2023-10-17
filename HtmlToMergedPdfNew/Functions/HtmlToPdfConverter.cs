using DinkToPdf;
using iTextSharp.text.log;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;

namespace HtmlToMergedPdfNew.Functions
{
    public static class HtmlToPdfConverter
    {
        public async static Task<List<byte[]>> Convert(List<string> filesContent,IProgress<int> progress)
        {
            var allPdfFiles = new List<byte[]>();
            var counter = 0;
            foreach (var file in filesContent.Where(file => file.Length > 0))
            {
                try
                {
                    Debug.WriteLine($"Converting file {counter}");
                    var converter = new BasicConverter(new PdfTools());

                    // Convert the HTML to PDF
                    var doc = new HtmlToPdfDocument()
                    {
                        GlobalSettings = {
                        ColorMode = ColorMode.Color,
                        Orientation = DinkToPdf.Orientation.Portrait,
                        PaperSize = PaperKind.A4,
                        Margins = { Top = 30, Bottom = 20, Left = 20, Right = 20 }
                    },
                        Objects = {
                        new ObjectSettings
                        {
                            PagesCount = true,
                            HtmlContent = file.Replace("€", "&euro;"),
                            WebSettings = { MinimumFontSize = 19} // Change the font size as needed
                        }
                    }
                    };
                    // Apply CSS to adjust the margin for the first page

                    var pdfBytes = converter.Convert(doc);
                    allPdfFiles.Add(pdfBytes);
                    counter++;

                    // Report progress
                    var percentage = (int)((counter / (double)filesContent.Count) * 100);
                    progress.Report(percentage);
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error occurred when converting file {e.Message} {e.StackTrace}");
                    throw;
                }

            }
            return allPdfFiles;
        }
        public async static Task<byte[]> MergeMultiplePdfs(List<byte[]> allPdfFilesBytes,IProgress<int> progress)
        {
            using var mergedStream = new MemoryStream();
            var document = new Document();
            var copy = new PdfCopy(document, mergedStream);
            document.Open();
            var counter = 1;

            foreach (var pdfBytes in allPdfFilesBytes)
            {
                Debug.WriteLine($"Merging file {counter}");
                try
                {
                    using var pdfStream = new MemoryStream(pdfBytes);
                    var reader = new PdfReader(pdfStream);
                    var numberOfPages = reader.NumberOfPages;

                    for (var page = 1; page <= numberOfPages; page++)
                    {
                        var importedPage = copy.GetImportedPage(reader, page);
                        copy.AddPage(importedPage);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error occurred when merging file. {e.Message} {e.StackTrace}");
                    throw;
                }

                counter++;
                // Report progress
                var percentage = (int)((counter / (double)allPdfFilesBytes.Count) * 100);
                progress.Report(percentage);
            }

            document.Close();
            return mergedStream.ToArray();
        }
    }
}

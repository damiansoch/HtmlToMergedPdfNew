using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Resources;
using HtmlToMergedPdfNew.Functions;
using HtmlToMergedPdfNew.Models;
using iTextSharp.text.pdf;

namespace HtmlToMergedPdfNew
{
    public partial class Form1 : Form
    {
        private int _totalFilesSelected = 0;
        public List<UploadedFile> UploadedFiles = new();
        public Form1()
        {
            InitializeComponent();
        }

        private async void SelectFilesButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Select HTML files",
                InitialDirectory = @"C:\", // You can change this to your preferred directory
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "html", // Default file extension
                Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*", // Filter files by extension
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            UploadedFiles.Clear();
            try
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    string fileContent = File.ReadAllText(fileName);
                    // Pass filename and content to another class
                    var uploadedFile = new UploadedFile(fileName, fileContent);
                    UploadedFiles.Add(uploadedFile);
                }
                var sortedFiles = UploadedFiles.OrderBy(file =>
                {
                    var fileName = file.FileName;
                    // Use regular expressions or custom logic to extract the numerical part
                    var numericPart = new string(fileName.Where(char.IsDigit).ToArray());
                    return int.TryParse(numericPart, out var numericValue) ? numericValue :
                        // Handle cases where the filename doesn't contain a numeric part
                        int.MaxValue; // or a different default value
                }).ToList();

                UploadedFiles = sortedFiles;
                UpdateFileCountTextBox(UploadedFiles.Count);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private async void convertButton_Click(object sender, EventArgs e)
        {
            convertButton.Enabled = false;
            SelectFilesButton.Enabled = false;
            var allFileContent = UploadedFiles.Select(x => x.FileContent).ToList();
            var progress = new Progress<int>(percentage =>
            {
                // Update UI with the progress percentage
                progressTextBox.Text = $"Progress: {percentage}%";
            });
            var allPdfBytes = await HtmlToPdfConverter.Convert(allFileContent,progress);
            var mergedPdf = await HtmlToPdfConverter.MergeMultiplePdfs(allPdfBytes,progress);

            // Open a save file dialog to let the user choose the download location
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, mergedPdf);
                        Debug.WriteLine("File downloaded successfully.");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error saving the merged PDF: {ex.Message}");
                    }
                }
            }

            convertButton.Enabled = true;
            SelectFilesButton.Enabled = true;
        }

        private void UpdateFileCountTextBox(int count)
        {
            if (totalFilestextBox.InvokeRequired)
            {
                if (totalFilestextBox.IsHandleCreated)
                {
                    totalFilestextBox.Invoke(new Action(() => totalFilestextBox.Text = $"Files selected: {count}"));
                }
            }
            else
            {
                totalFilestextBox.Text = $"Files selected: {count}";
            }
        }
    }
}
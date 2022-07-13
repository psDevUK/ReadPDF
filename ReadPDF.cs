using System;
using System.Management.Automation;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
namespace ReadPDF

{
    [Cmdlet(VerbsData.Import, "PDFFile")]
    public class Program : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public string Path { get; set; }
        protected override void EndProcessing()
        {
            using (PdfDocument document = PdfDocument.Open(Path))
            {
                foreach (Page page in document.GetPages())
                {
                    string pageText = page.Text;

                    foreach (Word word in page.GetWords())
                    {
                        WriteObject(word.Text);
                    }
                }
            }

        }
    }
}

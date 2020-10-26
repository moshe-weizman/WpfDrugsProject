using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.DAL
{
    public class SaveAsPDF:IPDF
    {
        public void SavaPDF(string data)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
            gfx.DrawString(
                data, font, XBrushes.Black,
                new XRect(0, 0, page.Width, page.Height),
                XStringFormat.Center
                );
            string filename = "recept.pdf";
            document.Save(filename);
            Process.Start(filename);
        }
    }
}

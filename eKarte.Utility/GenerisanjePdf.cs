using eKarte.Models;
using eKarte.Models.ViewModels;
using IronPdf;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace eKarte.Utility
{
    public class GenerisanjePdf
    {
        public PdfDocument ConvertToDocument(IWebHostEnvironment _env, AvioKartaViewModel model)
        {


            var html = ReplaceKarta(model, _env);

            HtmlToPdf converter = new HtmlToPdf();
            converter.RenderingOptions.PaperSize = IronPdf.Rendering.PdfPaperSize.A4;
            converter.RenderingOptions.PaperOrientation = IronPdf.Rendering.PdfPaperOrientation.Landscape;
            converter.RenderingOptions.FitToPaperWidth = true;
            converter.RenderingOptions.Title = "Karta";
            PdfDocument doc = converter.RenderHtmlAsPdf(html);
            var x = doc.SaveAs(_env.WebRootPath + @"\karta.pdf");
            //Attachment a = new Attachment(_env.WebRootPath + @"\karta.pdf", "application/pdf");
            //slanje maila sa attachmentom

            doc.Dispose();
            return x;




        }
        public string ReplaceKarta(AvioKartaViewModel obj, IWebHostEnvironment _env)
        {
            string karta = string.Empty;
            karta = System.IO.File.ReadAllText(_env.WebRootPath + @"\Ticket.html");

            karta = karta.Replace("kompanija", obj.Kompanija)
                                .Replace("od", obj.Od)
                                .Replace("do", obj.Do)
                                .Replace("letid", obj.BrojLeta)
                                .Replace("ulaz", obj.Ulaz)
                                .Replace("sjediste", obj.Sjediste)
                                .Replace("ukrcavanje", obj.Ukrcavanje)
                                .Replace("email", obj.Email);
            return karta;
        }

    }
}

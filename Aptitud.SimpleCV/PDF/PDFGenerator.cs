using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using Aptitud.SimpleCV.Model;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace Aptitud.SimpleCV.PDF
{
    public class PDFGenerator
    {
        public PDFGenerator(Consultant consultant)
        {
            Consultant = consultant;
        }

        public Consultant Consultant { get; set; }
        public string ConsultantFullName()
        {
            return string.Format("{0} {1}", Consultant.FirstName, Consultant.LastName);
        }

        public void Generate()
        {

            var f = System.IO.File.OpenWrite("consultant-test.pdf");
            Generate(f);
            f.Close();
            // ...and start a viewer.
            System.Diagnostics.Process.Start("consultant-test.pdf");
        }


        public void Generate(System.IO.Stream output)
        {
            // Create a new PDF document
            var document = new Document();
            document.Info.Title = string.Format("Aptitud CV {0}", ConsultantFullName());
            document.Info.Author = ConsultantFullName();
            document.Info.Keywords = string.Format("CV, {0}", ConsultantFullName());
            document.Info.Subject = document.Info.Title;
            // Create an empty page
            var section = document.AddSection();
            // Just to create a new line
            CreateHeader(section);
            CreateSummary(section);

            CreateSubSection(section, "Programspråk", "languages");
            CreateSubSection(section, "Produk ter, Verktyg, Ramverk", "tools");
            CreateSubSection(section, "Metoder, Tekniker, Mönster", "methods");

            CreateProjectsSection(section);

            CreatePdf(document, output);
        }

        private void CreateProjectsSection(Section section)
        {
            section.AddPageBreak();
            var head = section.AddParagraph();
            Fonts.ProjectsHeadFontSpec.Apply(head.Format.Font);
            head.Format.SpaceBefore = normalSpacing * 2;
            head.Format.SpaceAfter = normalSpacing;
            head.AddText("Uppdragshistorik");

            Consultant.Projects.Each((p, i, size) =>
            {
                CreateProjectSection(section, p, i, size);
            });
        }

        private void CreateProjectSection(Section section, Project p, int i, int size)
        {
            var header = section.AddParagraph();
            Fonts.ProjectHeaderFontSpec.Apply(header.Format.Font);
            if (i > 0)
            {
                header.Format.SpaceBefore = normalSpacing * 1.5;
            }
            header.Format.SpaceAfter = normalSpacing;
            header.Format.KeepWithNext = true;
            header.Format.ClearAll();
            header.Format.AddTabStop(Unit.FromMillimeter(140), TabAlignment.Left);
            header.AddText(p.Customer);
            if (p.Name != null)
            {
                header.AddSpace(2);
                header.AddText(p.Name);
            }
            header.AddTab();
            if (p.StartDate.Year > 1 && p.EndDate.Year > 1)
            {
                header.AddText(string.Format("{0} - {1}", p.EndDate.Year, p.StartDate.Year));
            }
            else if (p.StartDate.Year > 1 && p.EndDate == DateTime.MinValue)
            {
                header.AddText(string.Format("{0} - {1}", "Pågående", p.StartDate.Year));
            }
            else if (p.EndDate.Year > 1)
            {
                header.AddText(string.Format("{0}", p.EndDate.Year));
            }


            var summary = section.AddParagraph();
            Fonts.TextFontSpec.Apply(summary.Format.Font);
            summary.AddText(p.Description);

        }

        private void CreateSubSection(Section section, string header, string skill)
        {
            if (Consultant.GetSkills(skill).ToList().Count > 0)
            {
                var headerPara = section.AddParagraph();
                headerPara.Format.SpaceBefore = normalSpacing;
                headerPara.Format.SpaceAfter = normalSpacing * 1.5;
                Fonts.H1FontSpec.Apply(headerPara.Format.Font);
                headerPara.AddText(header);
                var text = section.AddParagraph();
                text.Format.SpaceAfter = normalSpacing * 2;
                text.Format.LeftIndent = "10mm";
                Fonts.TextFontSpec.Apply(text.Format.Font);
                Consultant.GetSkills(skill).Each((skillValue, i, size) => 
                    {
                        text.AddText(skillValue);
                        if (i < size - 1) text.AddText(" ,");
                    }
                );
            }
        }
        
        const int normalSpacing = 20;

        void CreateSummary(Section section)
        {
            var summary = section.AddParagraph();
            summary.Format.SpaceBefore = normalSpacing * 2;
            summary.Format.SpaceAfter = normalSpacing;
            Fonts.SummaryFontSpec.Apply(summary.Format.Font);
            summary.AddText(Consultant.Summary);
        }

        void CreatePdf(Document document, System.IO.Stream output)
        {
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(false, PdfFontEmbedding.Automatic);
            renderer.Document = document;
            renderer.RenderDocument();
            // write the document to output...
            renderer.Save(output, false);
        }

        void CreateHeader(Section section)
        {
            var header = section.Headers.Primary.AddParagraph();
            Fonts.HeaderFontSpec.Apply(header.Format.Font);
            header.Format.Alignment = ParagraphAlignment.Center;
            //var img = header.AddImage("../../images/logo-aptitud.png");
            //img.Width = 150;
            //img.LockAspectRatio = true;
            //img.RelativeHorizontal = MigraDoc.DocumentObjectModel.Shapes.RelativeHorizontal.Page;
            //img.RelativeVertical = MigraDoc.DocumentObjectModel.Shapes.RelativeVertical.Page;
            //img.WrapFormat.Style = MigraDoc.DocumentObjectModel.Shapes.WrapStyle.Through;
            //img.WrapFormat = Shapes.WrapFormat;
            header.AddText(ConsultantFullName());
            header.AddLineBreak();
            header.AddText(string.Format("[{0}]", Consultant.Title));
        }
    }

    public class Fonts
    {
        public class FontSpec {
            public FontSpec(string name, int size, Style style)
            {
                Name = name;
                Style = style;
                Size = size;
            }
            public Style Style { get; set; }
            public string Name { get; set; }
            public int Size { get; set; }
            public void Apply(Font font) 
            {
                font.Color = Colors.Black;
                font.Name = Name;
                font.Size = Size;
                switch (Style)
                {
                    case Style.Bold: font.Bold = true; break;
                    case Style.Italic: font.Italic = true; break;
                    case Style.Regular:
                    default:
                        break;
                }
            }

        }

        public enum Style
        {
            Bold,
            Italic,
            Regular
        }
        public const string DefaultFont = "Verdana";
        public static readonly FontSpec HeaderFontSpec = new FontSpec(DefaultFont, 16, Style.Bold);
        public static readonly FontSpec SummaryFontSpec = new FontSpec(DefaultFont, 10, Style.Bold);
        public static readonly FontSpec TextFontSpec = new FontSpec(DefaultFont, 10, Style.Regular);
        public static readonly FontSpec H1FontSpec = new FontSpec(DefaultFont, 12, Style.Bold);
        public static readonly FontSpec ProjectsHeadFontSpec = new FontSpec(DefaultFont, 16, Style.Bold);
        public static readonly FontSpec ProjectHeaderFontSpec = new FontSpec(DefaultFont, 16, Style.Bold);
    }
    public class XFonts
    {
        public const string DefaultFont = "Verdana";
        public static readonly XFont HeaderFont = new XFont(DefaultFont, 24, XFontStyle.Bold);
        public static readonly XFont H1Font = new XFont(DefaultFont, 20, XFontStyle.Bold);
        public static readonly XFont IngressTextFont = new XFont(DefaultFont, 20, XFontStyle.Bold);
        public static readonly XFont TextFont = new XFont(DefaultFont, 12, XFontStyle.Regular);
    }    
}

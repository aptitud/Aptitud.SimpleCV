using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using Aptitud.SimpleCV.Model;

namespace Aptitud.SimpleCV.PDF
{
    public class Test
    {
        static void Main(string[] args)
        {
            Consultant consultant = new Consultant();
            consultant.Name = "Kalle Kula";
            consultant.Title = "Software Guru";
            consultant.EmailAddress = "kalle.kula@guruland.com";
            consultant.Summary =
                            @"Quo ut stet semper. Te mundi possim consectetuer cum, nam ex utroque accusata. Sumo alia recusabo no mei. Ne usu dictas docendi, eu vix dico commodo definitiones, est lorem facete omnium ex. In sed lorem dolore mnesarchum, est te ornatus ceteros, alii meis pertinax qui id.
                            Ad per audire luptatum. Saepe ponderum posidonium vel ea, sed te nostrud eligendi. Ne vel facilis minimum. At dolorum accumsan mentitum eam.
                            Pro ei offendit invenire pertinacia. Nec in ocurreret assentior, malis facilisis voluptatibus nam ei, id per perfecto corrumpit. Equidem facilisis assueverit no vim, praesent deterruisset an nam, vis solum debet ei. Aeterno omittantur an eum. Cu admodum voluptua sea, eam quem appetere an. Mea id animal diceret, eam et mucius tibique.
                            Id mediocrem dissentiet mea, pro quod latine no. Duo ea porro epicuri dissentiunt, ius ad nisl persecuti. Paulo vituperatoribus nec ea, pro eu purto vero offendit, omnes commodo liberavisse in eum. Quot inimicus ut eam, usu melius scriptorem theophrastus ei.
                            ";
            var skills = new List<Skill>();
            skills.Add(new Skill("C#", "languages"));
            skills.Add(new Skill("VB.NET", "languages"));
            skills.Add(new Skill("HTML", "languages"));
            skills.Add(new Skill("JavaScript", "languages"));
            skills.Add(new Skill("T-SQL", "languages"));
            skills.Add(new Skill("XSD", "languages"));

            skills.Add(new Skill(".Net Framwork", "tools"));
            skills.Add(new Skill("ASP.NET", "tools"));
            skills.Add(new Skill("WCF", "tools"));
            skills.Add(new Skill("WPF", "tools"));
            skills.Add(new Skill("Visual Studio 20xx", "tools"));

            skills.Add(new Skill("Scrum", "methods"));
            skills.Add(new Skill("Kanban", "methods"));
            skills.Add(new Skill("BDD", "methods"));
            skills.Add(new Skill("TDD", "methods"));
            skills.Add(new Skill("SBD", "methods"));
            skills.Add(new Skill("DDD", "methods"));

            consultant.Skills = skills;

            var projects = new List<Project>();
            projects.Add(new Project("H&M", null, 
                                            @"Quo ut stet semper. Te mundi possim consectetuer cum, nam ex utroque accusata. Sumo alia recusabo no mei. Ne usu dictas docendi, eu vix dico commodo definitiones, est lorem facete omnium ex. In sed lorem dolore mnesarchum, est te ornatus ceteros, alii meis pertinax qui id.
                            Ad per audire luptatum. Saepe ponderum posidonium vel ea, sed te nostrud eligendi. Ne vel facilis minimum. At dolorum accumsan mentitum eam.",
                            new DateTime(2013, 6, 1)));

            projects.Add(new Project("Länsförsäkringar Liv", "ProjektNamn",
                                            @"Quo ut stet semper. Te mundi possim consectetuer cum, nam ex utroque accusata. Sumo alia recusabo no mei. Ne usu dictas docendi, eu vix dico commodo definitiones, est lorem facete omnium ex. In sed lorem dolore mnesarchum, est te ornatus ceteros, alii meis pertinax qui id.
                            Ad per audire luptatum. Saepe ponderum posidonium vel ea, sed te nostrud eligendi. Ne vel facilis minimum. At dolorum accumsan mentitum eam.",
                            new DateTime(2012, 6, 1)));

            projects.Add(new Project("Apoteket", null,
                                            @"Quo ut stet semper. Te mundi possim consectetuer cum, nam ex utroque accusata. Sumo alia recusabo no mei. Ne usu dictas docendi, eu vix dico commodo definitiones, est lorem facete omnium ex. In sed lorem dolore mnesarchum, est te ornatus ceteros, alii meis pertinax qui id.
                            Ad per audire luptatum. Saepe ponderum posidonium vel ea, sed te nostrud eligendi. Ne vel facilis minimum. At dolorum accumsan mentitum eam.",
                            new DateTime(2010, 4, 1)));
                
            consultant.Projects = projects;
            new Aptitud.SimpleCV.PDF.PDFGenerator(consultant).Generate();
        }
    }
}

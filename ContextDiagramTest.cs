using System.IO;
using Hypercube.C4;
using Hypercube.C4.Diagrams;
using Hypercube.C4.Puml;
using Hypercube.C4.Relationships;
using Xunit;
using static Hypercube.Tests.C4Model.Persons;
using static Hypercube.Tests.C4Model.Systems;

namespace Hypercube.Tests.C4Model.Samples
{
    public class ContextDiagramTest
    {
        [Fact]
        public void Its_C4_Model_Context_Diagram()
        {
            var diagram = new ContextDiagram
            {
                Title = "System Context diagram for Internet Banking System",
                Structures = new Structure[]
                {
                    Customer,
                    BankingSystem,
                    Mainframe,
                    MailSystem
                },
                Relationships = new Relationship[]
                {
                    new Relationship(Customer, BankingSystem, "Uses"),
                    new RelateBack(Customer, MailSystem, "Sends e-mails to"),
                    new RelateNeighbor(BankingSystem, MailSystem, "Sends e-mails", "SMTP"),
                    new Relationship(BankingSystem, Mainframe, "Uses"),
                }
            };

            PumlFile.Save(diagram);
            PumlFile.ExportToPng(diagram);
            
            Assert.True(File.Exists($"c4/{diagram.Slug()}.puml"));
        }        
    }
}
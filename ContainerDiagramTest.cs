using System.IO;
using Hypercube.C4;
using Hypercube.C4.Diagrams;
using Hypercube.C4.Puml;
using Hypercube.C4.Relationships;
using Xunit;
using static Hypercube.Tests.C4Model.Persons;
using static Hypercube.Tests.C4Model.Systems;
using static Hypercube.Tests.C4Model.Containers;


namespace Hypercube.Tests.C4Model.Samples
{
    public class ContainerDiagramTest
    {
        [Fact]
        public void Its_C4_Model_Container_Diagram_Test()
        {
            var diagram = new ContainerDiagram
            {
                Title = "Container diagram for Internet Banking System",
                Structures = new Structure[]
                {
                    Customer,
                    new SoftwareSystemBoundary("c1", "Internet Banking", new[]
                    {
                        WebApp,
                        Spa,
                        MobileApp,
                        Database,
                        BackendApi
                    }),
                    BankingSystem,
                    MailSystem,
                },
                Relationships = new Relationship[]
                {
                    new Relationship(Customer, WebApp, "Uses", "HTTPS"),
                    new Relationship(Customer, Spa, "Uses", "HTTPS"),
                    new Relationship(Customer, MobileApp, "Uses"),

                    new RelateNeighbor(WebApp, Spa, "Delivers"),
                    new Relationship(Spa, BackendApi, "Uses", "async, JSON/HTTPS"),
                    new Relationship(MobileApp, BackendApi, "Uses", "async, JSON/HTTPS"),
                    new RelateBackNeighbor(Database, BackendApi, "Reads from and writes to", "sync, JDBC"),

                    new RelateBack(Customer, MailSystem, "Sends e-mails to"),
                    new RelateBack(MailSystem, BackendApi, "Sends e-mails using", "sync, SMTP"),
                    new RelateNeighbor(BackendApi, BankingSystem, "Uses", "sync/async, XML/HTTPS")                    
                }
            };

            PumlFile.Save(diagram);
            PumlFile.ExportToPng(diagram);

            Assert.True(File.Exists($"c4/{diagram.Slug()}.puml"));            
        }        
    }
}
using System.Collections.Generic;
using System.IO;
using Hypercube.C4.Diagrams;
using Hypercube.C4.Puml;
using Hypercube.C4.Relationships;
using Xunit;
using static Hypercube.Tests.C4Model.Components;
using static Hypercube.Tests.C4Model.Containers;
using static Hypercube.Tests.C4Model.Systems;


namespace Hypercube.Tests.C4Model.Samples
{
    public class ComponentDiagramTest
    {
        [Fact]
        public void Its_C4_Model_Component_Diagram_Test()
        {
            var boundary = new C4.ContainerBoundary("c1", "API Application", new[]
                {
                    Sign,
                    Accounts,
                    Security,
                    MainframeFacade
                },
                new Relationship[]
                {
                    new Relationship(Sign, Security, "Uses"),
                    new Relationship(Accounts, MainframeFacade, "Uses"),
                    new Relationship(Security, Database, "Read & write to", "JDBC"),
                    new Relationship(MainframeFacade, Mainframe, "Uses", "XML/HTTPS")                    
                }
            );
            
            
            var diagram = new ComponentDiagram()
            {
                Title = "Component diagram for Internet Banking System - API Application",
                Structures = new C4.Structure[]
                {
                    Spa,
                    MobileApp,
                    Database,
                    Mainframe,
                    boundary,
                },
                Relationships = new Relationship[]
                {
                    new Relationship(Spa, Sign, "Uses", "JSON/HTTPS"),
                    new Relationship(Spa, Accounts, "Uses", "JSON/HTTPS"),

                    new Relationship(MobileApp, Sign, "Uses", "JSON/HTTPS"),
                    new Relationship(MobileApp, Accounts, "Uses", "JSON/HTTPS")
                }
            };
            
            PumlFile.Save(diagram);
            PumlFile.ExportToPng(diagram);
            
            Assert.True(File.Exists($"c4/{diagram.Slug()}.puml"));
        }
    }
}
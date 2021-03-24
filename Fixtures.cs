using Hypercube.C4;

namespace Hypercube.Tests.C4Model
{
    public static class Persons
    {
        public static C4.Person Customer => new(
            alias: "customer",
            label: "Personal Banking Customer",
            description: "A customer of the bank, with personal bank accounts."
        );
    }

    public static class Systems
    {
        public static C4.SoftwareSystem BankingSystem => new(
            alias: "BankingSystem",
            label: "Internet Banking System",
            description: "Allows customers to view information about their bank accounts, and make payments."
        );

        public static C4.SoftwareSystem Mainframe => new(
            alias: "Mainframe",
            label: "Mainframe Banking System",
            description: "Stores all of the core banking information about customers, accounts, transactions, etc.",
            softwareSystemType: C4.SoftwareSystemType.External
        );

        public static C4.SoftwareSystem MailSystem => new(
            alias: "MailSystem",
            label: "E-mail system",
            description: "The internal Microsoft Exchange e-mail system.",
            softwareSystemType: C4.SoftwareSystemType.External
        );

        public static C4.SoftwareSystem Zabbix => new(
            alias: "Zabbix",
            label: "Zabbix",
            description: "enterprise-level platform to monitor large-scale IT environments",
            softwareSystemType: C4.SoftwareSystemType.External
        );
    }

    public static class Containers
    {
        public static C4.Container WebApp => new(
            alias: "WebApp",
            type: C4.ContainerType.WebApplication,
            description: "Delivers the static content and the Internet banking SPA",
            technology: "C#, WebApi"
        );

        public static C4.Container Spa => new(
            alias: "Spa",
            type: ContainerType.Spa,
            description: "Provides all the Internet banking functionality to cutomers via their web browser",
            technology: "JavaScript, Angular"
        );
        
        public static C4.Container MobileApp => new(
            alias: "MobileApp",
            type: ContainerType.Mobile,
            description: "Provides a limited subset of the Internet banking functionality to customers via their mobile device",
            technology: "C#, Xamarin"
        );        
        
        public static C4.Container Database => new(
            alias: "Database",
            type: ContainerType.Database,
            description: "Stores user registration information, hashed auth credentials, access logs, etc.",
            technology: "SQL Database"
        );      
        
        public static C4.Container BackendApi => new(
            alias: "BackendApi",
            type: ContainerType.Api,
            description: "Provides Internet banking functionality via API.",
            technology: "Dotnet, Docker Container"
        );          
    }

    public static class Components
    {
        public static C4.Component Sign => new(
            alias: "sign",
            label: "Sign In Controller",
            description: "Allows users to sign in to the internet banking system",
            technology: "MVC Rest Controller"
        );

        public static C4.Component Accounts => new(
            alias: "accounts",
            label: "Accounts Summary Controller",
            description: "Provides customers with a summary of their bank accounts",
            technology: "MVC Rest Controller"
        );

        public static C4.Component Security => new(
            alias: "security",
            label: "Security Component",
            description: "Provides functionality related to singing in, changing passwords, etc.",
            technology: "Spring Bean"
        );

        public static C4.Component MainframeFacade => new(
            alias: "mbsfacade",
            label: "Mainframe Banking System Facade",
            description: "A facade onto the mainframe banking system.",
            technology: "C#, Class Library"
        );
    }
}
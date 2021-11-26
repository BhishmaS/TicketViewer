# Ticket Viewer Application (.NET Core 5.0)
To view tickets raised by clients with the help of 3rd party integrations in SAAS products.

**Name: Bhishma Sukhavasi**  
**Email: bhishma.sukhavasi@gmail.com**

## Tech Stack
**Framework:** .NET 5.0, ASP.NET Core  
**Programming Languages:** C#, JavaScript, HTML, CSS  
**Unit Testing:** xUnit.net  
**Third party libraries:** AutoMapper(10.1.1) Nuget, Newtonsoft.Json(13.0.1) Nuget

## Application local setup

Is .NET only for windows machines?  
**Well it used to be, but the latest versions of .NET entirely build again as ".NET Core" given cross-platform support (Yes this is too WORA)**

Is Application Setup using .NET a complex process?  
**No, not at all. Just follow few simple steps given below**

### Steps: 
- **Download & Install Visual Studio IDE**  
For Windows (Visual Studio Community Version): https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=17  
For Mac: https://visualstudio.microsoft.com/vs/mac/  
**Installation:**  
<img src="images/dot-net-installation.jpeg" width="500">

- **Download & Install .NET 5 SDK based on your OS**  
.NET 5 SDK: https://dotnet.microsoft.com/download/dotnet/5.0  
**Installation:**  
<img src="images/dot-net5-sdk.jpeg" width="400">

- Visual studio install guide for reference: https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2022

- **Clone the Repo:** https://github.com/BhishmaS/TicketViewer.git

- Now Open the Solution **TicketViewer.sln** using visual studio from the root directory of the project.  
<img src="images/solution-open.jpeg" width="400"> 

- All the required project nugut dependencies will be automatically restored or else you can restore as shown below.  
<img src="images/nuget-restore.jpeg" width="400"> 

## Running the application

- By default web app will be startup a project if not, update that as shown below:  
    <img src="images/project-startup.jpg" width="400" height="250"> 

- **Authentication:**  
Both "TokenBased" & "Basic" authentication are supported.
Go To: **appsettings.json** in **TicketViewer.App.Web**

    ```JSON
    {
    "ZendeskSubdomainName": "zccbsportive.zendesk.com",
    "ZendeskAuthType": "TokenBased", // Values: "Basic", "TokenBased"
    "ZendeskAccessToken": "__ZendeskAccessToken__",
    "ZendeskUsername": "__ZendeskUsername__",
    "ZendeskPassword": "__ZendeskPassword__",
    "AllowedHosts": "*"
    }
    ```
    - By default authentication type is "TokenBased".  
    Provide "access token" value for "ZendeskAccessToken" in the above JSON file.
    
    - If is you want Basic Authentication, change "ZendeskAuthType" value to "Basic".  
    Provide "username" and "password" values for "ZendeskUsername", "ZendeskPassword" in the above JSON file.  
    
    <img src="images/app-settings.jpg" width="200"> 
  
- **Run the application**  
    <img src="images/app-run.jpeg" width="500"> 

## Application Design
class diagrams

not using CLI so removed from the solution

can even integrate with mobile app by simple createing enw mobile and using these stand alone class libraries

each class library explain

## Ticket List

<img src="images/ticket-list.jpg">

## Ticket Details

<img src="images/ticket-details.jpg">

## Unit Tests

Used xUnit.net for unit tests

- ### Authentication Setup:  
    Same as for the application, go to **appsettings.json** in **TicketViewer.Tests** and update the auth values.

    <img src="images/tets-app-settings.jpg" width="350">

- To run unit tests go to **TestExplorer** in Visual Studio and run them from that window.

    <img src="images/tests-explorer.jpg" width="350">

- ### Tests Run
    <img src="images/unit-tests.jpg" width="350">


## Crowdience 

 

Crowdience is a take on the traditional ‘Mr & Mrs’ game, often played at a wedding.  

  There is: 

+ A **Host**, who controls the game. 

+ A **Couple**, who are the subject of the questions. 

+ **Audience** members, who vote on one member of the couple for each question. 
  
---

  **How to Use:** 

The game is hosted on Microsoft Azure Services. 

Simply by going onto the home page, you are presented with playing as either the *host*, part of a *couple*, or as an audience *player*.  

Nothing is required to download the game and can be played simply with a device and internet connection. 

--- 

  **Tech Stack used:**

We had a task to create a C# web app. Starting off with a .Net Core Framework on Visual Studio Code, we found SignalR would enable real-time interaction with multiple users. We used Entity Framework Core (EF Core) as an Object Relational Mapper (ORM) to enable functions to use our PostgreSQL database.  

|     Front-End         |     Database          |     Back-End          |       Hosting          |
| --------------------- | --------------------- | --------------------- | ---------------------  |
|       Javascript      | Entity Framework Core |      ASP.Net Core     |         Docker         |
|       Razor Pages     |      PostgreSQL       |      SignalR          |Microsoft Azure Services|

---

 **Our Approach:**  

We wanted a project that had a fine balance beteen a challence, and achievability.
8 days to create an app, which showcased 12 weeks of learning. Within a couple of days we had our idea, but didn't fully know how to implement it.

We had built Single Page Applications (SPA) and Model-View-Controller (MVC) applications and only once had interaction with the C# language. Using EF Core, SignalR and Javascript were relatively straight forward. Using them all in tandem was far more challenging.

By the end of the first week, we essentially had a single page Javascript app in Visual Studio Code, using a SignalR library enabling players to cast votes, which appeared on a different screen.

Agile Process: Daily sprints with a stand-up in the morning and retro each afternoon.

  **MVP & Functionalities:**

Our Minimal Viable Product (MVP)


 

  **Team:**

+ Alex Hutchings 

+ John Haythorn 

+ Paul Ayling 

+ Saule Guzyte 

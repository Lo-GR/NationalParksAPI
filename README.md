# <div align="center"> **National Parks API** </div>
### This is a National Parks API using full CRUD for State and Parks

 ### _Contributor(s) and Contact Info_
> Logan Roth diamondintheroth@gmail.com - [GitHub(Lo-GR)](https://github.com/Lo-GR)

---

## _Technologies Used_ ⚙

* **C# 9**
* **.NET 5.0.102**
* **SDK 8.0.19**
* **My SQL 8.0.19/WorkBench 8.0.19**
* **Entity Framework**
* **MVC.ApiVersioning 5**
* **Swagger 3.0**


## _Concepts Used_ 🧠

* **RESTful Conventions**
* **CRUD Functionality**
* **Database Retrieval/Storage**
* **API Development**
* **API Versioning**

---

## _Description_ 📃
This project is a demo API. It includes full CRUD for Parks and State objects for displaying an API. All parks are assigned a State for a many to one relationship and includes the ability to pull all parks with states. See API Use for further details.

---

## _Installation Guide_ 💻 

<details>
<summary>Open for full Guide</summary>

### _Cloning and Initial Setup_

> Repository: https://github.com/Lo-GR/NationalParksAPI.Solution.git
1. In your terminal of choice or [GitHub's Desktop Application](https://desktop.github.com/), clone the above repository from Github. For further explanation on how to clone this repository, please visit [GitHub's Documentation](https://docs.github.com/en/github/using-git/which-remote-url-should-i-use).
2. Ensure you are running .NET Core SDK by using the command dotnet --version in your terminal. If a version number is not presented, please visit [this download page for .NET 5 and install the applicable software for your OS](https://dotnet.microsoft.com/download/dotnet/5.0). 
3. Once you verify you are running a .NET 5, navigate in your terminal to NationalParksAPI directory within the NationalParksAPI.Solution directory you just cloned. Once there, run "dotnet build" in your terminal to build application within directory. 
4. You will require a text or code editor to complete the following steps. [VS Code is recommended](https://code.visualstudio.com/)
5. (optional)If changes to packages are required, add respective packages to csproj then run "dotnet restore." Also good for troubleshooting.


### _Installation: Database Recreation_

1. Ensure you are running MySQL Server 8 and MySQL WorkBench 8. If you are running windows, use the [Windows Installer ](https://dev.mysql.com/downloads/installer/) for MySQL and follow the instructions provided by the installer. For Macs, visit [MySQL Community Downloads](https://dev.mysql.com/downloads/mysql/) and select macOS from the Operation Systems. This will be a manual installation. If you need additional assistance on this, please visit Epicodus's [Learn How to Program Article](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql).
2. Once you verify you have SQL installed, create a file called "appsettings.json" in the project directory NationalParksAPI. Paste the following into this file. Replace bracketed PORT OF CHOICE and PASSWORD OF CHOICE with ports and password set up during MySQL installation.
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port={PORT OF CHOICE};database=nationalparksapi;uid=root;pwd={PASSWORD OF CHOICE};"
  }
}
```
3. In the production directory "NationalParksAPI", run "dotnet ef database update" in your terminal.

</details>

---

## _API Use Guide_ ⌨

<details>
<summary>Open for full Guide</summary>

### _API: Getting Started_

Note: This API will launch swagger upon launching the server. Swagger will provide a GUI for endpoints on this api. You can also use [Postman](https://www.postman.com/) to practice endpoints on this API.

1. Back in your terminal in the NationalParksAPI production directory, type "dotnet run." The terminal will present local host routes for your dedicated API link. An example would be "http://localhost:5000." It will also launch Swagger in your default browser.
2. Keep the terminal running as it is being used to control the local server. When finished, exit the terminal or use the command "CTRL C"(Windows) or "CMD C"(Mac) to shut down the local server.
3. The following is the baseline of the link.
```
https://localhost:5001/api/{version #}/{parks OR states}
```
Note: This API includes versioning. In order to access endpoints, a specific version number must be entered in the URL.

### **API End Points: Parks**

Example Return Value
```
[
  {
    "parkId": 0,
    "name": "string",
    "distance": 0,
    "established": "string",
    "imageURL": "string",
    "stateId": 0
  }
]
```

### _Get All Parks EndPoint_
```
https://localhost:5001/api/1/Parks
```
This link will pull a full list of all messages available in database. The first 3 IDs are seeded. This route is queryable. Please see the below table for query options.

| Parameter | Type | Description | Example |
| :------------- | :------------- | :------------ | :-------------: |
| name | string | Search for parks containing the argument | ?name=rocky | 

### _Get Park by ID EndPoint_
```
https://localhost:5001/api/1/Parks/{id}
```
Returns a specific Park by ID number. 

### _Post(Create) Park by EndPoint_
```
https://localhost:5001/api/1/Parks/create/{ID of State Park is in}
```
This API will post a new park based on the requirement values below. I opted to push the State ID through the URL in order to avoid conflicts with foreign keys not being included. See below for example of values that can be entered.
```
{
  "name": "string",
  "distance": 0,
  "established": "test",
  "imageURL": null,{OPTIONAL}
}
```

### _Put(Edit) Park by EndPoint_
```
https://localhost:5001/api/1/Parks/{Park ID you'd like to edit}
```
Edit a park entry. All values are recommended to be included in the update. Returns no Response from server. See below for example:

```
{
  "parkId": 8,
  "name": "string",
  "distance": 0,
  "established": "string",
  "imageURL": "string",
  "stateId": 1
}
```

### _Delete Park by EndPoint_
```
https://localhost:5001/api/1/Parks/{ID of park to delete}
```
Delete a park by ID entered. Returns no response.

### **API End Points: States**
Example Return Value
```

```
**Get all Endpoint** 
```
http://localhost:5000/api/groups
```
This link will pull a full list of all groups available in database, along with messages linked to those groups.

**Create a group Endpoint**
```
http://localhost:5000/api/groups
```

Example of body for Post endpoint

```
{
  "name": "NAME OF GROUP",
}
```

**Get group by ID Endpoint**
```
http://localhost:5000/api/groups/id
```
where `id` is the integer value of that message


### _Query Parameters: Messages_

| Parameter | Type | Description | Example |
| :------------- | :------------- | :------------ | :-------------: |
| title | string | Search messages for title containing parameter | ?title=taco | 
| user | string | Search messages for specific usernames | ?user=kirbypaint|
| searchDate | YYYY-MM-DD | Search messages posted on specific date | ?searchDate=2021-01-02|
| startDate | YYYY-MM-DD | Search messages posted after and on specific date | ?startDate=2021-01-02|
| endDate | YYYY-MM-DD | Search messages posted before and on specific date | ?endDate=2021-01-02|
| startDate + endDate | YYYY-MM-DD | Search messages posted between start and end date | ?startDate=2020-01-02&endDate=2021-01-02|
| body | string | Search messages for body containing parameter | ?body=strangers | 

_Example_
```
http://localhost:5000/api/messages?searchDate=2021-01-13
```

### _Query Parameters: Groups_

| Parameter | Type | Description | Example |
| :------------- | :------------- | :------------ | :-------------: |
| name | string | Search groups for name | ?name=tacofans | 

_Example_
```
http://localhost:5000/api/groups?name=tacofans
```

</details>

---

## _Known Bugs_ 🩹
* No known bugs at this time. Please contact a contributor to report any bugs found during use.

---

## _Future Updates_ 🛠
* Front End Example

---

## _Preplanning/Whiteboard Work_ 📋
```
Expectations___
1. As a user, I want to be able to GET all messages related to a specific group.
2. As a user, I want to be able to POST messages to a specific group.
3. As a user, I want to be able to see a list of all groups.
4. As a user, I want to input date parameters and retrieve only messages posted during that timeframe.
5. As a user, I want to be able to PUT and DELETE messages, but only if I wrote them. (Start by requiring a user_name param to match the user_name of the author on the message. You can always try authentication later.)

API Functionality___
1. Make GET and POST routes for messages
  - Get route allows for all messages of group
  - Search Routes/Params for Get routes
2. PUT and DELETE route for messages.
3. Message Class
  - Title of Message
  - Body 
  - Date of Posting
  - User property for identity
  - Image URL
4. Identity implementation
5. ApplicationUser Class  
  - The whole identity sheabang
6. Solid README for those picking up api

Stretch Goal Ideas____
1. Replies class, one to many relationship to Message class

Frontend Functionality___
1. See list of all groups
```
---

## _License_ ⚖️

[![MIT license](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)

Copyright (c) 2021, Logan Roth, Ash Porter.

Please contact Contributor for further use information or if you would like to make a contribution.
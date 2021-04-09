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
NOTE: Distance is intended to be measured in acres.

### _Get All Parks EndPoint_ 🔵
```
https://localhost:5001/api/1/Parks
```
This link will pull a full list of all parks available in database. The first 3 IDs are seeded. This route is queryable. Please see the below table for query options.

| Parameter | Type | Description | Example |
| :------------- | :------------- | :------------ | :-------------: |
| name | string | Search for park names containing the argument | ?name=rocky | 

### _Get Park by ID EndPoint_ 🔵
```
https://localhost:5001/api/1/Parks/{id}
```
Returns a specific Park by ID number. 

### _Post(Create) Park by EndPoint_ 🟢
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

### _Put(Edit) Park by EndPoint_ 🟠
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

### _Delete Park by EndPoint_ 🔴
```
https://localhost:5001/api/1/Parks/{ID of park to delete}
```
Delete a park by ID entered. Returns no response.

### **API End Points: States**
Example Return Value
```
[
  {
    "stateId": 0,
    "name": "string",
    "region": "string",
    "parks": [
      {
        "parkId": 0,
        "name": "string",
        "distance": 0,
        "established": "string",
        "imageURL": "string",
        "stateId": 0
      }
    ]
  }
]
```
### _Get all States by EndPoint_ 🔵
```
https://localhost:5001/api/1/States
```
This link will pull a full list of all states and their corresponding parks available in database. The first 3 IDs are seeded. This route is queryable. Please see the below table for query options.

| Parameter | Type | Description | Example |
| :------------- | :------------- | :------------ | :-------------: |
| name | string | Search for state names containing the argument | ?name=colorado | 
| region | string | Search for state regions containing the argument | ?region=mountain | 

### _Get State by ID EndPoint_ 🔵
```
https://localhost:5001/api/1/States/{id}
```
Returns a specific State by ID number. 

### _Post(Create) State by EndPoint_ 🟢
```
https://localhost:5001/api/1/States/
```
This API will post a new state based on the requirement values below. See below for example of values that can be entered.
```
{
  "name": "string",
  "region": "string"
}
```

### _Put(Edit) States by EndPoint_ 🟠
```
https://localhost:5001/api/1/States/{State ID you'd like to edit}
```
Edit a State entry. All values are recommended to be included in the update except parks. Returns no Response from server. See below for example:

```
{
  "stateId": 0,
  "name": "string",
  "region": "string",
}
```

### _Delete State by EndPoint_ 🔴
```
https://localhost:5001/api/1/States/{ID of state to delete}
```
Delete a state by ID entered. Returns no response.

</details>

---

## _Known Bugs_ 🩹
* No known bugs at this time. Please contact a contributor to report any bugs found during use.

---

## _Future Updates_ 🛠
* Front End Example
* A random Query
* An additional version (2.0) with extended features.

---

## _Preplanning/Whiteboard Work_ 📋
```
Expectations___
1. Return API of states and national parks. Full CRUD of both. 
2. Further exploration of one of the following objectives: authentication, versioning, pagination, Swagger documentation, or CORS.

API Functionality___
1. States Class
  - Name
  - Region
2. Parks
  - Name
  - Distance (in acres)
  - Established (DateTime?)
3. Further Exploration topics to consider, Swagger, Authentication, pagination.
  - Research for pagination: 
    - https://www.youtube.com/watch?v=cKj6U4qDmgQ
    - https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/nerddinner/implement-efficient-data-paging
  - Research for versioning:
    -https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Versioning/
    - https://neelbhatt.com/2018/04/21/api-versioning-in-net-core/
    -https://dev.to/99darshan/restful-web-api-versioning-with-asp-net-core-1e8g

```
---

## _License_ ⚖️

[![MIT license](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)

Copyright (c) 2021, Logan Roth.

Please contact Contributor for further use information or if you would like to make a contribution.

# ASP.NET MVC InterviewSystem

## Project Description

A system for proceeding interviews should be implemented. It should allow candidates to take a test for a new job by answering several predefined questions. After submitting the test they should see their passed/failed result. 

## General Requirements

###Roles
* HR role - administer candidate's profile [requires authentication]
* Senior developer  - add questions to the repository [requires authentication]
* Technical lead - generate tests for a specific candidate by providing an unique key [requires authentication]
* Support - response candidate's needs (if contacted)
* Candidate - open a test by an unique key, answer questions; communicate runtime with the support (if needed)

###Questions
Each question should have **category** (.NET, Java, PHP, HTML, CSS, JavaScript), **level** (Beginner, Intermediate, Advanced), **weight** (ex. 0.1, 0.2, 0.3, ... etc.), **possible correct answers** (one or many)

## Technical Requirements

* Use **Razor** template engine for generating the UI
* Use **MS SQL Server** as database back-end
* Create beautiful and responsive UI
* Use the standard **ASP.NET Identity System** for managing users and roles
* Use **AJAX** form and/or **SignalR** communication 
* Use **caching** of data where it makes sense (e.g. starting page)
* Use **Ninject** (or any other dependency container) and **Automapper**
* Write at least 30 **unit tests** for your logic, controllers, actions, helpers, routes, etc.
* Apply **error handling** and **data validation** to avoid crashes when invalid data is entered (both client-side and server-side)
* Prevent yourself from **security** holes (XSS, XSRF, Parameter Tampering, etc.)
* Implement **routing** mechanism
* Make the application compatible with **mobile** devices

# _Hair Salon_

#### _A web app for a hair salon, Aug 18, 2017_

#### By _**Charlie Kelson**_

## Description

_This web app will allow a hair salon owner to add a list of stylist, and for each stylist, add clients who see that stylist. The stylists work independently, so each client only belongs to a single stylist._


### User Story

| User Behavior | Input | Output |
|----|----|----|  
| As a salon employee, I need to be able to see a list of all our stylists. | Stylist | Stylist list |
| As an employee, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist. | Click stylist name | Stylist details with list of clients|
| As an employee, I need to add new stylists to our system when they are hired. | Add stylist | List of stylist |
| As an employee, I need to be able to add new clients to a specific stylist. | Add client | Client list on stylist page|
| As an employee, I need to be able to update a client's name. | Update new client name | New client name in client list under specific stylist|
| As an employee, I need to be able to delete a client if they no longer visit our salon. | User clicks delete button| Client is deleted|



### Technical Specs

| App Behavior | Expected | Actual |
|----|----|----|  
|  Get all stylists at first position in database | 0 | Database List<Stylist> count start at 0 |
|  Save stylist to database|  Local List<stylist> = {Becky, 1}  | Database List<stylist> = {Becky, 1}   |
|  Find stylist from database by id|  Crystal  |  Crystal  |
| Get all clients at first position in database | 0 | Database List<Stylist> count start at 0|
|  Save client to database | List with one client: Sarah | List with one client: Sarah |
|  Find client from database by id| Raymond  |  Raymond  |
|  Get all clients of a specific Stylist by stylist_id|  Local client list  |  Database Client list matches local client list  |
|  Update clients name | David | David |
|  Delete client |A list of only one client rather than two | A database query that only returns one client after delete method has been called |


## Setup/Installation Requirements

* _Clone repo and set up .NET dependencies to view locally_
* _Configure MySQL database with MAMP and recreate database with instructions below_
---

#### MySQL commands to create database
- `CREATE DATABASE hair_salon;`
- `USE hair_salon;`
- `CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));`
- `CREATE TABLE clients (id serial PRIMARY KEY, description VARCHAR(255), stylist_id INT);`

---

## Known Bugs

_No known Bugs_



## Technologies Used

* _ASP.NET MVC_
* MySQL

### License

MIT License

Copyright (c) 2015 **_Charlie Kelson_**

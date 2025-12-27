This project is a .NET 8 Web API designed to ingest large CSV-based historical sales data, persist it efficiently using RavenDB, and expose RESTful APIs for analytical queries.

The solution emphasizes:

Scalability for millions of records

Clean domain-driven design

Efficient bulk ingestion

Production-grade API design

Architecture Overview
API (Controllers)
│
├── Application Layer
│   ├── Services (Data Refresh, Revenue Calculation)
│   └── Interfaces (Repositories)
│
├── Infrastructure Layer
│   ├── CSV Importer
│   ├── RavenDB Repositories
│   └── Document Store Configuration
│
└── Domain Layer
    ├── Order
    ├── Product
    └── Customer

Database Design (RavenDB)
Collections Used
Collection	Purpose
Orders	Stores transactional sales data
Products	Stores unique product information
Customers	Stores unique customer information
Design Notes

Each entity is stored as a separate document

Relationships are maintained via IDs (normalized model)

RavenDB document IDs follow predictable patterns:

orders/{orderId}

products/{productId}

customers/{customerId}

Data Refresh Strategy

CSV ingestion is triggered via an API endpoint

Uses RavenDB BulkInsert for high-performance writes

Supports on-demand refresh

Safe to re-run (idempotent document IDs)

 API Endpoints
API Table
API Name	Method	Route	Request	Response	Description
Upload & Refresh Data	POST	/api/data-refresh	multipart/form-data (CSV file)	{ "message": "Data refresh completed" }	Ingests CSV data into RavenDB
Get Total Revenue	GET	/api/revenue/total	fromDate, toDate (query params)	{ "totalRevenue": 123456.78 }	Calculates total revenue for date range
Health Check	GET	/swagger	—	Swagger UI	API documentation
 API Usage Examples
Upload CSV & Refresh Data

Endpoint

POST /api/data-refresh


Request

Content-Type: multipart/form-data

Field name: file

File type: .csv

Response

{
  "message": "Data refresh completed successfully"
}

Get Total Revenue

Endpoint

GET /api/revenue/total?fromDate=2024-01-01&toDate=2024-12-31


Response

{
  "totalRevenue": 92344.32
}


Revenue Formula

(quantity × unit price × (1 - discount)) + shipping cost

 Testing & Validation

APIs tested via Swagger UI

CSV validation handled during parsing

Invalid rows are skipped safely

Date range filtering verified

Prerequisites
Tool	Version
.NET SDK	8.0+
RavenDB	6.x (Local)
IDE	Visual Studio 2022
 How to Run the Project

Start RavenDB
http://localhost:8085


Create database:

lumel_assignment_db

Run the API
dotnet restore
dotnet build
dotnet run


API URL:

https://localhost:7233

Open Swagger
https://localhost:7233/swagger

Project Structure
Lumel_BackendAssessment
│
├── Controllers
├── Application
│   ├── Interfaces
│   └── Services
├── Domain
│   └── Entities
├── Infrastructure
│   ├── Csv
│   ├── Repositories
│   └── RavenDb
└── README.md

Design Decisions (Interview Highlights)

BulkInsert used instead of sessions for ingestion

Clean separation of concerns (CSV notequal Domain notequal DB)

RavenDB chosen for schema flexibility & performance

Normalized domain model for analytical clarity

REST APIs designed for extensibility


Ezhilarasan Chandrasekaran
Senior / Lead Backend Engineer
.NET | Distributed Systems | Data Engineering
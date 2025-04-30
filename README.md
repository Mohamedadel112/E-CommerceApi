<h1>📌 Project Name: </h1>
E-Commerce Food Ordering System – ASP.NET Core Web APIs

<h1> Project Description:</h1>
A robust and secure E-Commerce backend system for managing food products, built using ASP.NET Core Web APIs, supporting:

Full CRUD operations on Products, Basket, and Orders

Initial data setup using Data Seeding

The project follows Onion Architecture with clean separation of responsibilities across 4 main layers:

Domain Layer – Contains business entities and contracts in a dedicated folder

Services Layer – Business logic implementation

Service Abstraction Layer – Interfaces for services

Infrastructure & Persistence Layer – Data access logic and database handling

Presentation Layer – API controllers

<h1> Security and Authentication:</h1>
Protection against:

XSS, SQL Injection, and CSRF

JWT-based Authentication and Authorization

Secure Cookies for session management

<h1> Key Features:</h1>
Use of DTOs for controller communication

Repository Pattern and Unit of Work

AutoMapper for object mapping

Dependency Injection for service management

Modular service access using IServiceManager

Advanced Exception Handling (NotFound, Unauthorized, Validation, Internal Errors) handled via custom Middleware

<h1>Technologies & Tools Used:</h1>
Language & Framework: ASP.NET Core Web API, C#

Database: Microsoft SQL Server

ORM: Entity Framework Core (Code-First)

Architecture: Onion Architecture

Design Patterns: Repository, Unit of Work, Specification

Security: JWT, CSRF Protection, XSS, SQL Injection prevention

Data Layering: DTOs, AutoMapper

Dependency Management: IServiceManager, Dependency Injection

Error Handling: Centralized Exception Middleware

Frontend (if used): HTML, CSS, Bootstrap, JavaScript , Angular

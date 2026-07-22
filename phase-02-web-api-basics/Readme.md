# Phase 02 - ASP.NET Core Web API Basics

## Student Information

| Field | Value |
|-------|-------|
| Name | Habiba Amr |
| Track | ASP.NET Backend Career Training |
| Phase | Phase 02 - Web API Basics |
| Status | Completed & Ready for Review |

---
### Master Evidence Folder

**Google Drive:**  
https://drive.google.com/drive/folders/1yCm4MUb4fbRjipkmRvJjszF09czteB4q?usp=sharing


## Phase Mission

The core objective of this phase was to transition from console-based foundations to building real-world ASP.NET Core Web APIs.

I focused on mastering RESTful routing, the Controller-Service-Repository pattern, DTOs for request/response shaping, and professional API documentation.

---

## Tasks Completed

I have implemented the following 8 tasks as specified in the Phase 02 Task Pack:

- **Task 00 - API Workspace Setup:** Prepared a clean Web API environment with Swagger/OpenAPI enabled.
- **Task 01 - REST & Routing Drills:** Completed 15 technical drills to master route parameters, query strings, and HTTP status codes.
- **Task 02 - Student Management API:** Built a full in-memory CRUD system for training center students.
- **Task 03 - Products & Categories API:** Developed a complex API with related resources, advanced filtering, and inventory reports (My main focus for business logic).
- **Task 04 - Book Store API:** A mini-project connecting Books, Authors, and Categories.
- **Task 05 - Evidence Pack:** Professional documentation including Swagger screenshots and a complete Postman collection.
- **Task 06 - API Standards & Refactor:** Refactored legacy code into clean architecture layers.
- **Task 07 - Interview Answers:** Technical explanations for core Web API concepts.(Upcomming)

---

## Task 01: REST & Routing Drills

| Drill No. | Endpoint | Concept | Status |
|-----------|----------|---------|--------|
| 01 | `GET /api/health` | Basic endpoint / JSON status | Done |
| 02 | `GET /api/tools/echo/{name}` | Route parameters | Done |
| 03 | `GET /api/calculator/add` | Query parameters | Done |
| 05 | `GET /api/grades/calculate` | Validation & 400 Bad Request | Done |
| 08 | `GET /api/notes/{id}` | Route ID + 404 Handling | Done |
| 11 | `GET /api/notes/search` | Search Query Strings | Done |
| 15 | `GET /api/errors/demo` | Standard Error Response Shape | Done |

---

## Business Rules Applied (Task 03 Focus)

In the Products & Categories API, I implemented several "Mentor-Ready" business rules:

- **Data Integrity:** Prices must be positive (> 0), and Stock Quantity cannot be negative.
- **Relational Logic:** A Product cannot be created unless its CategoryId already exists in the system.
- **Unique Constraints:** Category names must be unique to prevent duplication.
- **Advanced Filtering:** Implemented search by name, category filtering, and a "Low Stock" filter for items with ≤ 5 units.
- **Inventory Reports:** Automated endpoints to calculate total stock value and inventory summaries.

---

## How To Run

### Clone the Repo

```bash
git clone techmaster-aspnet-backend-training
```

### Navigate to Project

```bash
cd phase-02-web-api-basics/task-03-products-categories-api/
```

### Run Application

```bash
dotnet run
```

### Access Documentation

Open:

```text
https://localhost:[PORT]/swagger
```

to interact with the API.

---

## Evidence & Documentation

**Swagger Documentation:**

Screenshots of all endpoints are organized in the Google Drive folder under `01-Swagger-Screenshots`.

**Postman Collection:**

A `TechMaster ASP.NET Phase 02.postman_collection.json` file is included in the project folder for importing.(Upcomming)

---

## Seed Data

I included 15+ products across 4 categories (Electronics, Furniture, Stationery, Accessories) to allow for immediate testing of filters and reports.

---

## What I Learned

- **Separation of Concerns:** Moving logic out of controllers into Services to keep the API clean.
- **DTO Pattern:** Using Data Transfer Objects to protect internal models and control the API's "shape".
- **HTTP Standards:** Properly using 201 Created, 204 No Content, and 404 Not Found status codes.
- **Professional Delivery:** Documentation via Swagger and Postman is as important as the code itself.(Upcomming)

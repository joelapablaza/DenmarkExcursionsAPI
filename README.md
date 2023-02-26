# **Denmark Excursions WebAPI ASP.NET 6**

# _This is a simple but complete Web Api that I made with learning purpose_

---

## This project implement the next Design Patterns:

- Dependency Injection
- Repository Pattern
- Contract Models - DTO (Data Transfer Objects)

---

## Authentication:

For this, I first implemented normal authentication private methods and hand-wrote all the validation fields. But then decided to migrate to _`FluentValidation`_ and only use normal private methods to use the Repositories to connect to the DbContext and validate if some data already exist and if true, the validation continues to the _`Fluentvalidation`_ classes.

---

## DTO (Data Transfer Objects)

For the DTOs implementation, I normally copied the values from the Domain model to the DTO model (and vice versa when needed) and also used _`AutoMapper`_ to make the copy in a single line of code. I use the two ways of doing it just to practice.

---

## Authentication and Authorization

For Authentication and Authorization, I used the built-in features on AspNetCore to create the IdentityModel and Claims to generate the Token. And for Authorization used the AuthorizeAtribute for the controllers.

---

## Persisted Data

For the Database I used `SQL Server` and `Entity Framework` to make the queries.

---

## [My Linkedin](https://www.linkedin.com/in/joel-apablaza-350bb1223/)

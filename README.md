# 🏠 House Renting System

An **ASP.NET Core MVC** web application for renting houses.

## 📋 Overview

The app allows users to browse available houses, view details, and rent a property. Registered users can become **Agents**, who are able to list, edit, and delete the houses they've added. An **Admin** role oversees the platform, with full visibility into user registrations and rental activity.

## 👥 Roles & Permissions

| Role  | Permissions |
|-------|-------------|
| **User**  | Browse houses, view details, rent a house, view their own rented houses, apply to become an Agent |
| **Agent** | All User permissions, plus add new houses and edit/delete only the houses they've listed |
| **Admin** | Full oversight of all user registrations and all rentals made in the system |

## 🛠️ Tech Stack

- ASP.NET Core MVC 
- Entity Framework Core
- ASP.NET Core Identity
- Razor Views

## 🗃️ Data Model

- **House** — title, address, description, image, price per month, category, linked agent and renter
- **Category** — grouping for house listings
- **Agent** — linked to an identity user, with contact info
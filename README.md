# NASA_Task
# 🚀 NASA APOD Gallery - Setup Guide

This guide explains how to set up and run the NASA APOD Gallery project.

---

## ✅ Prerequisites

Make sure the following are installed on your system:

- .NET SDK (6.0 or later)
- Visual Studio 2022 or VS Code
- SQL Server Management Studio (SSMS)

---

## 🧩 Step 1: Clone the Repository

## 🧩 Step 2: Create Database
Open SQL Server Management Studio and run the following SQL script:
<img width="250" height="150" alt="image" src="https://github.com/user-attachments/assets/336fc274-15ef-4edc-9656-d97f6bdb2248" />

## 🧩Step 3: Update Connection String & Add NASA Api key
Open appsettings.json and update the SQL Server connection string:
1. Replace YOUR_SERVER_NAME with your actual SQL Server instance name.
2. Replace ADD_APIkey with your actual NASA api key
<img width="1166" height="173" alt="image" src="https://github.com/user-attachments/assets/b5839feb-938f-438c-845f-389f2ecc337c" />

## ▶️ Step 4: Run the Application
output:
<img width="960" height="540" alt="Screenshot (837)" src="https://github.com/user-attachments/assets/b59dec9c-80ef-4f2e-a3ec-df5a855a549e" />
<img width="1337" height="315" alt="image" src="https://github.com/user-attachments/assets/b912d366-506c-42b7-86be-0079813e6785" />

# 🚀 Instructions for Setting NASA API Key

## 🧩 Step 1: Get API Key
1.Visit: https://api.nasa.gov

2.Click Generate API Key

3.Register with your email

4.Copy the generated API key

## 🧩 Step 2: Add API Key to Project
Open appsettings.json and add:
 Replace ADD_APIkey with your actual NASA api key
<img width="1166" height="173" alt="image" src="https://github.com/user-attachments/assets/b5839feb-938f-438c-845f-389f2ecc337c" />
TEST POSTMAN :
<img width="900" height="173" alt="image" src="https://github.com/user-attachments/assets/2a3b1c0d-fb0a-4359-8e86-6b969a21a685" />



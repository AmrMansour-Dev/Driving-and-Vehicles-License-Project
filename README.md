# 🚗 DVLD - Driving & Vehicle License Department System

DVLD is a desktop management system built using **C# Windows Forms** and **SQL Server**.  
The project automates driving license services including issuing, renewing, replacing, and managing licenses while applying structured **3-Tier Architecture** to handle business logic and database operations efficiently.

---

##  Features

-  Application Management (New / Renew / Replace Lost / Replace Damaged / Release Detained)
-  Manage Test Types (Vision / Theory / Practical)
-  Issue new driving licenses
-  License renewal functionality
-  Replace lost or damaged licenses
-  License detainment & release management
-  Retake test functionality
-  Centralized People management system
-  Driver records and history tracking
-  Secure login & logout system
-  Role-based access control (Admin / User)
-  Account settings (Change password / User info)
-  Full CRUD operations for Users
-  User activation status tracking (IsActive)
-  Advanced filtering & search functionality for People, Drivers, and Users

---

##  Technologies Used

- C#
- Windows Forms (WinForms)
- SQL Server
- ADO.NET
- 3-Tier Architecture
- Visual Studio 2022 / 2026
- SQL Server Management Studio (SSMS)

---

### 🛠️ Tech Stack

| Category | Technology |
| :--- | :--- |
| **Frontend** | Windows Forms (WinForms) |
| **Backend** | C# (.NET Framework) |
| **Database** | SQL Server |
| **Data Access** | ADO.NET |
| **Architecture** | 3-Tier Architecture (Presentation Layer, Business Layer, Data Access Layer) |
| **Security** | Role-Based Authorization (Admin / User) |
| **Tools** | Visual Studio 2022 / 2026, SSMS |

## 📸 Screenshots
<img width="884" height="571" alt="Screenshot 2026-04-20 210912" src="https://github.com/user-attachments/assets/6b95fdf5-ba5e-4e34-aa14-4ec0db862d90" />
<img width="1433" height="894" alt="Screenshot 2026-04-20 210928" src="https://github.com/user-attachments/assets/8b2e434b-97d0-4e39-a5b0-157767dedfe8" />
<img width="1435" height="880" alt="Screenshot 2026-04-20 211100" src="https://github.com/user-attachments/assets/5db7f6b7-a270-44ff-b504-0002e907f84d" />
<img width="944" height="892" alt="Screenshot 2026-04-20 212547" src="https://github.com/user-attachments/assets/f18f48a5-bdf3-4101-b4d7-dcd0d736ddfc" />
<img width="953" height="811" alt="Screenshot 2026-04-20 212353" src="https://github.com/user-attachments/assets/527610c8-8689-40da-b098-e568c3905388" />
<img width="1382" height="1016" alt="Screenshot 2026-04-20 212339" src="https://github.com/user-attachments/assets/51c62e11-c3d4-4c76-aa9b-c1c83aa23ea7" />
<img width="552" height="820" alt="Screenshot 2026-04-20 212603" src="https://github.com/user-attachments/assets/b936948d-3af6-4247-aba2-5af3485079a2" />

##  Setup Instructions

Here is Connection String Setup
To run the project on your local machine, please follow these steps:

1- Clone the Repository

2-Download Database File and Restore it in your SSMS 

3-Navigate to the Data Access Layer in project and find "clsDataAccessSettings" and Modify connection string to match your local server instance



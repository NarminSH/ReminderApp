# Reminder Scheduling API 📅 

This is a RESTful API built with ASP.NET Core for scheduling reminders via email or Telegram. It allows users to create, update, delete, and retrieve reminders, ensuring that notifications are sent at the exact time specified.

## Features

✅ CRUD Operations for reminders

✅ Email & Telegram Notifications

✅ Scheduling System to ensure reminders are sent on time

✅ Validation & Exception Handling

✅ Background Task Processing using Hangfire

✅ Docker support  



## Tech Stack
- **Backend:** .NET 6, ASP.NET Core
- **Database:** SQL Server
- **Architecture:** Clean Architecture, CQRS, Repository Pattern, Factory Pattern, Unit of Work
- **Background Jobs:** Hangfire
- **Notifications:** SMTP (Email), Telegram Bot
- **Containerization:** Docker with Docker Compose


🚀 Installation

- .NET 6 SDK
- SQL Server
- Docker (Optional)


🔹 Steps

## Installation
1. Clone the repository  
   ```sh
   git clone https://github.com/NarminSH/ReminderApp.git
   cd ReminderApp

🛠️ Configuration
Set up environment variables:

TELEGRAM_BOT_TOKEN

REMINDERAPP_EMAIL_LOGIN

REMINDERAPP_EMAIL_PASSCODE

SMTP_USE_SSL=true

SMTP_HOST=smtp.gmail.com

SMTP_PORT=587


✅ *Apply database migrations:*

dotnet ef database update

✅ *Run the API:*

dotnet run

✅ *Docker Support*

To run the project in a Docker container:

docker-compose up --build


### **📝 API Endpoints**
```md
   ## API Endpoints
   
   | Method | Endpoint            | Description                  |
   |--------|---------------------|------------------------------|
   | POST   | /api/reminders      | Create a new reminder       |
   | GET    | /api/reminders      | Get all reminders           |
```

🤝 Contributing
Contributions are welcome! Please follow these steps:

Fork the repository.
Create a new branch (feature/your-feature).
Commit your changes.
Push the branch.
Open a pull request.

📝 License
This project is licensed under the MIT License. See the LICENSE file for details.

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

Prerequisites

.NET 6

SQL Server

Docker (optional for containerization)

Setup

Clone the repository:

git clone https://github.com/NarminSH/ReminderApp.git
cd ReminderApp

Configure the database connection string in appsettings.json:

"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=reminderdb;User Id=youruser;Password=yourpassword;"
}

Apply database migrations:

dotnet ef database update

Run the API:

dotnet run

Docker Support

To run the project in a Docker container:

docker-compose up --build

API Endpoints

Reminders

GET /api/reminders - Get all reminders

POST /api/reminders - Create a new reminder

Environment Variables

TELEGRAM_BOT_TOKEN: API token for the Telegram bot

SMTP_SERVER: SMTP server for email notifications

SMTP_PORT: Port for SMTP

SMTP_USER: Email username

SMTP_PASSWORD: Email password

Contributing

Feel free to submit issues or pull requests.

License

This project is licensed under the MIT License.

## 📘 BlogPost API – Prosigliere

A clean and extensible RESTful API built with **ASP.NET Core** that allows you to create, retrieve, and manage blog posts and their comments. This API follows best practices, includes Swagger documentation, and is structured for scalability and maintainability.

** If I had more time I would add more Tests and Update Blog Posts Content and Title by ID.

---

### 💠 Features

* ✅ Create, retrieve, and delete blog posts
* 💬 Add comments to blog posts
* 📖 Get detailed post information including comments
* 📦 Organized by domain-driven design principles
* 🔐 Robust error handling and logging
* 🌐 Swagger UI for API testing and documentation
* 📦 Auto inititalized with On memory Blog Posts information

---

### 📡 Endpoints

All routes are prefixed with `/api/v1` (you can set this globally via routing conventions).

| Method | Endpoint                   | Description                  |
| ------ | -------------------------- | ---------------------------- |
| GET    | `/api/posts`               | List all blog posts          |
| GET    | `/api/posts/{id}`          | Get a single blog post by ID |
| POST   | `/api/posts`               | Create a new blog post       |
| POST   | `/api/posts/{id}/comments` | Add a comment to a post      |
| DELETE | `/api/posts/{id}`          | Delete a blog post by ID     |

---

### 📦 Models Overview

#### BlogPost

```json
{
  "id": 1,
  "title": "Understanding ASP.NET Core",
  "content": "Guide to web apps with ASP.NET Core",
  "comments": []
}
```

#### Comment

```json
{
  "author": "Alice",
  "text": "Great article!"
}
```

---

### 🚀 Running the API

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/BlogPostAPIProsigliere.git
   cd BlogPostAPIProsigliere
   ```

2. Restore dependencies and run:

   ```bash
   dotnet restore
   dotnet run

   Or open in visual Studio and Run it.
   ```

3. Navigate to:

   ```
   https://localhost:{port}/swagger

   **When you start the Application, it automatically initiate with On Memory Blog Posts information saved.
   ```

---

### 🧪 Testing the API

* Access [Swagger UI](https://localhost:{port}/swagger) after running to test all endpoints interactively.

---

### 🦾 Error Responses

All errors follow a consistent structure:

```json
{
  "error": "An error occurred while processing your request."
}
```

---

### 📚 Project Structure

```
📦 BlogPostAPIProsigliere
 ├ 📂Controllers
 ├ 📂Domain
 ┃ ├ 📂BlogPostContext
 ┃ ┃ ├ 📂Commands
 ┃ ┃ ├ 📂Entities
 ┃ ┃ ├ 📂Handlers
 ├ 📄 Program.cs
 ├ 📄 README.md
```

---

### 📄 License

This project is licensed under the MIT License.

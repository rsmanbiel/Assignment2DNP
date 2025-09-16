# ForumMini - Assignment 1: Entities & Repositories

A tiny Reddit-like forum application built with .NET 8 and C# 12, implementing the core domain model and repository pattern.

## Overview

This assignment implements the foundation of a forum application with three main entities: Users, Posts, and Comments. The solution follows a clean architecture approach with separate projects for domain entities, repository contracts, and in-memory implementations.

## Requirements & Constraints

- **No associations/navigation properties** in entities - relationships modeled via foreign key integers only
- **Repository pattern** with exact CRUD signatures as specified
- **IQueryable&lt;T&gt;** returned by GetMany() (non-async)
- **InvalidOperationException** thrown when entities don't exist
- **Auto-incrementing IDs** starting from 1
- **Seed data** included for easy manual testing
- **Nullable reference types** enabled
- **.NET 8** and **C# 12** compatibility

## Domain Model

### User
- `int Id` (primary key)
- `string Username`
- `string Password`

### Post
- `int Id` (primary key)
- `string Title`
- `string Body`
- `int UserId` (foreign key to User)

### Comment
- `int Id` (primary key)
- `string Body`
- `int UserId` (foreign key to User)
- `int PostId` (foreign key to Post)

## Project Structure

```
ForumMini/
├── Server/
│   ├── Entities/               # Domain entities
│   ├── RepositoryContracts/    # Repository interfaces
│   └── InMemoryRepositories/   # In-memory implementations
├── ForumMini.sln
├── .gitignore
└── README.md
```

## How to Build

```bash
# Build the entire solution
dotnet build ForumMini.sln

# Or build individual projects
dotnet build Server/Entities/Entities.csproj
dotnet build Server/RepositoryContracts/RepositoryContracts.csproj
dotnet build Server/InMemoryRepositories/InMemoryRepositories.csproj
```

## Manual Testing

You can manually instantiate and test the repositories like this:

```csharp
// Create repository instances
var users = new UserInMemoryRepository();
var posts = new PostInMemoryRepository();
var comments = new CommentInMemoryRepository();

// Inspect seed data
var allUsers = users.GetMany().ToList();
var allPosts = posts.GetMany().ToList();
var allComments = comments.GetMany().ToList();

// Test CRUD operations
var newUser = await users.AddAsync(new User { Username = "testuser", Password = "testpass" });
var retrievedUser = await users.GetSingleAsync(newUser.Id);
await users.UpdateAsync(new User { Id = newUser.Id, Username = "updateduser", Password = "testpass" });
await users.DeleteAsync(newUser.Id);
```

## Repository Signatures

All repositories implement these exact signatures:

```csharp
public interface IPostRepository
{
    Task<Post> AddAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(int id);
    Task<Post> GetSingleAsync(int id);
    IQueryable<Post> GetMany(); // note: not async
}
```

## Seed Data

The repositories are pre-populated with sample data:

**Users:**
- ID 1: alice / password123
- ID 2: bob / password123
- ID 3: charlie / password123

**Posts:**
- ID 1: "Welcome to the forum!" by user 1
- ID 2: "Second post" by user 2
- ID 3: "Another post" by user 1

**Comments:**
- ID 1: "Great first post!" by user 2 on post 1
- ID 2: "I agree completely." by user 3 on post 1
- ID 3: "Thanks for sharing." by user 1 on post 2
- ID 4: "Interesting perspective." by user 2 on post 3

## Next Steps

Future assignments will build upon this foundation by adding:
- CLI interface for user interaction
- Web API endpoints
- Entity Framework Core integration
- Additional features and validation

## Acceptance Criteria ✅

- [x] Solution builds successfully on .NET 8 with nullable enabled
- [x] Entities project contains User, Post, Comment with only scalar props + FK ints
- [x] RepositoryContracts defines IUserRepository, IPostRepository, ICommentRepository with required signatures
- [x] InMemoryRepositories implements all three repositories with List-backed storage
- [x] Auto-incrementing ID assignment (max ID + 1, or 1 if empty)
- [x] Proper error handling with InvalidOperationException for not found entities
- [x] GetMany() returns IQueryable&lt;T&gt; and is non-async
- [x] Seed data present and consistent (valid FK references)
- [x] No navigation properties or collections on entities
- [x] XML documentation comments on public interfaces and methods
- [x] Clean project structure with proper namespaces
- [x] Comprehensive README with build instructions and testing examples

## Technologies Used

- .NET 8
- C# 12
- Nullable Reference Types
- Repository Pattern
- In-Memory Data Storage

# ForumMini CLI Application - Assignment 2

This repository contains Assignment 2 for the DNP course, implementing a Command Line Interface for the ForumMini application.

## CLI Application

The CLI implementation can be found here: **[Server/CLI](https://github.com/rsmanbiel/Assignment2DNP/tree/master/Server/CLI)**

## Features

The CLI application provides a text-based interface with the following functionality:

### Required Features
- Create new user (username, password)
- Create new post (title, body, user ID)
- Add comment to existing post (body, user ID, post ID)  
- View posts overview (displays [title, id] for each post)
- View specific post (shows title, body, and all comments)

### Additional Features
- List all users
- List all comments
- Input validation and error handling
- Interactive help system

## How to Run

1. Navigate to the CLI project folder:
   ```
   cd Server/CLI
   ```

2. Build the project:
   ```
   dotnet build
   ```

3. Run the application:
   ```
   dotnet run
   ```

## Available Commands

Once running, use these commands:

- `1` or `create-user` - Create a new user
- `2` or `create-post` - Create a new post
- `3` or `add-comment` - Add comment to a post
- `4` or `list-posts` - View all posts overview
- `5` or `view-post` - View specific post with comments
- `6` or `list-users` - View all users
- `7` or `list-comments` - View all comments
- `help` - Show help message
- `clear` - Clear the screen
- `exit` or `quit` - Exit the application

## Project Structure

The application uses dependency injection and follows clean architecture principles:

- **Program.cs** - Entry point, creates repository instances
- **UI/CliApp.cs** - Main CLI controller handling user interaction
- Uses existing Entities, RepositoryContracts, and InMemoryRepositories projects

## Sample Usage

```
ForumMini> help
ForumMini> 1
Enter username: john
Enter password: pass123
User created successfully! ID: 4, Username: john

ForumMini> 4
=== POSTS OVERVIEW ===
[1] Welcome to the forum! - b

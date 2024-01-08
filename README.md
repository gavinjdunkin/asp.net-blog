# ASP.NET Core Blog Project with MVC and Authentication

## Project Overview

This project is a simple blog application built using ASP.NET Core with the Model-View-Controller (MVC) architectural pattern. The application allows users to create, edit, and delete blog posts, and it includes user authentication to secure certain features.

## Features

- **User Authentication**: Users can register, log in, and log out to access the blog features.
- **Create and Edit Posts**: Authenticated users can create new blog posts and edit existing ones.
- **Delete Posts**: Authenticated users can delete their own posts.
- **View Posts**: All users can view published blog posts.

## Technologies Used

- **ASP.NET Core 3.1**: The framework for building the web application.
- **Entity Framework Core**: ORM for database operations.
- **MVC (Model-View-Controller)**: Architectural pattern for organizing code and separating concerns.
- **Identity**: Used for user authentication and authorization.
- **Razor Pages**: Templating engine for generating dynamic HTML.

## Prerequisites

Make sure you have the following installed:

- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) with the ASP.NET Core workload.
- [.NET Core SDK](https://dotnet.microsoft.com/download) 3.1 or later.

## Getting Started

1. Clone the repository:

    ```bash
    git clone https://github.com/yourusername/aspnet-core-blog.git
    ```

2. Open the project in Visual Studio or Visual Studio Code.

3. Set up the database:
   
    ```bash
    dotnet ef database update
    ```

4. Run the application:

    ```bash
    dotnet run
    ```

5. Open your browser and navigate to [https://localhost:5001](https://localhost:5001) to view the application.

## Configuration

1. **Database Connection**: You can change the database connection string in the `appsettings.json` file.

2. **Authentication**: Authentication settings are configured in the `Startup.cs` file.

## Contributing

Feel free to contribute to the project by submitting pull requests or reporting issues. Please follow the [Contributing Guidelines](CONTRIBUTING.md).

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Special thanks to the ASP.NET Core and Entity Framework Core communities for their valuable contributions.

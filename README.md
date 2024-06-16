# Simple Receipt App

This is a simple Receipt App built with .NET Web API. The app allows users to add items and generate receipts for the added items. The receipts will display the total amount, the amount paid, and the remaining balance.

## Features

- Add items with details such as name, quantity, and price.
- Generate receipts that summarize the added items.
- Display the total amount, the amount paid, and the remaining balance for each receipt.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.
- [Docker](https://www.docker.com/get-started) installed on your machine.

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/yourusername/simplereceiptapp.git
    cd simplereceiptapp
    ```

2. Restore the dependencies:

    ```bash
    dotnet restore
    ```

3. Build the project:

    ```bash
    dotnet build
    ```

### Setting Up the MySQL Database with Docker Compose

1. Run the following command to start the MySQL service:

    ```bash
    docker-compose up -d
    ```

   The `-d` flag runs the services in detached mode.

2. To check the status of the MySQL container, use the following command:

    ```bash
    docker-compose ps
    ```

3. To stop the services, use the following command:

    ```bash
    docker-compose down
    ```

### Running the Application

1. Ensure the MySQL database is running using Docker Compose.
2. Run the application:

    ```bash
    dotnet run
    ```

   The application should now be running on `http://localhost:5059`.

## API Documentation

For detailed API documentation and to interact with the API, visit the Swagger UI: `http://localhost:5059/index.html`
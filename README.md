# 📦 EasyStore

**This project contains a sample ASP.NET Core app. This app is an example of the article I produced for the Telerik Blog (telerik.com/blogs)**

**EasyStore** is an ASP.NET Core application designed to store product page data in Cosmos DB.

## 🌟 Features

- **ASP.NET Core**: A robust, cross-platform framework for building web applications.
- **Cosmos DB**: A globally distributed, multi-model database for high-performance data storage.
- **CSV Helper**: A powerful library to read and write CSV files with ease.
- **Product Page Management**: Efficiently store and manage product page data.

## 🛠️ Getting Started

### Prerequisites

- .NET Core SDK
- Azure Cosmos DB server (You can use the Cosmos DB emulator)
- Basic knowledge of ASP.NET Core and Cosmos DB

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/zangassis/easy-store.git
   cd EasyStore
   ```

2. **Install dependencies:**
   ```bash
   dotnet restore
   ```

3. **Set up Cosmos DB:**
   - Configure your Cosmos DB connection string in the `appsettings.json` file.

4. **Run the application:**
   ```bash
   dotnet run
   ```

### Usage

1. **Upload a CSV file:**
   - Use the application to upload your product page data in CSV format.

2. **Data Storage:**
   - The application processes the CSV file and stores the product data in Cosmos DB.

## 🛡️ License

This project is licensed under the MIT License. See the `LICENSE` file for more details.

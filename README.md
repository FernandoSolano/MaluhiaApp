# Random Clicker Application

## Overview
The Random Clicker Application is a C# desktop application that allows users to randomly click within a user-defined area on their screen. This application provides a simple user interface to start and stop the clicking process and to select the area where the clicks will occur.

## Features
- Define a specific area on the screen for random clicking.
- Start and stop the clicking process with a single click.
- User-friendly interface for easy navigation and control.

## Project Structure
The project consists of the following files:

- `src/RandomClickerApp.csproj`: Project configuration and dependencies.
- `src/Program.cs`: Entry point of the application.
- `src/MainForm.cs`: Main user interface logic.
- `src/MainForm.Designer.cs`: Designer-generated layout for the main form.
- `src/AreaSelectorForm.cs`: Logic for selecting the area on the screen.
- `src/AreaSelectorForm.Designer.cs`: Designer-generated layout for the area selector form.
- `src/Utils/Clicker.cs`: Logic for simulating mouse clicks.

## Getting Started

### Prerequisites
- .NET SDK installed on your machine.

### Building the Application
1. Open a terminal and navigate to the project directory.
2. Run the following command to build the application:
   ```
   dotnet build src/RandomClickerApp.csproj
   ```

### Running the Application
After building the application, you can run it using the following command:
```
dotnet run --project src/RandomClickerApp.csproj
```

## Usage
1. Launch the application.
2. Use the area selector to define the area where you want the random clicks to occur.
3. Click the start button to begin the clicking process.
4. Click the stop button to halt the clicking.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.
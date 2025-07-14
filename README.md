# MakeMyTrip Automation Project

## Overview
This project is an automated test suite for the MakeMyTrip website, focusing on the scenario of searching for flights. The tests are written in C# using the Playwright framework, which enables browser automation for end-to-end testing.

## Project Structure
```
MakeMyTrip/
├── MakeMyTrip.cs
├── MakeMyTrip.csproj
├── MakeMyTrip.sln
├── ExampleOfPageTestClass.cs
├── ReachingMMTINHeadlessMode.cs
├── screenshots/
├── videos/
└── ...
```

## Playwright PageTest Usage
The test classes `ExampleOfPageTestClass` and `ReachingMMTINHeadlessMode` both inherit from Playwright’s `PageTest` class. This provides built-in support for launching browsers in headless mode, managing browser contexts, and simplifying test setup/teardown. In `ExampleOfPageTestClass`, the `PageTest` base is used for advanced features like ARIA snapshot testing, while in `ReachingMMTINHeadlessMode` it is used for basic navigation and assertions.

## Playwright Codegen for Initial Automation Setup
This project leveraged Playwright's `codegen` functionality to quickly generate the initial automation code. By using `codegen`, I was able to:
- Rapidly define the workflow for automating the flight search scenario
- Automatically discover and record selectors for web elements during manual interaction
- Speed up the initial setup of the test suite

After generating the base code with `codegen`, I customized the scripts to fit my test design requirements. This included refining workflows, improving assertions, and re-editing selectors when tests failed due to changes in the website or element behavior. The use of `codegen` made the process much faster and more efficient, especially for:
- Quickly identifying and interacting with dynamic web elements
- Reducing manual effort in writing selectors
- Providing a solid starting point for further test development

Overall, Playwright's codegen was instrumental in accelerating the initial development and troubleshooting phases of this automation project.

## Trace Viewer and Video Logging
This project leverages Playwright’s advanced logging features:
- **Trace Viewer**: Tracing is enabled in the test code to capture screenshots, DOM snapshots, and source files during test execution. The trace is saved as a `.zip` file and can be viewed using Playwright’s trace viewer for debugging and analysis.
- **Video Logging**: Browser contexts are configured to record videos of test runs. Videos are saved in the `videos/` directory, allowing you to review the test execution visually.

## Playwright Methods (Commented for Future Use)
Several Playwright methods are included in the code but commented out for future reference. These include:
- HTTP authentication for browser contexts
- Handling popups and dialogs
- Working with frames
- Capturing screenshots of specific locators
- Downloading and uploading files
- Advanced assertions and element interactions

These commented sections serve as a guide for extending the test suite with more complex scenarios.

## Playwright Locators
Playwright locators are a powerful way to identify and interact with elements on a web page. They allow you to select elements using CSS selectors, text, roles, and more. In this project, Playwright locators are used to:
- Identify input fields for source and destination cities
- Select dates from the calendar
- Click the search button
- Validate the appearance of flight results

Example usage:
```csharp
var sourceInput = page.Locator("input[placeholder='From']");
var destinationInput = page.Locator("input[placeholder='To']");
var searchButton = page.Locator("button:has-text('Search')");
```

## Tested Site
The tests target the [MakeMyTrip](https://www.makemytrip.com/) website, a popular travel booking platform in India.

## Test Scenario: Finding a Flight
The main scenario automated in this project is searching for a flight. The steps include:
1. Navigating to the MakeMyTrip homepage
2. Entering the source and destination cities
3. Selecting the travel date
4. Clicking the search button
5. Verifying that flight options are displayed

## How to Run the Tests
1. Ensure you have .NET and Playwright installed.
2. Build the project:
   ```powershell
   dotnet build
   ```
3. Run the tests:
   ```powershell
   dotnet test
   ```

## How to View Playwright Trace Files

After running your tests, a `trace.zip` file is generated in the output directory. You can use Playwright's trace viewer to open and analyze this file.

### Steps to Open `trace.zip` Using PowerShell
1. Open PowerShell and navigate to the directory containing your `trace.zip` file:
   ```powershell
   cd "*\MakeMyTrip\MakeMyTrip\bin\Debug\net8.0"
   ```
2. Run the Playwright trace viewer:
   ```powershell
   pwsh .\playwright.ps1 show-trace trace.zip
   ```
   Or, if you have Playwright installed globally via npm, you can use:
   ```powershell
   npx playwright show-trace trace.zip
   ```

### If `playwright.ps1` Does Not Run
If you encounter issues running `playwright.ps1`, use the following PowerShell command:
```powershell
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope Process
```
This will open the trace viewer in your default browser for interactive debugging.

---
Feel free to expand the test scenarios and add more details as your automation suite grows.

# MakeMyTrip Automation Project

## Overview
This project is an automated test suite for the MakeMyTrip website, focusing on the scenario of searching for flights. The tests are written in C# using the Playwright framework, which enables browser automation for end-to-end testing.

## Playwright Locators
Playwright locators are a powerful way to identify and interact with elements on a web page. They allow you to select elements using CSS selectors, text, roles, and more. In this project, Playwright locators are (or will be) used to:
- Identify input fields for source and destination cities
- Select dates from the calendar
- Click the search button
- Validate the appearance of flight results

Example usage (to be implemented in your test class):
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

---
Feel free to expand the test scenarios and add more details as your automation suite grows.

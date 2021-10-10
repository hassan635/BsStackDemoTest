# DX Solution Coding Exercise - Hasan Ali Tariq

## BsStackDemo Automated Tests

---

## Dependencies & Prerequisites:

- Windows 10 x64
- Visual Studio 2019 installed on the system
- .Net Core 3.1 installed on the system
- Git for Windows
- Google Chrome version 94.0 installed on the system
- ChromeDriver version 94.0 binary added to PATH environment variable. **[Read Tutorial](https://zwbetz.com/download-chromedriver-binary-and-add-to-your-path-for-automated-functional-testing/#windows-gui)**

---

## Setup & Execution:

- Clone the solution on your local system. If using Git Bash then enter the command on terminal like so:
``` git clone https://github.com/hassan635/BsStackDemoTest.git```
- Open CLI (cmd.exe) and navigate to the cloned location until you are in the same directory as the file **BsStackDemoTest.sln**
- To start automated test execution, type the following command on the CLI:
``` dotnet test```

---

## Automated Test Report Generation:

- Open CLI (cmd.exe) and navigate to the cloned location until you are in the same directory as the directory **\BsStackDemoTests\bin\Debug\netcoreapp3.1**
- Issue the following command to install the SpecFlow report generator:
``` dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI``` 
- Now issue the following command to generate the report:
``` livingdoc test-assembly BsStackDemoTest.dll -t TestExecution.json --title "Automated Test Execution Report"```
- A HTML report file with the name **LivingDoc** will be generated and store in the same directory.
- This report file is self contained and can easily be shared.

---

## Solution Details:

- Incorporates Page Object Model for the Login, Checkout, Orders and Product pages.
- Product and Orders object 'has-a' navigation object since the navigation is available for both these pages in the actual UI.
- These page objects are then used to write a tests in respective step definitions for the Order details feature.
- Selenium WebDriver library is employed to drive the browser.
- Specflow is employed to provide executable features.
- NUnit is used for assertions.
- Test data values are injected via a JSON file.
- Login UI is bypassed by injecting the username key in the session.
- Dynamic waiting strategy is applied commonly. Some exceptional scenarios utilize explicit waiting for more reliable test execution.

---
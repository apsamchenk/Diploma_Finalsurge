
# Finalsurge

This solution is a test automation framework for website https://log.finalsurge.com/.



## Authors

- [@Anna Samchenko](https://github.com/apsamchenk)


## Tech Stack

**Test framework:** NUnit

**Logging:** NLog

**Reporting:** Allure

**Browser automation:** Selenium

**Fake data generator:** Bogus


## Approaches used in the development of the framework and tests

* Driver Factory
* Browser
* Page Object
* Page Steps
* Wrappers
* Builder for model
* Chain of invocation
* Bogus
## Test set
**Authorization Tests**
| Title | Description                |
| :-------- | :------------------------- |
| ValidLoginTest | Try to sign in using valid login/password from appsettings.json  |
| InvalidLoginTest | Try to sign in using random login/password, check alert message |
| InvalidPasswordTest | Try to sign in using valid login and random password, check alert message  |
| LogoutTest | Check logout after successful authorization |

**Calendar Tests**
| Title | Description                |
| :-------- | :------------------------- |
| QuickAddByCalendarCell | Create new activity by "plus" button in necessary calendar cell |
| QuickAddByButton | Create new activity by "Quick Add" button located at calendar page |
| MoveActivityToAnotherCell | Move existing activity from one calendar cell to another |
| CopyActivityToAnotherCell | Copy existing activity from one calendar cell to another  |
| DeleteActivity | Try to delete existing activity from calendar cell. Confirm removal |
| CancelDeleteActivity | Try to delete existing activity from calendar cell. Reject removal |

**Calculator Tests**
| Title | Description                |
| :-------- | :------------------------- |
| CalculateCaloriesForFemale | Fill fields and calculate calories. Gender = female  |
| CalculateCaloriesForMale | Fill fields and calculate calories. Gender = male (to see difference in calculation) |
| CalculatePaceForDistanceType | Fill distance type and calculate pace |
| CalculatePaceForRaceDistance | Fill race distance and calculate pace |
| CheckErrorMessage | Check error message for both of calculators (2 different tests) in case of incorrect field filling|


## Installation

1) Sign up in https://log.finalsurge.com/. You can use any random email and password, website doesn't require any confirmation
2) Clone [Finalsurge Tests](https://github.com/apsamchenk/Diploma_Finalsurge) repository
3) Open solution in Visual studio (or other IDE for C#)
4) Open Finalsurge -> Runsettings -> appsettings.json. Replace values for variables `FinalSurgeUserLogin` and `FinalSurgeUserPassword` with your data
5) Build solution

    
## Running Tests

In Visual Studio you can use Test Explorer for tests running

If you want to run tests from command line, use the following command:

```bash
  dornet test
```


## Allure Reporting
**Allure installation:**
1) Download zip from [maven](https://repo.maven.apache.org/maven2/io/qameta/allure/allure-commandline/) (one of latest versions)
2) Extract files to any directory on your computer
3) Add path to the bin directory in environment variable PATH
4) Run command `allure --version` in terminal to check that installation is successful

----
**Generate Allure report:**
1. In cmd open directory **\Diploma\Finalsurge\bin\Debug\net6.0
2. Run the command
```bash
  allure serve
```
Allure report will be open in your web browser
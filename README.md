# WorkingDaysCalculator
 
[![Build Status](https://github.com/davewalker5/WorkingDaysCalculator/workflows/.NET%20Core%20CI%20Build/badge.svg)](https://github.com/davewalker5/WorkingDaysCalculator/actions)
[![GitHub issues](https://img.shields.io/github/issues/davewalker5/WorkingDaysCalculator)](https://github.com/davewalker5/WorkingDaysCalculator/issues)
[![Coverage Status](https://coveralls.io/repos/github/davewalker5/WorkingDaysCalculator/badge.svg?branch=master)](https://coveralls.io/github/davewalker5/WorkingDaysCalculator?branch=master)
[![Releases](https://img.shields.io/github/v/release/davewalker5/WorkingDaysCalculator.svg?include_prereleases)](https://github.com/davewalker5/WorkingDaysCalculator/releases)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://github.com/davewalker5/WorkingDaysCalculator/blob/master/LICENSE)
[![Language](https://img.shields.io/badge/language-c%23-blue.svg)](https://github.com/davewalker5/WorkingDaysCalculator/)
[![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/davewalker5/WorkingDaysCalculator)](https://github.com/davewalker5/WorkingDaysCalculator/)

## About

The WorkingDaysCalculator is a demonstration of calculating the number of working days between two days, assuming the weekend falls on Saturday and Sunday, using the following algorithm:

![Working Days Algorithm](https://raw.githubusercontent.com/davewalker5/WorkingDaysCalculator/master/images/algorithm.png "Working Days Algorithm")

* If the start date is a Sunday, move it back to the Saturday of the same weekend
* If the start date is not a Saturday, roll it forward to the next Saturday, counting the number of working days required, _fs_
* If the end date is not a Saturday, roll it forward to the next Saturday, counting the number of working days required, _fe_
* Calculate the number of working days between the adjusted start and end dates
* Divide by 7 to give the number of complete weeks, _w_
* Calculate the number of working days as 5 * _w_ + _fs_ + _fe_ + 1

## Getting Started

The following code snippet illustrates the use of the calculator to calculate the working days between the current day and a specified end date accounting for 2020 public holidays in England:

```csharp
DateTime[] bankHolidays =
{
    new DateTime(2020, 1, 1),
    new DateTime(2020, 4, 10),
    new DateTime(2020, 4, 13),
    new DateTime(2020, 5, 8),
    new DateTime(2020, 5, 25),
    new DateTime(2020, 8, 31),
    new DateTime(2020, 12, 25),
    new DateTime(2020, 12, 28)
};

DateTime start = DateTime.Now;
DateTime end = new DateTime(2020, 4, 24);

WorkingDaysCalculator calculator = new WorkingDaysCalculator();
int days = calculator.Calculate(start, end, bankHolidays);

Console.WriteLine($"There are {days} working days between {start.ToString("dd/MMM/yyyy")} and {end.ToString("dd/MMM/yyyy")}");
```

## Authors

- **Dave Walker** - *Initial work* - [LinkedIn](https://www.linkedin.com/in/davewalker5/)

## Feedback

To file issues or suggestions, please use the [Issues](https://github.com/davewalker5/WorkingDaysCalculator/issues) page for this project on GitHub.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details

[![](https://img.shields.io/nuget/v/soenneker.extensions.datetime.week.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.datetime.week/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.datetime.week/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.datetime.week/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.datetime.week.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.datetime.week/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.datetime.week/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.datetime.week/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.DateTime.Week
A collection of helpful DateTime week-based extension methods.

## Installation

```bash
dotnet add package Soenneker.Extensions.DateTime.Week
```

## Quick start

```csharp
using Soenneker.Extensions.DateTime.Week;

DateTime datetime = DateTime.UtcNow;
var result = datetime.ToStartOfWeek();
```

## Common operations

- `ToStartOfWeek()` - Adjusts the specified DateTime to the start of the current week. Returns a new DateTime instance set to the first moment (00:00:00) of the week of the original DateTime.
- `ToEndOfWeek()` - Adjusts the specified DateTime to the end of the current week. Returns a new DateTime instance set to the last moment (23:59:59.9999999) of the week of the original DateTime.
- `ToStartOfNextWeek()` - Adjusts the specified DateTime to the start of the next week, represented in UTC. Returns a new DateTime instance set to the first moment of the next week. The method calculates the start of the next week without performing any timezone conversion.
- `ToStartOfPreviousWeek()` - Adjusts the specified DateTime to the start of the previous week. Returns a new DateTime instance set to the first moment of the previous week. This method calculates the start of the previous week without adjusting for timezone differences.
- `ToEndOfNextWeek()` - Adjusts the specified DateTime to the end of the previous week. Returns a new DateTime instance set to the last moment of the week preceding the current week.
- `ToEndOfPreviousWeek()` - Adjusts the specified DateTime to the end of the previous week. Returns a new DateTime instance set to the last moment of the week preceding the current week.
- `ToStartOfTzWeek()` - Converts the specified UTC DateTime to a specific timezone, adjusts it to the start of the current week in that timezone, and then converts it back to UTC. Returns a new DateTime instance in UTC, representing the start of the current week in the specified timezone. This method is useful for aligning dates with the beginning of the week in different timezones.
- `ToStartOfNextTzWeek()` - Converts the specified UTC DateTime to a specific timezone, adjusts it to the start of the next week in that timezone, and then converts it back to UTC. Returns a new DateTime instance in UTC, representing the start of the next week in the specified timezone.
- `ToStartOfPreviousTzWeek()` - Adjusts the specified UTC DateTime to the start of the previous week according to a specific timezone, and represents the result in UTC. This method calculates the start of the previous week by subtracting 7 days from the start of the current timezone-adjusted week.
- `ToEndOfTzWeek()` - Adjusts the specified UTC DateTime to the very last moment of the current week according to a specific timezone, and represents the result in UTC. This method finds the start of the next week in the specified timezone and subtracts one tick to align with the very end of the current week.
- `ToEndOfPreviousTzWeek()` - Adjusts the specified UTC DateTime to the very last moment of the previous week according to a specific timezone, then converts it back to UTC. Returns a DateTime instance in UTC, representing the last moment of the previous week in the specified timezone.
- `ToEndOfNextTzWeek()` - Adjusts the specified UTC DateTime to the very last moment of the next week according to a specific timezone, then converts it back to UTC. Returns a DateTime instance in UTC, representing the last moment of the next week in the specified timezone.

The package also includes 2 additional operations for more specialized cases.

[![](https://img.shields.io/nuget/v/soenneker.extensions.datetime.week.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.datetime.week/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.datetime.week/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.datetime.week/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.datetime.week.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.datetime.week/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.datetime.week/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.datetime.week/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.DateTime.Week

Computes Monday-based week boundaries and ISO-8601 week numbers for `DateTime`, with optional time-zone-aware UTC results.

## Installation

```bash
dotnet add package Soenneker.Extensions.DateTime.Week
```

## Week boundaries

```csharp
using Soenneker.Extensions.DateTime.Week;

System.DateTime value = new(2026, 8, 29, 16, 42, 30, DateTimeKind.Utc);

System.DateTime start = value.ToStartOfWeek();
System.DateTime end = value.ToEndOfWeek();
System.DateTime previousStart = value.ToStartOfPreviousWeek();
System.DateTime nextEnd = value.ToEndOfNextWeek();
```

Weeks always begin Monday at `00:00:00`; they do not depend on the current culture. End methods return one tick before the following Monday.

| Method pair | Selected week |
| --- | --- |
| `ToStartOfWeek()` / `ToEndOfWeek()` | Current |
| `ToStartOfPreviousWeek()` / `ToEndOfPreviousWeek()` | Previous |
| `ToStartOfNextWeek()` / `ToEndOfNextWeek()` | Next |

These methods operate on the input calendar fields and preserve `Kind`. They do not perform time-zone conversion.

## Time-zone-aware boundaries

```csharp
TimeZoneInfo eastern = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
System.DateTime utc = new(2026, 8, 29, 18, 0, 0, DateTimeKind.Utc);

System.DateTime localWeekStartUtc = utc.ToStartOfTzWeek(eastern);
System.DateTime localWeekEndUtc = utc.ToEndOfTzWeek(eastern);
```

Time-zone variants cover the current, previous, and next local week and return boundaries as UTC `DateTime` values. Their names follow the same pattern, including `ToStartOfPreviousTzWeek()` and `ToEndOfNextTzWeek()`.

If the input `Kind` is not `Utc`, its fields are treated as UTC rather than converted from the machine's local zone. Supply an actual UTC value to avoid ambiguity.

Week ends are one tick before the following valid local Monday boundary. If local Monday midnight falls in a daylight-saving gap, the boundary advances to the first valid local minute; if it is ambiguous, the earlier UTC instant is selected.

## ISO week numbers

```csharp
int utcWeek = utc.ToUtcWeekNumber();
int easternWeek = utc.ToTzWeekNumber(eastern);
```

Both methods use ISO-8601 rules: Monday is the first weekday, and week 1 is the week containing January 4. `ToUtcWeekNumber()` applies those rules to the input date fields without converting them. `ToTzWeekNumber()` first selects the calendar date in the supplied time zone.

Only the week number (`1–53`) is returned. If the associated ISO week-year is also required, use `System.Globalization.ISOWeek.GetYear()` on the same calendar date.

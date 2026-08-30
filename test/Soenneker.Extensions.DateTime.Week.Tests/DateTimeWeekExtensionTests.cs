using System;
using System.Threading.Tasks;
using Soenneker.Tests.Unit;

namespace Soenneker.Extensions.DateTime.Week.Tests;

public class DateTimeWeekExtensionTests : UnitTest
{
    [Test]
    public async Task ToStartOfWeek_uses_monday()
    {
        var sunday = new System.DateTime(2026, 8, 30, 12, 0, 0, DateTimeKind.Utc);

        System.DateTime result = sunday.ToStartOfWeek();

        await Assert.That(result).IsEqualTo(new System.DateTime(2026, 8, 24, 0, 0, 0, DateTimeKind.Utc));
    }

    [Test]
    public async Task ToUtcWeekNumber_uses_iso_week_year_boundary_rules()
    {
        var value = new System.DateTime(2018, 12, 31, 0, 0, 0, DateTimeKind.Utc);

        await Assert.That(value.ToUtcWeekNumber()).IsEqualTo(1);
    }

    [Test]
    public async Task Time_zone_week_end_is_tick_before_next_local_monday()
    {
        var value = new System.DateTime(2026, 8, 26, 12, 0, 0, DateTimeKind.Utc);

        System.DateTime result = value.ToEndOfTzWeek(TimeZoneInfo.Utc);

        await Assert.That(result).IsEqualTo(new System.DateTime(2026, 8, 31, 0, 0, 0, DateTimeKind.Utc).AddTicks(-1));
    }
}

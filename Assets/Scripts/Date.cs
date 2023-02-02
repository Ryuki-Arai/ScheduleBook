using System;
using System.Collections.Generic;

/// <summary>
/// 年月日と曜日、記録を保管するクラス
/// </summary>
[Serializable]
public class Date
{
    public int year;
    public int month;
    public int day;
    public Week week;
    public List<string> schedule;

    public Date()
    {
        var nowDate = DateTime.Today;
        year = nowDate.Year;
        month = nowDate.Month;
        day = nowDate.Day;
        week = (Week)nowDate.DayOfWeek;
        schedule = new List<string>();
    }

    public Date(int year,int month, int day, Week week)
    {
        this.year = year;
        this.month = month;
        this.day = day;
        this.week = week;
        this.schedule = new List<string>();
    }
    
    public Date(int year,int month, int day, Week week, List<string> schedule)
    {
        this.year = year;
        this.month = month;
        this.day = day;
        this.week = week;
        this.schedule = schedule;
    }
}

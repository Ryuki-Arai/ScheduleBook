using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Month : MonoBehaviour
{
    int _year;
    int _month;
    [SerializeField] int _cellCount;
    [SerializeField] Day _day = default;
    Day[] _days = default;
    public Day[] Days => _days;
    int _firstWeek = default;
    Week _week = default;

    public void InitMonthData(int year,int month)
    {
        _year = year;
        _month = month;
        _days = new Day[_cellCount];
        _firstWeek = (int)FindDay(1);
        CreateCalendar();
    }

    private DayOfWeek FindDay(int d)
    {
        var date = new DateTime(_year, _month, d);
        return date.DayOfWeek;
    }

    private void CreateCalendar()
    {
        int day = 1;
        Debug.Log(DateTime.DaysInMonth(_year,_month));
        for (int i = 0; i < _cellCount; i++)
        {
            if (i >= _firstWeek && i < DateTime.DaysInMonth(_year, _month) + _firstWeek)
            {
                _week = (Week)FindDay(day);
                var d = Instantiate(_day, transform);
                d.name = $"Day_{i}";
                _days[i] = d;
                _days[i]._Day = day;
                _days[i].Week = _week;
                day++;
            }
            else
            {
                var d = Instantiate(_day, transform);
                d.name = $"Day_{i}";
                _days[i] = d;
                _days[i].Week = Week.None;
            }
        }
    }
}

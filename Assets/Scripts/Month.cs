using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Month : MonoBehaviour
{
    [SerializeField] int year;
    [SerializeField] int _month;
    [SerializeField] int _cellCount;
    [SerializeField] Day _day = default;
    Day[] _days = default;
    int _firstWeek = default;
    DayOfWeek _week = default;

    private void Start()
    {
        _days = new Day[_cellCount];
        _firstWeek = (int)FindDay(1);
        CreateCalendar();
    }

    private void OnValidate()
    {
        
    }

    private DayOfWeek FindDay(int d)
    {
        var date = new DateTime(year, _month, d);
        return date.DayOfWeek;
    }

    public void CreateCalendar()
    {
        int day = 1;
        for (int i = 0; i < _cellCount; i++)
        {
            if(i >= _firstWeek && i < DateTime.DaysInMonth(year, _month))
            {
                _week = FindDay(i + 1);
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
                _days[i]._Day = 0;
            }
        }
    }
}

using System;
using UnityEngine;

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

    /// <summary>
    /// 西暦年月から初日の曜日を算出し、カレンダーのデータを初期化する。
    /// </summary>
    /// <param name="year">西暦年号を格納する</param>
    /// <param name="month">月を格納する</param>
    public void InitMonthData(int year,int month)
    {
        _year = year;
        _month = month;
        _days = new Day[_cellCount];
        _firstWeek = (int)FindDay(1);
        ApplyCalendar();
    }

    /// <summary>
    /// 任意の日にちが何曜日か求める
    /// </summary>
    /// <param name="d">任意の日にち</param>
    /// <returns>曜日情報の列挙型</returns>
    private Week FindDay(int d)
    {
        var date = new DateTime(_year, _month, d);
        return (Week)date.DayOfWeek;
    }

    /// <summary>
    /// 用意されたデータを基にシーン上にゲームオブジェクトの配列を作成する。
    /// </summary>
    private void ApplyCalendar()
    {
        int day = 1;
        for (int i = 0; i < _cellCount; i++)
        {
            _days[i] = Instantiate(_day, transform);
            _days[i].name = $"Day_{i}";
            if (i >= _firstWeek && i < DateTime.DaysInMonth(_year, _month) + _firstWeek)
            {
                _week = FindDay(day);
                _days[i].Date = day;
                _days[i].Week = _week;
                day++;
            }
            else
            {
                _days[i].Week = Week.None;
            }
        }
    }
}

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
    /// �J�����_�[�̃f�[�^������������B
    /// </summary>
    public void InitMonthData()
    {
        _days = new Day[_cellCount];
        for (int i = 0; i < _cellCount; i++)
        {
            _days[i] = Instantiate(_day, transform);
            _days[i].name = $"Day_{i}";
        }
    }

    /// <summary>
    /// �C�ӂ̓��ɂ������j�������߂�
    /// </summary>
    /// <param name="d">�C�ӂ̓��ɂ�</param>
    /// <returns>�j�����̗񋓌^</returns>
    private Week FindDay(int d)
    {
        var date = new DateTime(_year, _month, d);
        return (Week)date.DayOfWeek;
    }

    /// <summary>
    /// �p�ӂ��ꂽ�f�[�^����ɃV�[����ɃQ�[���I�u�W�F�N�g�̔z����쐬����B
    /// </summary>
    public void ApplyCalendar(int year, int month)
    {
        _year = year;
        _month = month;
        _firstWeek = (int)FindDay(1);
        int day = 1;
        for (int i = 0; i < _cellCount; i++)
        {
            if (i >= _firstWeek && i < DateTime.DaysInMonth(_year, _month) + _firstWeek)
            {
                _week = FindDay(day);
                _days[i].Date = day;
                _days[i].Week = _week;
                day++;
            }
            else
            {
                _days[i].Date = 0;
                _days[i].Week = Week.None;
            }
        }
    }
}

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
    /// ����N�����珉���̗j�����Z�o���A�J�����_�[�̃f�[�^������������B
    /// </summary>
    /// <param name="year">����N�����i�[����</param>
    /// <param name="month">�����i�[����</param>
    public void InitMonthData(int year,int month)
    {
        _year = year;
        _month = month;
        _days = new Day[_cellCount];
        _firstWeek = (int)FindDay(1);
        CreateCalendar();
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
    /// �p�ӂ��ꂽ�f�[�^����ɃV�[����ɃJ�����_�[���쐬����B
    /// </summary>
    private void CreateCalendar()
    {
        int day = 1;
        for (int i = 0; i < _cellCount; i++)
        {
            if (i >= _firstWeek && i < DateTime.DaysInMonth(_year, _month) + _firstWeek)
            {
                _week = (Week)FindDay(day);
                var d = Instantiate(_day, transform);
                d.name = $"Day_{i}";
                _days[i] = d;
                _days[i].Date = day;
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

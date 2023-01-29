using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    [SerializeField] int _yearData;
    [SerializeField] int _monthData;
    [SerializeField] TMP_Text _yearText;
    [SerializeField] TMP_Text _monthText;
    [SerializeField] Month _month;

    void Start()
    {
        ApplyCalendar();
    }

    public void ApplyCalendar()
    {
        _yearText.text = $"{_yearData}";
        _monthText.text = $"{_monthData}";
        _month.InitMonthData(_yearData, _monthData);
    }
}

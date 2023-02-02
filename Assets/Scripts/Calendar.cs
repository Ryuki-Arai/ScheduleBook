using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Calendar : MonoBehaviour, IPointerClickHandler
{
    [SerializeField,Range(1,9999)] int _yearData = DateTime.Today.Year;
    [SerializeField,Range(1,12)] int _monthData = DateTime.Today.Month;
    [SerializeField] TMP_Text _yearText;
    [SerializeField] TMP_Text _monthText;
    [SerializeField] TMP_InputField _yearInputField;
    [SerializeField] TMP_InputField _monthInputField;
    [SerializeField] Month _month;
    [SerializeField] Popup _popup;

    void Start()
    {
        _month.InitMonthData();
        DrawCalendar();
    }

    public void DrawCalendar()
    {
        if(_yearInputField.text != "")
        {
            _yearData = int.Parse(_yearInputField.text);
            _yearInputField.text = "";
        }
        if (_monthInputField.text != "")
        {
            _monthData = int.Parse(_monthInputField.text);
            _monthInputField.text = "";
        } 
        _yearText.text = $"{_yearData}”N";
        _monthText.text = $"{_monthData}ŒŽ";
        _month.ApplyCalendar(_yearData,_monthData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject.TryGetComponent(out Day obj))
        {
            foreach (var day in _month.Days)
            {
                if (obj.Date == day.Date && day.Date.week != Week.None)
                {
                    _popup.ApplyTexts(day);
                }
            }
        }
    }
}

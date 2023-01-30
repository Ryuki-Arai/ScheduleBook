using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Calendar : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] int _yearData;
    [SerializeField] int _monthData;
    [SerializeField] TMP_Text _yearText;
    [SerializeField] TMP_Text _monthText;
    [SerializeField] Month _month;
    [SerializeField] Popup _popup;

    void Start()
    {
        DrawCalendar();
    }

    public void DrawCalendar()
    {
        _yearText.text = $"{_yearData}";
        _monthText.text = $"{_monthData}";
        _month.InitMonthData(_yearData, _monthData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject.TryGetComponent(out Day obj))
        {
            foreach (var d in _month.Days)
            {
                if (obj.Date == d.Date && d.Week != Week.None)
                {
                    _popup.OnApplyTexts(_yearData, _monthData, d.Date, d.Week, d.Schedules);
                }
            }
        }
    }
}

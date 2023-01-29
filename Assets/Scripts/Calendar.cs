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
    [SerializeField] GameObject _popup;

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

    public void OnPointerClick(PointerEventData eventData)
    {
        var obj = eventData.pointerCurrentRaycast.gameObject.GetComponent<Day>()._Day;
        foreach(var d in _month.Days)
        {
            if(obj == d._Day)
            {
                Debug.Log($"Find:{_monthData},{d._Day}");
            }
        }
    }
}

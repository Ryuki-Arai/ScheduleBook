using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Day : MonoBehaviour
{
    [SerializeField] DayOfWeek _week = default;
    public DayOfWeek Week 
    {
        get => _week;
        set 
        { 
            _week = value;
            OnColorChanged();
        }
    }
    [SerializeField] TMP_Text _dayText = default;
    [SerializeField] Image _image = default;
    [SerializeField] List<string> _plan = new List<string>();
    int _day = 0;
    public int _Day
    {
        get => _day;
        set
        {
            _day = value;
            OnValueChanged();
        }
    }

    private void OnValueChanged()
    {
        _dayText.text = _day.ToString();
    }

    private void OnValidate()
    {
        OnColorChanged();
    }

    private void OnColorChanged()
    {
        if(_image != null)
        {
            if (_week == DayOfWeek.Sunday)
            {
                _image.color = Color.red;
            }
            else if (_week == DayOfWeek.Saturday)
            {
                _image.color = Color.blue;
            }
            else
            {
                _image.color = Color.white;
            }
        }
    }
}

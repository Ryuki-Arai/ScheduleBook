using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Day : MonoBehaviour
{
    [SerializeField] DayOfWeek _week = default;
    [SerializeField] TMP_Text _day = default;
    [SerializeField] Image _image = default;
    [SerializeField] List<string> _plan = new List<string>();

    private void OnValidate()
    {
        OnCellColorChanged();
    }

    private void OnCellColorChanged()
    {
        if(_image != null)
        {
            if (_week == DayOfWeek.Sunday)
            {
                _image.color = Color.red;
                Debug.Log(_week);
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

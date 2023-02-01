using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] TMP_Text _dateText;
    [SerializeField] TMP_Text _scheduleText;
    [SerializeField] TMP_InputField _scheduleInputField;

    public void ApplyTexts(Date date)
    {
        _dateText.text = $"{date.year}/{date.month}/{date.day} ({date.week})";
        gameObject.SetActive(true);
        _scheduleText.text = "";
        if(date.schedule.Count == 0) return;
        foreach(var schedule in date.schedule)
        {
            _scheduleText.text += $"{schedule}\n";
        }
    }

    public void ApplySchedule()
    {
        _scheduleText.text += $"{_scheduleInputField.text}\n";
    }
}

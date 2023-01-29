using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] TMP_Text _dateText;

    public void OnApplyTexts(int yyyy,int MM, int dd, Week day, List<string> schedules)
    {
        _dateText.text = $"{yyyy}/{MM}/{dd} ({day})";
        gameObject.SetActive(true);
        foreach(var schedule in schedules)
        {

        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 日にちを管理するクラス。
/// 日付・曜日・その日の予定を所持する。
/// </summary>
public class Day : MonoBehaviour
{
    [SerializeField] Date _date;
    [SerializeField] TMP_Text _dateText = default;
    [SerializeField] Image _image = default;
    public Date Date
    {
        get => _date;
        set
        {
            _date = value;
            OnColorChanged();
            OnValueChanged();
        }
    }

    /// <summary>
    /// スケジュールをデータリストに追加する。
    /// </summary>
    /// <param name="contents">スケジュール内容</param>
    public void AddSchedule(string contents)
    {
        _date.schedule.Add(contents);
    }

    /// <summary>
    /// 日付のテキストを更新する。
    /// </summary>
    private void OnValueChanged()
    {
        _dateText.text = _date.day != 0 ? _date.day.ToString(): "";
    }

    private void OnValidate()
    {
        OnColorChanged();
    }

    /// <summary>
    /// 曜日によってUIの色を変える。
    /// </summary>
    private void OnColorChanged()
    {
        if(_image != null)
        {
            if (_date.week == Week.Sunday)
            {
                _image.color = Color.red;
            }
            else if (_date.week == Week.Saturday)
            {
                _image.color = Color.blue;
            }
            else if(_date.week == Week.None)
            {
                _image.color = Color.gray;
                _dateText.text = "";
            }
            else
            {
                _image.color = Color.white;
            }
        }
    }
}

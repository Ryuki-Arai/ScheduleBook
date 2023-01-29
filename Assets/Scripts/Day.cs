using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// ���ɂ����Ǘ�����N���X�B
/// ���t�E�j���E���̓��̗\�����������B
/// </summary>
public class Day : MonoBehaviour
{
    [SerializeField] Week _week = default;
    public Week Week 
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
    [SerializeField] List<string> _schedules = new List<string>();
    public List<string> Schedules => _schedules;
    int _date = 0;
    public int Date
    {
        get => _date;
        set
        {
            _date = value;
            OnValueChanged();
        }
    }

    /// <summary>
    /// �X�P�W���[�����f�[�^���X�g�ɒǉ�����B
    /// </summary>
    /// <param name="contents">�X�P�W���[�����e</param>
    public void AddSchedule(string contents)
    {
        _schedules.Add(contents);
    }

    /// <summary>
    /// ���t�̃e�L�X�g���X�V����B
    /// </summary>
    private void OnValueChanged()
    {
        _dayText.text = _date.ToString();
    }

    private void OnValidate()
    {
        OnColorChanged();
    }

    /// <summary>
    /// �j���ɂ����UI�̐F��ς���B
    /// </summary>
    private void OnColorChanged()
    {
        if(_image != null)
        {
            if (_week == Week.Sunday)
            {
                _image.color = Color.red;
            }
            else if (_week == Week.Saturday)
            {
                _image.color = Color.blue;
            }
            else if(_week == Week.None)
            {
                _image.color = Color.gray;
                _dayText.text = "";
            }
            else
            {
                _image.color = Color.white;
            }
        }
    }
}

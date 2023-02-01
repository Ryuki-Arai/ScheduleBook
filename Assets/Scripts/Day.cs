using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// ���ɂ����Ǘ�����N���X�B
/// ���t�E�j���E���̓��̗\�����������B
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
    /// �X�P�W���[�����f�[�^���X�g�ɒǉ�����B
    /// </summary>
    /// <param name="contents">�X�P�W���[�����e</param>
    public void AddSchedule(string contents)
    {
        _date.schedule.Add(contents);
    }

    /// <summary>
    /// ���t�̃e�L�X�g���X�V����B
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
    /// �j���ɂ����UI�̐F��ς���B
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

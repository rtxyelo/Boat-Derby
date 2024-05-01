using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXButtonsController : MonoBehaviour
{
    [SerializeField]
    private Image _musicBtnImage;

    [SerializeField]
    private Image _soundBtnImage;

    [SerializeField]
    private Sprite _audioOnSprite;

    [SerializeField]
    private Sprite _audioOffSprite;

    private AudioController _audioController;

    private readonly string _musicKey = "Music";

    private readonly string _soundKey = "Sound";

    private void OnEnable()
    {
        CheckButtonsStatus();
    }

    public void Initialize()
    {
        _audioController = FindObjectOfType<AudioController>();
    }
    public void ChangeMusic()
    {
        _audioController.ChangeMusic();
        CheckButtonsStatus();
    }

    public void ChangeSound()
    {
        _audioController.ChangeSound();
        CheckButtonsStatus();
    }

    private void CheckButtonsStatus()
    {
        if (PlayerPrefs.GetInt(_musicKey) == 0)
            _musicBtnImage.sprite = _audioOffSprite;
        else
            _musicBtnImage.sprite = _audioOnSprite;

        if (PlayerPrefs.GetInt(_soundKey) == 0)
            _soundBtnImage.sprite = _audioOffSprite;
        else
            _soundBtnImage.sprite = _audioOnSprite;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _levelText;

    [SerializeField] private AudioSource asseptSound;
    [SerializeField] private AudioSource declineSound;
    [SerializeField] private List<TMP_Text> listOfButtonText = new(5);

    [SerializeField] private Color selectLvlColor;
    [SerializeField] private Color openedLvlColor;
    private Color closedLvlColor = Color.red;

    private readonly string maxLevelKey = "MaxLevel";
    private readonly string currentLevelKey = "Level";
    private readonly string _soundKey = "Sound";

    private void Start()
    {
        if (!PlayerPrefs.HasKey(maxLevelKey))
            PlayerPrefs.SetInt(maxLevelKey, 0);

        if (!PlayerPrefs.HasKey(_soundKey))
            PlayerPrefs.SetInt(_soundKey, 0);

        if (!PlayerPrefs.HasKey(currentLevelKey))
            PlayerPrefs.SetInt(currentLevelKey, 0);

        _levelText.text = (PlayerPrefs.GetInt(currentLevelKey, 0) + 1).ToString();

        int btnInd = 0;
        foreach (var text in listOfButtonText)
        {
            if (btnInd > PlayerPrefs.GetInt(maxLevelKey))
                text.color = closedLvlColor;

            else if (btnInd != PlayerPrefs.GetInt(currentLevelKey))
                text.color = openedLvlColor;

            else
                text.color = selectLvlColor;
            btnInd++;
        }
    }

    /// <summary>
    /// Check level availability by level number.
    /// </summary>
    /// <param name="lvl">Level number.</param>
    public void CheckLevelAvailability(int lvl)
    {
        if (!PlayerPrefs.HasKey(_soundKey))
            PlayerPrefs.SetInt(_soundKey, 0);

        if (!PlayerPrefs.HasKey(currentLevelKey))
            PlayerPrefs.SetInt(currentLevelKey, 0);

        if (!PlayerPrefs.HasKey(maxLevelKey))
            PlayerPrefs.SetInt(maxLevelKey, 0);

        else if (lvl <= PlayerPrefs.GetInt(maxLevelKey))
        {
            PlayerPrefs.SetInt(currentLevelKey, lvl);
            Debug.Log("currentLevelKey " + PlayerPrefs.GetInt(currentLevelKey, 0));

            _levelText.text = (PlayerPrefs.GetInt(currentLevelKey, 0) + 1).ToString();

            int btnInd = 0;
            foreach (var text in listOfButtonText)
            {
                if (btnInd > PlayerPrefs.GetInt(maxLevelKey))
                    text.color = closedLvlColor;

                else if (btnInd != PlayerPrefs.GetInt(currentLevelKey, 0))
                    text.color = openedLvlColor;

                else
                    text.color = selectLvlColor;
                btnInd++;
            }

            if (PlayerPrefs.GetInt(_soundKey) != 0)
            {
                asseptSound.volume = PlayerPrefs.GetInt(_soundKey, 0);
                asseptSound.Play();
            }

            //SceneController.LoadSceneByName("Game");
        }
        else
        {
            if (PlayerPrefs.GetInt(_soundKey) != 0)
            {
                declineSound.volume = PlayerPrefs.GetInt(_soundKey);
                declineSound.Play();
            }
        }
    }
}

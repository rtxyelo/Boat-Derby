using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyController : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyCountText;
    private string _moneyCountKey = "MoneyCount";

    private int _moneyCount;

    // Start is called before the first frame update
    void Awake()
    {
        if (!PlayerPrefs.HasKey(_moneyCountKey))
            PlayerPrefs.SetInt(_moneyCountKey, 0);

        _moneyCount = PlayerPrefs.GetInt(_moneyCountKey);

        ShowMoneyFunc();
    }

    public void SetMoneyCount(int moneyCount)
    {
        _moneyCount += moneyCount;

        PlayerPrefs.SetInt(_moneyCountKey, _moneyCount);

        ShowMoneyFunc();
    }

    public void ShowMoneyFunc()
    {
        //PlayerPrefs.SetInt(_moneyCountKey, 0);
        if (_moneyCountText != null)
            _moneyCountText.text = $"$ {PlayerPrefs.GetInt(_moneyCountKey, 0)}";
    }
}

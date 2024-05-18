using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ShopBehaviour : MonoBehaviour
{
    [SerializeField] private TMP_Text BoatName;

    private string _currentBoatKey = "CurrentBoat";
    private string _moneyCountKey = "MoneyCount";
    private string _hasNormalBoatKey = "HasNormalBoat";
    private string _hasMeduimBoatKey = "HasMediumBoat";
    private string _hasHardBoatKey = "HasHardBoat";

    [SerializeField] private GameObject _selectBtnTextObj;
    [SerializeField] private GameObject _selectBtnTextShadowObj;
    [SerializeField] private GameObject _balanceObj;


    [SerializeField] private List<GameObject> _boats = new(4);

    private TMP_Text _balanceText;
    private TMP_Text _selectBtnText;
    private TMP_Text _selectBtnTextShadow;

    private GameObject ShopObj;

    private int curentBoat = 0;
    private int maxBoat = 4;
    private int _normalBoatPrice = 500;
    private int _mediumBoatPrice = 2000;
    private int _hardBoatPrice = 5000;


    // Start is called before the first frame update
    void Start()
    {
        ShopObj = gameObject;
        if (!PlayerPrefs.HasKey(_currentBoatKey))
            PlayerPrefs.SetInt(_currentBoatKey, 0);
        if (!PlayerPrefs.HasKey(_moneyCountKey))
            PlayerPrefs.SetInt(_moneyCountKey, 0);
        if (!PlayerPrefs.HasKey(_hasNormalBoatKey))
            PlayerPrefs.SetInt(_hasNormalBoatKey, 0);
        if (!PlayerPrefs.HasKey(_hasMeduimBoatKey))
            PlayerPrefs.SetInt(_hasMeduimBoatKey, 0);
        if (!PlayerPrefs.HasKey(_hasHardBoatKey))
            PlayerPrefs.SetInt(_hasHardBoatKey, 0);


        //PlayerPrefs.SetInt(_currentBoatKey, 0);
        //PlayerPrefs.SetInt(_moneyCountKey, 0);
        //PlayerPrefs.SetInt(_hasNormalBoatKey, 0);
        //PlayerPrefs.SetInt(_hasMeduimBoatKey, 0);
        //PlayerPrefs.SetInt(_hasHardBoatKey, 0);


        Debug.Log("currentBoat " + PlayerPrefs.GetInt(_currentBoatKey, 0));
        Debug.Log("moneyCount " + PlayerPrefs.GetInt(_moneyCountKey, 0));
        Debug.Log("_hasNormalBoat " + PlayerPrefs.GetInt(_hasNormalBoatKey, 0));
        Debug.Log("hasMeduimBoat " + PlayerPrefs.GetInt(_hasMeduimBoatKey, 0));
        Debug.Log("hasHardBoat " + PlayerPrefs.GetInt(_hasHardBoatKey, 0));

        _selectBtnText = _selectBtnTextObj.GetComponent<TMP_Text>();
        _selectBtnTextShadow = _selectBtnTextShadowObj.GetComponent<TMP_Text>();
        _balanceText = _balanceObj.transform.GetChild(0).GetComponent<TMP_Text>();
        _balanceText.text = "$ " + PlayerPrefs.GetInt(_moneyCountKey, 0).ToString();

        if (curentBoat == PlayerPrefs.GetInt(_currentBoatKey, 0))
        {
            PlayerPrefs.SetInt(_currentBoatKey, 0);
            _selectBtnText.text = "Selected";
            _selectBtnTextShadow.text = "Selected";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    #region Public Methods
    public void BoatSelect()
    {
        // Easy boat
        if (curentBoat == 0)
        {
            if (curentBoat != PlayerPrefs.GetInt(_currentBoatKey, 0))
            {
                PlayerPrefs.SetInt(_currentBoatKey, 0);
                _selectBtnText.text = "Selected";
                _selectBtnTextShadow.text = "Selected";
            }
        }
        // Normal boat
        if (curentBoat == 1)
        {
            // Just select
            if (curentBoat != PlayerPrefs.GetInt(_currentBoatKey, 0) && PlayerPrefs.GetInt(_hasNormalBoatKey, 0) == 1)
            {
                PlayerPrefs.SetInt(_currentBoatKey, 1);
                _selectBtnText.text = "Selected";
                _selectBtnTextShadow.text = "Selected";

                Debug.Log("_currentBoatKey " + PlayerPrefs.GetInt(_currentBoatKey, 0));
                Debug.Log("_moneyCountKey " + PlayerPrefs.GetInt(_moneyCountKey, 0));
                Debug.Log("_hasNormalBoatKey " + PlayerPrefs.GetInt(_hasNormalBoatKey, 0));
                Debug.Log("_hasMeduimBoatKey " + PlayerPrefs.GetInt(_hasMeduimBoatKey, 0));
                Debug.Log("_hasHardBoatKey " + PlayerPrefs.GetInt(_hasHardBoatKey, 0));
            }
            // Else try to buy
            else if (PlayerPrefs.GetInt(_hasNormalBoatKey, 0) == 0)
            {
                BuyBoat(curentBoat);
            }
        }
        // Medium Boat
        else if (curentBoat == 2)
        {
            // Just select
            if (curentBoat != PlayerPrefs.GetInt(_currentBoatKey, 0) && PlayerPrefs.GetInt(_hasMeduimBoatKey, 0) == 1)
            {
                PlayerPrefs.SetInt(_currentBoatKey, 2);
                _selectBtnText.text = "Selected";
                _selectBtnTextShadow.text = "Selected";

                Debug.Log("_currentBoatKey " + PlayerPrefs.GetInt(_currentBoatKey, 0));
                Debug.Log("_moneyCountKey " + PlayerPrefs.GetInt(_moneyCountKey, 0));
                Debug.Log("_hasNormalBoatKey " + PlayerPrefs.GetInt(_hasNormalBoatKey, 0));
                Debug.Log("_hasMeduimBoatKey " + PlayerPrefs.GetInt(_hasMeduimBoatKey, 0));
                Debug.Log("_hasHardBoatKey " + PlayerPrefs.GetInt(_hasHardBoatKey, 0));
            }
            // Else try to buy
            else if (PlayerPrefs.GetInt(_hasMeduimBoatKey, 0) == 0)
            {
                BuyBoat(curentBoat);
            }
        }
        // Hard boat
        if (curentBoat == 3)
        {
            // Just select
            if (curentBoat != PlayerPrefs.GetInt(_currentBoatKey, 0) && PlayerPrefs.GetInt(_hasHardBoatKey, 0) == 1)
            {
                PlayerPrefs.SetInt(_currentBoatKey, 3);
                _selectBtnText.text = "Selected";
                _selectBtnTextShadow.text = "Selected";

                Debug.Log("_currentBoatKey " + PlayerPrefs.GetInt(_currentBoatKey, 0));
                Debug.Log("_moneyCountKey " + PlayerPrefs.GetInt(_moneyCountKey, 0));
                Debug.Log("_hasNormalBoatKey " + PlayerPrefs.GetInt(_hasNormalBoatKey, 0));
                Debug.Log("_hasMeduimBoatKey " + PlayerPrefs.GetInt(_hasMeduimBoatKey, 0));
                Debug.Log("_hasHardBoatKey " + PlayerPrefs.GetInt(_hasHardBoatKey, 0));
            }
            // Else try to buy
            else if (PlayerPrefs.GetInt(_hasHardBoatKey, 0) == 0)
            {
                BuyBoat(curentBoat);
            }
        }
    }
    public void MoveSide(bool side)
    {
        if (side)
        {
            if (curentBoat < maxBoat - 1)
            {
                curentBoat++;
                _boats.ForEach(boat => { boat.SetActive(false); });
                _boats[curentBoat].SetActive(true);
                SetName(curentBoat);
                SetSelectButtonText(curentBoat);
            }
        }
        else
        {
            if (curentBoat > 0)
            {
                curentBoat--;
                _boats.ForEach(boat => { boat.SetActive(false); });
                _boats[curentBoat].SetActive(true);
                SetName(curentBoat);
                SetSelectButtonText(curentBoat);
            }
        }
    }

    #endregion

    #region Private Methods

    private void BuyBoat(int boatForBuy)
    {
        // Normal boat
        if (boatForBuy == 1)
        {
            if (PlayerPrefs.GetInt(_moneyCountKey, 0) >= _normalBoatPrice)
            {
                PlayerPrefs.SetInt(_hasNormalBoatKey, 1);
                PlayerPrefs.SetInt(_moneyCountKey, PlayerPrefs.GetInt(_moneyCountKey, 0) - _normalBoatPrice);
                _balanceText.text = "$ " + PlayerPrefs.GetInt(_moneyCountKey, 0).ToString();
                _selectBtnText.text = "Select";
                _selectBtnTextShadow.text = "Select";

                Debug.Log("_currentBoatKey " + PlayerPrefs.GetInt(_currentBoatKey, 0));
                Debug.Log("_moneyCountKey " + PlayerPrefs.GetInt(_moneyCountKey, 0));
                Debug.Log("_hasNormalBoatKey " + PlayerPrefs.GetInt(_hasNormalBoatKey, 0));
                Debug.Log("_hasMeduimBoatKey " + PlayerPrefs.GetInt(_hasMeduimBoatKey, 0));
                Debug.Log("_hasHardBoatKey " + PlayerPrefs.GetInt(_hasHardBoatKey, 0));
            }
        }
        // Medium boat
        else if (boatForBuy == 2)
        {
            if (PlayerPrefs.GetInt(_moneyCountKey, 0) >= _mediumBoatPrice)
            {
                PlayerPrefs.SetInt(_hasMeduimBoatKey, 1);
                PlayerPrefs.SetInt(_moneyCountKey, PlayerPrefs.GetInt(_moneyCountKey, 0) - _mediumBoatPrice);
                _balanceText.text = "$ " + PlayerPrefs.GetInt(_moneyCountKey, 0).ToString();
                _selectBtnText.text = "Select";
                _selectBtnTextShadow.text = "Select";

                Debug.Log("_currentBoatKey " + PlayerPrefs.GetInt(_currentBoatKey, 0));
                Debug.Log("_moneyCountKey " + PlayerPrefs.GetInt(_moneyCountKey, 0));
                Debug.Log("_hasNormalBoatKey " + PlayerPrefs.GetInt(_hasNormalBoatKey, 0));
                Debug.Log("_hasMeduimBoatKey " + PlayerPrefs.GetInt(_hasMeduimBoatKey, 0));
                Debug.Log("_hasHardBoatKey " + PlayerPrefs.GetInt(_hasHardBoatKey, 0));
            }
        }
        // Hard boat
        else if (boatForBuy == 3)
        {
            if (PlayerPrefs.GetInt(_moneyCountKey, 0) >= _hardBoatPrice)
            {
                PlayerPrefs.SetInt(_hasHardBoatKey, 1);
                PlayerPrefs.SetInt(_moneyCountKey, PlayerPrefs.GetInt(_moneyCountKey, 0) - _hardBoatPrice);
                _balanceText.text = "$ " + PlayerPrefs.GetInt(_moneyCountKey, 0).ToString();
                _selectBtnText.text = "Select";
                _selectBtnTextShadow.text = "Select";

                Debug.Log("_currentBoatKey " + PlayerPrefs.GetInt(_currentBoatKey, 0));
                Debug.Log("_moneyCountKey " + PlayerPrefs.GetInt(_moneyCountKey, 0));
                Debug.Log("_hasNormalBoatKey " + PlayerPrefs.GetInt(_hasNormalBoatKey, 0));
                Debug.Log("_hasMeduimBoatKey " + PlayerPrefs.GetInt(_hasMeduimBoatKey, 0));
                Debug.Log("_hasHardBoatKey " + PlayerPrefs.GetInt(_hasHardBoatKey, 0));
            }
        }
    }

    private IEnumerator MoveCorutine(Vector3 aim)
    {
        Vector3 step = (Vector3.zero - aim) / 20f;
        for (int i = 0; i < 20; i++)
        {
            ShopObj.transform.position += step;
            yield return null;
        }
    }

    private void SetSelectButtonText(int _curentBoatNum)
    {
        Debug.Log("_currentBoatKey " + PlayerPrefs.GetInt(_currentBoatKey, 0));
        Debug.Log("_currentBoat " + curentBoat);

        // Current select boat
        int currBoat = PlayerPrefs.GetInt(_currentBoatKey, 0);

        // Easy boat
        if (_curentBoatNum == 0 && currBoat != _curentBoatNum)
        {
            _selectBtnText.text = "Select";
            _selectBtnTextShadow.text = "Select";
        }
        else if (_curentBoatNum == 0 && currBoat == _curentBoatNum)
        {
            _selectBtnText.text = "Selected";
            _selectBtnTextShadow.text = "Selected";
        }

        // Normal boat
        else if (_curentBoatNum == 1 && currBoat != _curentBoatNum && PlayerPrefs.GetInt(_hasNormalBoatKey, 0) == 1)
        {
            _selectBtnText.text = "Select";
            _selectBtnTextShadow.text = "Select";
        }
        else if (_curentBoatNum == 1 && currBoat == _curentBoatNum && PlayerPrefs.GetInt(_hasNormalBoatKey, 0) == 1)
        {
            _selectBtnText.text = "Selected";
            _selectBtnTextShadow.text = "Selected";
        }
        else if (_curentBoatNum == 1 && PlayerPrefs.GetInt(_hasNormalBoatKey, 0) != 1)
        {
            _selectBtnText.text = $"BUY ${_normalBoatPrice}";
            _selectBtnTextShadow.text = $"BUY ${_normalBoatPrice}";
        }

        // Medium boat
        else if (_curentBoatNum == 2 && currBoat != _curentBoatNum && PlayerPrefs.GetInt(_hasMeduimBoatKey, 0) == 1)
        {
            _selectBtnText.text = "Select";
            _selectBtnTextShadow.text = "Select";
        }
        else if (_curentBoatNum == 2 && currBoat == _curentBoatNum && PlayerPrefs.GetInt(_hasMeduimBoatKey, 0) == 1)
        {
            _selectBtnText.text = "Selected";
            _selectBtnTextShadow.text = "Selected";
        }
        else if (_curentBoatNum == 2 && PlayerPrefs.GetInt(_hasMeduimBoatKey, 0) != 1)
        {
            _selectBtnText.text = $"BUY ${_mediumBoatPrice}";
            _selectBtnTextShadow.text = $"BUY ${_mediumBoatPrice}";
        }

        // Hard boat
        else if (_curentBoatNum == 3 && currBoat != _curentBoatNum && PlayerPrefs.GetInt(_hasHardBoatKey, 0) == 1)
        {
            _selectBtnText.text = "Select";
            _selectBtnTextShadow.text = "Select";
        }
        else if (_curentBoatNum == 3 && currBoat == _curentBoatNum && PlayerPrefs.GetInt(_hasHardBoatKey, 0) == 1)
        {
            _selectBtnText.text = "Selected";
            _selectBtnTextShadow.text = "Selected";
        }
        else if (_curentBoatNum == 3 && PlayerPrefs.GetInt(_hasHardBoatKey, 0) != 1)
        {
            _selectBtnText.text = $"BUY ${_hardBoatPrice}";
            _selectBtnTextShadow.text = $"BUY ${_hardBoatPrice}";
        }
    }


    private void SetName(int boatNum)
    {
        if (curentBoat == 0)
        {
            BoatName.text = "Easy Boat";
        }
        if (curentBoat == 1)
        {
            BoatName.text = "Normal Boat";
        }
        if (curentBoat == 2)
        {
            BoatName.text = "Medium Boat";
        }
        if (curentBoat == 3)
        {
            BoatName.text = "Heavy Boat";
        }
    }

    #endregion
}
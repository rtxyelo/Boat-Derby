using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtacleBorder : MonoBehaviour
{
    [SerializeField]
    private ScoreCounter _scoreCounter;

    [SerializeField]
    private MoneyController _moneyController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (_moneyController != null)
                _moneyController.SetMoneyCount(2);

            if (_scoreCounter != null)
                _scoreCounter.IncreaseScore();
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinTextManager : MonoBehaviour
{
    public TextMeshProUGUI coinDisplay;

    public void LateUpdate()
    {
        coinDisplay.text = "" + PlayerPrefs.GetInt("Coin").ToString();
    }
}

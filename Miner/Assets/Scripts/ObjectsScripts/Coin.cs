using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinHolder=1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + coinHolder);
            Destroy(this.gameObject);
        }
    }
}

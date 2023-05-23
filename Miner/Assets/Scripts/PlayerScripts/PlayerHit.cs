using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("pot"))
        {
            other.GetComponent<pot>().DestroyPot();
        }if (other.CompareTag("breakable"))
        {
            Destroy(other.gameObject);
        }
    }
}

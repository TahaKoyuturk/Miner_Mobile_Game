using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessObject : MonoBehaviour
{

    [SerializeField] private Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Open", true);
        }
    }
    
}

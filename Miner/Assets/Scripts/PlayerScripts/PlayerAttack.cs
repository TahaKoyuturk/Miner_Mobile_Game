using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Animator animator;
    public void Attack()
    {
        StartCoroutine(AttackGo());
    }
    private IEnumerator AttackGo()
    {
        animator.SetBool("Attacking", true);
        yield return new WaitForSeconds(.13f);
        animator.SetBool("Attacking", false);
        yield return new WaitForSeconds(.8f);
        
    }
}

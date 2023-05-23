using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void DestroyPot()
    {
        if(animator!=null)
            animator.SetBool("smash", true);
        StartCoroutine(breakPot());
    }
    IEnumerator breakPot()
    {
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
    }
}

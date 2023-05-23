using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Animator animator;
    public void PlayGame()
    {
        StartCoroutine(Play());
    }
    public void OptionsMenu()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }
    IEnumerator Play()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Dungeon");
    }
}

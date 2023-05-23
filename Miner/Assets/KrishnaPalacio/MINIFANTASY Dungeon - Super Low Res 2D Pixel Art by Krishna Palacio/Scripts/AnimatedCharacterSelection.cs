using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedCharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    private GameObject activeCharacter;
    private Animator currentAnimator;
    private string currentParameter = "Idle";

    private void Start()
    {
        foreach (var character in characters)
        {
            character.SetActive(false);
        }
        activeCharacter = characters[0];
        activeCharacter.SetActive(true);
        currentAnimator = activeCharacter.GetComponentInChildren<Animator>();
    }

    public void TurnOffCurrentParameter()
    {
        currentAnimator.SetBool(currentParameter, false);
    }

    public void ToggleAnimation(string nextParameter)
    {
        currentAnimator.SetTrigger("Clicked");
        currentAnimator.SetBool(nextParameter, true);
        currentParameter = nextParameter;
    }

    public void ToggleXDirection(float x)
    {
        currentAnimator.SetFloat("X", x);
    }
    public void ToggleYDirection(float y)
    {
        currentAnimator.SetFloat("Y", y);
    }

    public void ToggleCharacter(int characterListIndex)
    {
        if (activeCharacter.name == characters[characterListIndex].name)
        {
            return;
        }
        activeCharacter.SetActive(false);
        activeCharacter = characters[characterListIndex];
        activeCharacter.SetActive(true);
        currentAnimator = activeCharacter.GetComponentInChildren<Animator>();
    }
}

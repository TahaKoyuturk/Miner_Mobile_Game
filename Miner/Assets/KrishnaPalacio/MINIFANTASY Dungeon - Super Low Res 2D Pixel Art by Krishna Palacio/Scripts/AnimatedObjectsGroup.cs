using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedObjectsGroup : MonoBehaviour
{
    public List<GameObject> groupObjects = new List<GameObject>();
    public List<Animator> animators = new List<Animator>();

    private void Start()
    {
        foreach (GameObject item in groupObjects)
        {
            if (item != null)
            {
                if (item.transform.childCount > 1)
                {
                    for (int i = 0; i < item.transform.childCount; i++)
                    {
                        animators.Add(item.transform.GetChild(i).GetComponentInChildren<Animator>());
                    }
                }
                else
                {
                    animators.Add(item.GetComponentInChildren<Animator>());
                }
            }
        }
    }

    public void OnOffSwitch(bool onOrOff)
    {
        foreach (Animator item in animators)
        {
            item.enabled = onOrOff;
        }
    }
}

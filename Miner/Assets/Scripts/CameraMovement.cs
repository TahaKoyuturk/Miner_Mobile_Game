using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    private Vector2 maxPos;
    private Vector2 minPos;
    public Vector2 maxPos1;
    public Vector2 minPos1;
    public Vector2 maxPos2;
    public Vector2 minPos2;
    public Vector2 maxPos3;
    public Vector2 minPos3;
    public Vector2 maxPos4;
    public Vector2 minPos4;
    private void Update()
    {
        if (PlayerPrefs.GetInt("Level")==0)
        {
            minPos = minPos1;
            maxPos = maxPos1;
        }
        else if(PlayerPrefs.GetInt("Level") == 1)
        {
            minPos = minPos2;
            maxPos = maxPos2;
        }else if(PlayerPrefs.GetInt("Level") == 2)
        {
            minPos = minPos3;
            maxPos = maxPos3;
        }
        else if (PlayerPrefs.GetInt("Level") == 3)
        {
            minPos = minPos4;
            maxPos = maxPos4;
        }
    }
    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);
            transform.position = Vector3.Lerp(transform.position,
                                                targetPos,
                                                smoothing);
        }
    }
}

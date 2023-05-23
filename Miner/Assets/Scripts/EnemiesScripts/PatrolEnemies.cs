using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PatrolEnemies : WoodEnemy
{
    public Transform[] path;
    public Transform currentGoal;
    public int currentPoint;
    public float roundingDistance;
    private bool isRounded=false;
    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius &&
            Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            rb.MovePosition(temp);
            ChangeAnim(temp - transform.position);
            animator.SetBool("wakeUp", true);
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            if (Vector3.Distance(transform.position, path[currentPoint].position) >= roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);
                rb.MovePosition(temp);
                ChangeAnim(temp - transform.position);
            }
            else
            {
                ChangeGoal();
            }
            
        }
    }
    private void ChangeGoal()
    {
        if(currentPoint == path.Length - 1)
        {
            isRounded = true;
            currentGoal = path[currentPoint];
        }
        if (currentPoint == 0)
        {
            isRounded = false;
            currentGoal = path[currentPoint];
        }
        if (isRounded)
        {
            currentPoint--;
            currentGoal = path[currentPoint];
        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }


}

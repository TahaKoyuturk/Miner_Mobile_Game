using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WoodEnemy : Enemy
{
    public float thrust;
    public float knockTime;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Animator animator;
    public Rigidbody2D rb;
    [SerializeField] private Slider slider;
    void Start(){
        target = GameObject.FindWithTag("Player").transform;
        slider.maxValue = maxHealth.initialValue;
        animator.SetBool("wakeUp", true);
    }
    void Update()
    {
        CheckDistance();
    }
    public virtual void CheckDistance()
    {
        if (Vector3.Distance(target.position,transform.position) <= chaseRadius &&
            Vector3.Distance(target.position,transform.position)>attackRadius)
        {
            Vector3 temp= Vector3.MoveTowards(transform.position,target.position,moveSpeed*Time.deltaTime);
            rb.MovePosition(temp);
            ChangeAnim(temp - transform.position);
            animator.SetBool("wakeUp", true);
        }
        else if(Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            animator.SetBool("wakeUp", false);
        }
    }
    private void SetAnimFloat(Vector2 setVector)
    {
        animator.SetFloat("moveX", setVector.x);
        animator.SetFloat("moveY", setVector.y);
    }
    public void ChangeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }
    public void Knock(Rigidbody2D r2d, float knockTime)
    {
        StartCoroutine(knock(r2d, knockTime));
    }
    IEnumerator knock(Rigidbody2D r2d, float knockTime)
    {
        if (r2d != null)
        {
            yield return new WaitForSeconds(knockTime);
            r2d.velocity = Vector2.zero;
        }
        else
            yield return new WaitForSeconds(0.25f);
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Rigidbody2D hit = collision.gameObject.GetComponent<Rigidbody2D>();
    //        if (hit != null)
    //        {
    //            hit.isKinematic = false;
    //            Vector2 dif = hit.transform.position - transform.position;
    //            dif = dif.normalized * thrust;
    //            hit.AddForce(dif, ForceMode2D.Impulse);
    //            hit.isKinematic = true;
    //            Knock(hit, knockTime);
    //        }
    //    }
    //}
    private void OnGUI()
    {
        slider.value = health;
    }
}

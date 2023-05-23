using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;

    private void Start()
    {
        health = maxHealth.initialValue;
    }

    public void Knock(Rigidbody2D r2d,float knockTime,float damage)
    {
        StartCoroutine(knock(r2d, knockTime));
        TakeDamage(damage);
    }
    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator knock(Rigidbody2D r2d,float knockTime)
    {
        if (r2d != null)
        {
            yield return new WaitForSeconds(knockTime);
            r2d.velocity = Vector2.zero;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.isTrigger)
        {
            if (attackSpeed <= canAttack)
            {
                collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
                canAttack += Time.fixedDeltaTime;
        }
    }
}

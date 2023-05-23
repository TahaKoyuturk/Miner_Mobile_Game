using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && collision.isTrigger )
        {
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                hit.isKinematic = false;
                Vector2 dif = hit.transform.position - transform.position;
                dif = dif.normalized * thrust;
                hit.AddForce(dif, ForceMode2D.Impulse);
                hit.isKinematic = true;
                if (collision.isTrigger && collision.isActiveAndEnabled)
                {
                    collision.GetComponent<Enemy>().Knock(hit, knockTime,damage);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement Instance { get; private set; }
    public FixedJoystick joystick;
    public Rigidbody2D rb;
    private Animator animator;
    public float moveSpeed = 5f;
    Vector3 move;
    [SerializeField] private GameObject[] levels = new GameObject[4];
    [SerializeField] private Transform[] spawnSpot = new Transform[4];

    private void Awake()
    {
        animator = GetComponent<Animator>();
        PlayerPrefs.DeleteAll();
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = spawnSpot[PlayerPrefs.GetInt("Level")].position;
    }
    void Update()
    {
        move = Vector2.zero;
        move.x = joystick.Horizontal;
        move.y = joystick.Vertical;

        UpdateAnimationAndMove();
    }
    void UpdateAnimationAndMove()
    {
        if (move != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", move.x);
            animator.SetFloat("moveY", move.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    private void MoveCharacter()
    {
        move.Normalize();
        rb.MovePosition(transform.position + move * moveSpeed * Time.fixedDeltaTime); 
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
        }else
             yield return new WaitForSeconds(0.25f);
    }
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

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gate"))
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            levels[PlayerPrefs.GetInt("Level")].active = true;
            levels[PlayerPrefs.GetInt("Level")-1].active = false;
            transform.position = spawnSpot[PlayerPrefs.GetInt("Level")].position;
        }
        if (other.gameObject.CompareTag("BackGate"))
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") - 1);
            levels[PlayerPrefs.GetInt("Level")].active = true;
            levels[PlayerPrefs.GetInt("Level")+1].active = false;
            transform.position = spawnSpot[PlayerPrefs.GetInt("Level")].position;
        }
    }
}

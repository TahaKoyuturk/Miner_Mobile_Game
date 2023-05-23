using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider slider;
    public Color low, high;
    public Vector3 Offset;
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    private void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
    }

    public void UpdateHealth(float mod)
    {
        health += mod;
        if (health > maxHealth)
        {
            health = maxHealth;
        }else if (health <=0f)
        {
            health = 0f;
            print("Player Respawn");
        }
    }
    private void OnGUI()
    {
        slider.value = health;
    }
}

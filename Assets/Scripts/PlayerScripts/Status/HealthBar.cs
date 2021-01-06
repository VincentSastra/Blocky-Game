using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private RectTransform fill;
    private float startWidth;
    public int maxHealth;
    public int currentHealth;

    void Start() {
        fill = GetComponent<RectTransform>();
        startWidth = fill.rect.width;
    }
    public void SetMaxHealth(int health)
    {
        maxHealth = health;
        this.currentHealth = health;
    }

    public void SetHealth(int health)
    {
        currentHealth = health;
        fill.sizeDelta = new Vector2(startWidth * health / maxHealth, fill.sizeDelta.y);
    }
}

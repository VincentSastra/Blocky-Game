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
    public Gradient gradient;
    private Image image;
    void Start() {
        fill = GetComponent<RectTransform>();
        startWidth = fill.rect.width;
        image = GetComponent<Image>();
    }
    public void SetMaxHealth(int health)
    {
        maxHealth = health;
        SetHealth(health);
    }

    public void SetHealth(int health)
    {
        currentHealth = health;
        fill.sizeDelta = new Vector2(startWidth * health / maxHealth, fill.sizeDelta.y);
        image.color = gradient.Evaluate((float)health / maxHealth);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemyCoreController : MonoBehaviour
{
    public EconomyManager economyManager;
    public TextMeshProUGUI healthText;
    public int maxHealth = 100;

    private int currentHealth;

    private void Start() {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void GetDamage(int damage) {
        currentHealth -= damage;
        UpdateHealthText();

        if (currentHealth < 0) {
            currentHealth = 0;
            SceneManager.LoadScene("WinScene");
        }
    }

    private void UpdateHealthText() {
        healthText.text = "Health: " + currentHealth.ToString();
    }
}

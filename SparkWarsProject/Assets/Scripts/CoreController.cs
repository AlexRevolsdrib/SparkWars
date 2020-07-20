using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoreController : MonoBehaviour
{
    public EconomyManager economyManager;
    public TextMeshProUGUI healthText;
    public int maxHealth = 100;

    private int currentHealth;

	private void Start() {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

	private void OnMouseDown()
    {
        economyManager.AddEnergy();
    }

    public void GetDamage(int damage) {
        currentHealth -= damage;
        UpdateHealthText();

        if (currentHealth < 0) {
            currentHealth = 0;
        }
	}

    private void UpdateHealthText() {
        healthText.text = "Health: " + currentHealth.ToString();
	}
}

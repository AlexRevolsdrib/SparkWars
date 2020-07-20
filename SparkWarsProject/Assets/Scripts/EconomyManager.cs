using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconomyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int firstSparkPrice = 1;
    public int secondSparkPrice = 3;
    public int thirdSparkPrice = 7;
    public TextMeshProUGUI energyText;

    int energy;

    void Start()
    {
        ResetEnergy();
    }

    public void ResetEnergy()
    {
        energy = 0;
        UpdateEnergyText();
    }

    public void AddEnergy(int amount = 1) {
        energy += amount;
        UpdateEnergyText();
    }

    public int BuySpark() {
        int sparkPrice = 0;
        if (energy >= thirdSparkPrice) {
            sparkPrice = thirdSparkPrice;
		} else if (energy >= secondSparkPrice) {
            sparkPrice = secondSparkPrice;
        } else if (energy >= firstSparkPrice) {
            sparkPrice = firstSparkPrice;
        }
        energy -= sparkPrice;
        UpdateEnergyText();
        return sparkPrice;
	}

    private void UpdateEnergyText() {
        energyText.text = "Energy: " + energy.ToString();
	}
}

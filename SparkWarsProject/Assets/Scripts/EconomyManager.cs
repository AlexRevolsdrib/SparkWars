using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int firstSparkPrice = 1;
    public int secondSparkPrice = 3;
    public int thirdSparkPrice = 7;

    int energy;

    void Start()
    {
        ResetEnergy();
    }

    public void ResetEnergy()
    {
        energy = 0;
    }

    public void AddEnergy(int amount = 1) {
        energy += amount;
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
        return sparkPrice;
	}
}

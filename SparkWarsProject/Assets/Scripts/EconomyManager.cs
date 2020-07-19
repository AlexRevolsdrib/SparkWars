using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    // Start is called before the first frame update
    int energy;
    int healPower = 150;
    void Start()
    {
        energy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setEnergy()
    {
        energy++;
    }

    public int buySpark()
    {
        int power=0;
        if(energy >= 3)
            power = 3;
        else if(energy >= 5)
            power = 5;
        else if (energy >= 7)
            power = 5;
        energy -= power;
        return power;
    }

    public void Damage(int damage)
    {
        healPower -= damage;
    }
}

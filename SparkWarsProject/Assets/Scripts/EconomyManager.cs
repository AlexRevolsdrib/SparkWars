using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    // Start is called before the first frame update
    int Energy;
    void Start()
    {
        Energy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setEnergy()
    {
        Energy++;
    }

    public void buySpark()
    {
        Energy = 0;
    }

}

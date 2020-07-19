using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreController : MonoBehaviour
{
    public EconomyManager economyManager;

    private void OnMouseDown()
    {
        economyManager.setEnergy();
    }

}

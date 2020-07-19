using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    // Start is called before the first frame update
    public TrackController track;
    public EconomyManager economyManager;
    public SparkController sparkController;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        int power = economyManager.buySpark();
        if (power!=0)
        {
             sparkController.setEnergy(power);
            sparkController.track = track;
            sparkController.transform.tag = "PlayerSpark";
            Instantiate(sparkController, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    // Start is called before the first frame update
    public TrackController track;
    public EconomyManager economyManager;
    public SparkController sparkPrefab;
    public Transform spawnPoint;

    private void OnMouseDown()
    {
        int power = economyManager.buySpark();
        if (power!=0)
        {
            SparkController spark = Instantiate(sparkPrefab, spawnPoint.position, Quaternion.identity);

            spark.setEnergy(power);
            spark.track = track;
            spark.transform.tag = "PlayerSpark";
            
        }
        
    }
}

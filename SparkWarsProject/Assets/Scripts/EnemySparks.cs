using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySparks : MonoBehaviour
{
    public TrackController[] tracks;
    public SparkController sparkController;
    private bool isRunningCoroutine;

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!isRunningCoroutine)
        {
            StartCoroutine("CreateSpark");
            isRunningCoroutine = true;
        }

    }

    IEnumerator CreateSpark()
    {
        yield return new WaitForSeconds(Random.Range(0f, 2f));
        SparkController spark = Instantiate(sparkController, transform.position, Quaternion.identity);
        spark.SetEnergy(RndSparkCharge());
        spark.track = tracks[Random.Range(0, 3)];
        isRunningCoroutine = false;
    }

    private int RndSparkCharge() {
        int rndNumber = Random.Range(1, 4);
        switch (rndNumber) {
            case 1:
                return 1;
            case 2:
                return 3;
            case 3:
                return 7;
            default:
                return 0;
		}
    }
}

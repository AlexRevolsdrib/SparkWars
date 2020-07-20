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
        SparkController spark = Instantiate(sparkController, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        spark.SetEnergy(Random.Range(1, 11));
        spark.track = tracks[Random.Range(0, 3)];
        //spark.transform.tag = "EnemySpark";
        isRunningCoroutine = false;
    }
}

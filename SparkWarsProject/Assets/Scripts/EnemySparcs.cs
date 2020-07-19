using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySparcs : MonoBehaviour
{
    public TrackController[] tracks;
    public SparkController sparkController;
    private bool runingCoroutine;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (!runingCoroutine)
        {
            StartCoroutine("CreateSpark");
            runingCoroutine = true;
        }
        
    }

    IEnumerator CreateSpark()
    {
        
            
        yield return new WaitForSeconds(Random.Range(0f, 2f));
        SparkController spark = Instantiate(sparkController, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        spark.setEnergy(Random.Range(1, 11));
        spark.track = tracks[Random.Range(0, 3)];
        spark.transform.tag = "EnemySpark";
        runingCoroutine = false;
    }
}

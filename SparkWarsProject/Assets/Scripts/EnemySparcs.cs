using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySparcs : MonoBehaviour
{
    public TrackController track;
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
        
            sparkController.setEnergy(10);
            sparkController.track = track;
            sparkController.transform.tag = "EnemySpark";
            yield return new WaitForSeconds(2f);
        Instantiate(sparkController, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        runingCoroutine = false;
    }
}

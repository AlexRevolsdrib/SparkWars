using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private Transform target;
    public TrackController track;
    private int numberPoint = 0;
    public int energy;
    void Start()
    {
        numberPoint = 0;
        target = track.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, target.position)<=0.2f)
        {
            GetNextPoint();
        }
    }

    void GetNextPoint()
    { 
        if(numberPoint >= track.points.Length-1)
        {
            Destroy(gameObject);
        }
        else
        {
            numberPoint++;
            target = track.points[numberPoint];
        }
        
    }
    public void setEnergy(int power)
    {
        energy = power;
    }
}

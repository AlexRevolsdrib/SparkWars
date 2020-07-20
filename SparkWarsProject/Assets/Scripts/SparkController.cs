using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkController : MonoBehaviour
{
    public float speed = 5f;
    public TrackController track;
    public int energy;

    private Transform target;
    private int numberPoint;

    void Start()
    {
        
        if(transform.CompareTag("PlayerSpark"))
            numberPoint = 0;
        else if(transform.tag == "EnemySpark")
            numberPoint = track.points.Length - 1;
        target = track.points[numberPoint];
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, target.position)<=0.2f)
        {
            GetNextPoint();
        }
    }

    void GetNextPoint()
    {
		if (transform.CompareTag("PlayerSpark")) {
            if (numberPoint >= track.points.Length - 1) {
                Destroy(gameObject);
            }
            else {
                numberPoint++;
                target = track.points[numberPoint];
            }
        }
        else {
            if (numberPoint <= 0) {
                Destroy(gameObject);
            }
            else {
                numberPoint--;
                target = track.points[numberPoint];
            }
        }
            
        
    }
    public void SetEnergy(int sparkPrice) {
        energy = sparkPrice;
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("EnemySpark")) {
            SparkController spark = collision.gameObject.GetComponent<SparkController>();
          
            if (spark.energy - energy <= 0)
            { 
                Destroy(collision.gameObject);
            }
            if (energy - spark.energy <= 0)
            {
                Destroy(gameObject);
            }
            energy -= spark.energy;
        } else if (collision.gameObject.CompareTag("PlayerCore")) {
            CoreController playerCore = collision.gameObject.GetComponent<CoreController>();
            playerCore.GetDamage(energy);
            Destroy(gameObject);
		}
    }
}

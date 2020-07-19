using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private Transform target;
    public TrackController track;
    private int numberPoint;
    public int energy;

    void Start()
    {
        
        if(transform.tag == "PlayerSpark")
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
        if (transform.tag == "PlayerSpark")
        {
            if (numberPoint >= track.points.Length - 1)
            {
                Destroy(gameObject);
            }
            else
            {
                numberPoint++;
                target = track.points[numberPoint];
            }
        }
        else
        {
            if (numberPoint <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                numberPoint--;
                target = track.points[numberPoint];
            }
        }
            
        
    }
    public void setEnergy(int power)
    {
        energy = power;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("EnemySpark"))
        {
            int damage = collision.gameObject.GetComponent<SparkController>().energy;
          
            if (damage - energy <= 0)
            {
                
                Destroy(collision.gameObject);
            }
            if (energy - damage <= 0)
            {
                Destroy(gameObject);
            }
            energy -= damage;

        }
        

    }
}

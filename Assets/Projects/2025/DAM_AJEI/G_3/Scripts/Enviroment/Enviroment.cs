using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment : MonoBehaviour
{
    public float speed;
    public float Realspeed;
    public bool direction;
    public bool stop;

    public Transform place1;
    public Transform place2;
    public int rand;

    private void Start()
    {
        Realspeed = speed;
    }

    void Update()
    {
        if (direction)
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * Realspeed;
        }
        else
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * Realspeed;
        }

        if(stop)
        {
            Realspeed = 0;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("limit"))
        {
            StartCoroutine(Persons());
        }
    }

    IEnumerator Persons()
    {
        stop = true;
        yield return new WaitForSeconds(Random.Range(1, 5));

        rand = Random.Range(0, 1);
        if(rand == 1)
        {
            if (direction == true)
            {
                direction = false;
                stop = false;
                Realspeed = speed;
            }
            else
            {
                direction = true;
                stop = false;
                Realspeed = speed;
            }
        }
        if(rand == 0)
        {
            if (direction == true)
            {
                transform.position = place1.position;
                stop = false;
                Realspeed = speed;               
            }
            else
            {
                transform.position = place2.position;
                stop = false;
                Realspeed = speed;
            }
            
        }

        
    }
}

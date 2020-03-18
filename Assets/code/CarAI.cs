using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CarAI : MonoBehaviour
{

    public GameObject[] waypoints;
    public GameObject[] brakes;
    private float speed = 0f;
    int nextWaypoint = 0;
    public float rotatespeed = 2.5f;
    float accuracy = 0.5f;
    float maxSpeed = 150f;
    float breakingpoint = 100f;
    float breakspeed = 100f;

    // Use this for initialization
    void Start()
    {

        waypoints = GameObject.FindGameObjectsWithTag("Waypoint").OrderBy(go => go.name).ToArray();
        brakes = GameObject.FindGameObjectsWithTag("Brakes").OrderBy(go => go.name).ToArray();

    }

    // Update is called once per frame
    void Update()
    {

            if (Vector3.Distance(waypoints[nextWaypoint].transform.position, transform.position) < accuracy)
            {

                nextWaypoint++;
                if (nextWaypoint >= waypoints.Length)
                {
                    nextWaypoint = 0;
                }
            }

        if (speed <= maxSpeed)
        {
            speed += 0.2f;
        }
        


        transform.position = Vector3.MoveTowards(transform.position, waypoints[nextWaypoint].transform.position, Time.deltaTime * speed);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(waypoints[nextWaypoint].transform.position - transform.position), 0.1f);

        if (Vector3.Distance(this.transform.position, GameObject.Find("Brake").transform.position) < breakingpoint)
        {
            if (speed >= breakspeed)
                speed -= 1f;

        }

        if (Vector3.Distance(this.transform.position, GameObject.Find("cbrake").transform.position) < breakingpoint)
        {
            if (speed >= breakspeed)
                speed -= 1f;

        }

        print(speed);

    }

    void OnGUI()
    {
        GUI.contentColor = Color.red;
        GUI.Label(new Rect(10, 10, 100, 20), "Speed " + speed + " km/h");
    }
}

 


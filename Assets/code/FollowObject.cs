using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FollowObject : MonoBehaviour {

   // Object targ = GameObject.Find("Cylinder").transform.position;

    float speed = 0f;
    float maxSpeed = 150f;
    float breakingpoint = 100f;
    float breakspeed = 90f;
    public GameObject[] brakes;
    int nextBreakpoint = 0;



    // Use this for initialization
    void Start () {

        brakes = GameObject.FindGameObjectsWithTag("Brakes").OrderBy(go => go.name).ToArray();

    }
	
	// Update is called once per frame
	void Update () {

        if (speed <= maxSpeed)
        {
            speed += 0.2f;

        }
        transform.position = Vector3.MoveTowards(this.transform.position, GameObject.Find("Cylinder").transform.position, Time.deltaTime * speed);
        //transform.LookAt(GameObject.Find("Cylinder").transform.position);

       this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(GameObject.Find("Cylinder").transform.position - transform.position), 0.1f);


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


    }
}


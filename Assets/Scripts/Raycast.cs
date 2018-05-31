using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray hitdirect = new Ray(transform.position, Camera.main.transform.forward);
        Debug.DrawLine(transform.position, transform.position + Camera.main.transform.forward * 100, Color.red);
        //print(Physics.Raycast(hitdirect, out hit));
        if (Physics.Raycast(hitdirect, out hit))
        {
            print(hit.collider.name);
            if (hit.collider.name == "oa5t") //in the editor, tag anything you want to interact with and use it here
            {
                print("This is a oa5t");
            }

        }
    }
}

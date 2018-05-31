using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToStart : MonoBehaviour {

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
            if (hit.collider.name == "Sphere_red") //in the editor, tag anything you want to interact with and use it here
            {
                SceneManager.LoadScene("start");
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Set_Active : MonoBehaviour {
    public GameObject ribbon;
    public GameObject BS;
    // Use this for initialization
	void Start () {
        ribbon.SetActive(true);
        BS.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (CameraControl.isribbon == true)
        {
            ribbon.SetActive(true);
            BS.SetActive(false);
        }
        else if (CameraControl.isribbon == false) {
            ribbon.SetActive(false);
            BS.SetActive(true);
        }
	}
}

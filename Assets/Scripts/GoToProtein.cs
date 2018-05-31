using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Leap;
using Leap.Unity;

public class GoToProtein : MonoBehaviour
{
    LeapProvider provider;
    // Use this for initialization
    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;

    }

    // Update is called once per frame
    void Update()
    {
        Frame frame = provider.CurrentFrame;
        var hands = frame.Hands;

        RaycastHit hit;
        Ray hitdirect = new Ray(transform.position, Camera.main.transform.forward);
        Debug.DrawLine(transform.position, transform.position + Camera.main.transform.forward * 100, Color.red);
        //print(Physics.Raycast(hitdirect, out hit));
        if (Physics.Raycast(hitdirect, out hit))
        {

            if (hit.collider.name == "Cube_5aot") //in the editor, tag anything you want to interact with and use it here
            {
                print(hit.collider.name);
                if (hands.Count >= 2 && hands[0].PinchStrength == 1 && hands[1].PinchStrength == 1)
                {
                    SceneManager.LoadScene("5aot_Scene");
                }

            }
            else if (hit.collider.name == "Cube_5aoz") //in the editor, tag anything you want to interact with and use it here
            {
                //SceneManager.LoadScene("5aoz_Scene");

                if (hands.Count >= 2 && hands[0].PinchStrength == 1 && hands[1].PinchStrength == 1)
                {
                    print(hit.collider.name);
                    SceneManager.LoadScene("5aoz_Scene");
                }

            }
            else if (Input.GetKey(KeyCode.F))
            {
                print(123);
                SceneManager.LoadScene("5aoz_Scene");
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                print("to main");
                SceneManager.LoadScene("MainMenu");
            }

        }
    }
}

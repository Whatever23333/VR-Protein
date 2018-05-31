using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;
using UnityEngine.SceneManagement;

public class CameraControl : MonoBehaviour
{
    // Use this for initialization  
    private GameObject gameObject;
    float speed = 0.15f;
    public static bool isribbon = true;
    public static bool isBS = false;
    LeapProvider provider;
    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        gameObject = GameObject.Find("LMHeadMountedRig");
        
    }

    // Update is called once per frame  
    void Update()
    {
        Frame frame = provider.CurrentFrame;
        var hands = frame.Hands;

        RaycastHit hit;
        Ray hitdirect = new Ray(transform.position, Camera.main.transform.forward);
        Debug.DrawLine(transform.position, transform.position + Camera.main.transform.forward * 100, Color.red);

        if (hands.Count >= 2)
        {
            if (hands[0].GrabStrength == 1 && hands[1].GrabStrength == 1)//双手握拳
            {
                Vector3 direction = Camera.main.transform.forward;
                this.gameObject.transform.Translate(direction * speed);
            }
            else if (hands[0].PinchStrength >= 0.8 && hands[1].PinchStrength >= 0.8)//双手OK
            {
                //do some things
                Vector3 direction = Camera.main.transform.forward;
                this.gameObject.transform.Translate(-direction * speed);
            }

        }
        if (Input.GetKey(KeyCode.F))
        {
            Vector3 direction = Camera.main.transform.forward;
            this.gameObject.transform.Translate(direction * speed);
        }
        if (Input.GetKey(KeyCode.G))
        {
            Vector3 direction = Camera.main.transform.forward;
            this.gameObject.transform.Translate(-direction * speed);
        }

        if (Physics.Raycast(hitdirect, out hit))
        {
            
            if (hit.collider.name == "Sphere_red") //in the editor, tag anything you want to interact with and use it here
            {
                print(hit.collider.name);
                if (hands.Count >= 2 && hands[0].PinchStrength >= 0.8 && hands[1].PinchStrength >= 0.8)
                {
                    SceneManager.LoadScene("Start");
                }

            }
            if (hit.collider.name == "Sphere_yellow") //in the editor, tag anything you want to interact with and use it here
            {
                print(hit.collider.name);
                if (hands.Count >= 2 && hands[0].PinchStrength >= 0.8 && hands[1].PinchStrength >= 0.8)
                {
                    isribbon = true;
                    isBS = false;
                }

            }
            if (hit.collider.name == "Sphere_green") //in the editor, tag anything you want to interact with and use it here
            {
                print(hit.collider.name);
                if (hands.Count >= 2 && hands[0].PinchStrength >= 0.8 && hands[1].PinchStrength >= 0.8)
                {
                    isribbon = false;
                    isBS = true;
                }

            }

        }
    }
}
using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;

public class MoveScript : MonoBehaviour
{

    public static bool isForward = false;
    public static bool isCatchBall = false;
    public static bool isThrowBall = false;
    public static bool isBack = false;
    public float Dist;
    public static Vector3 rightHandPos;
    public static float scaleFactor = 0.5f;
    public bool isPeaceSign = false;

    // Use this for initialization
    public GameObject protein;
    float speed = 10;


    LeapProvider provider;
    //public GameObject controlledObject;
    //public GameObject camera;


    //private float realMoveSpeed;

    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        //mTiger = GameObject.Find("Tiger");
        //mTiger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        Frame frame = provider.CurrentFrame;
        var hands = frame.Hands;
        
    float ho = 1 * speed * Time.deltaTime;


        float ve = 1 * speed * Time.deltaTime;
        if (hands.Count == 1)
        {
            if (hands[0].IsRight && hands[0].GrabStrength == 1)
            {
                GetComponent<Transform>().Rotate(0, ho, 0, Space.World);
            }
            else if (hands[0].IsLeft && hands[0].GrabStrength == 1)
            {
                GetComponent<Transform>().Rotate(ve, 0, 0, Space.World);
            }
            else if(hands[0].IsRight && hands[0].PinchStrength==1)
            {
                //zoom in
                GetComponent<Transform>().localScale += new Vector3(0.01F, 0.01f, 0.01f);
            }
            else if (hands[0].IsLeft && hands[0].PinchStrength == 1)
            {
                //zoom in
                GetComponent<Transform>().localScale -= new Vector3(0.01F, 0.01f, 0.01f);
            }
            /*
            else if (hands[0].IsRight && isPeaceSign==true)
            {
                transform.Translate(Camera.main.transform.forward * -scaleFactor);
            }
            */
        }




        /* (hands.Count >= 2)
        {
            if (hands[0].GrabStrength == 1 && hands[1].GrabStrength == 1)//双手握拳
            {
                //isForward = true;
                //Debug.Log("Forwarding");
                //GetComponent<Transform>().Rotate(0, ho, 0, Space.World);
                transform.Translate(Camera.main.transform.forward * -scaleFactor);
            }
            else if (hands[0].PinchStrength >= 0.8 && hands[1].PinchStrength >= 0.8)//双手OK
            {
                //do some things
                //isBack = true;
                //GetComponent<Transform>().Rotate(ve, 0, 0, Space.World);
                //Debug.Log("Backing");
                transform.Translate(Camera.main.transform.forward * scaleFactor);
            }

        }*/

        //else if (hands.Count == 1)
        //{
        //    if (hands[0].IsRight)
        //    {
        //        rightHandPos = hands[0].PalmPosition.ToVector3();

        //    }
        //    if (hands[0].IsRight && hands[0].GrabStrength == 1)
        //    {
        //        //catch the ball
        //        //isCatchBall=true;

        //    }
        //    if (hands[0].IsRight && hands[0].GrabStrength == 0 && MainCharacterController.CurrentStateID == StateID.MovingWithBall)
        //    {
        //        //throw the ball
        //        //isCatchBall=false;
        //        isThrowBall = true;
        //    }
        //}
        else
        {
            //No hand is detected
            isForward = false;
            //isCatchBall = false;
           // isThrowBall = false;
            isBack = false;
        }
    }
}




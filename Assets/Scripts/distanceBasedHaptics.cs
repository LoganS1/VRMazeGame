using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class distanceBasedHaptics : MonoBehaviour
{
    private Vector3 controllerPosL, controllerPosR;
    private GameObject[] walls;
    private GameObject end;

    public XRBaseController controllerL, controllerR;
    public float defaultAmplitude = 0.2f;
    public float defaultDuration = 0.5f;

    public bool usePulses = false;
    public float periodL = 0.0f;
    public float periodR = 0.0f;
    public float intervalL = 0.1f;
    public float intervalR = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        walls = GameObject.FindGameObjectsWithTag("Wall");
        Application.targetFrameRate = 90;
    }

    // Update is called once per frame
    void Update()
    {

        controllerPosL = GameObject.Find("LeftHand Controller").transform.position;
        controllerPosR = GameObject.Find("RightHand Controller").transform.position;

        float closestDistanceL = 999f;
        float closestDistanceR = 999f;

        foreach (GameObject wall in walls)
        {
            Vector3 closestPointL = wall.GetComponent<Collider>().ClosestPointOnBounds(controllerPosL);
            Vector3 closestPointR = wall.GetComponent<Collider>().ClosestPointOnBounds(controllerPosR);
            float distanceL = Vector3.Distance(closestPointL, controllerPosL);
            float distanceR = Vector3.Distance(closestPointR, controllerPosR);
            if (distanceL < closestDistanceL)
                closestDistanceL = distanceL;
            if (distanceR < closestDistanceR)
                closestDistanceR = distanceR;
            
        }

        // Debug.Log("L " + closestDistanceL);
        // Debug.Log("R " + closestDistanceR);

        if(!usePulses){
            if (closestDistanceL < 0.2f)
            {
                controllerL.SendHapticImpulse((1 - closestDistanceL*5f), 0.1f);
            }
            if (closestDistanceR < 0.2f)
            {
                controllerR.SendHapticImpulse((1 - closestDistanceR*5f), 0.1f);
            }
        }else{
            if (closestDistanceL < 0.3f)
            {
                if (periodL > closestDistanceL*5f)
                {
                    controllerL.SendHapticImpulse(1, 0.05f);
                    periodL = 0;
                }
            }
            if (closestDistanceR < 0.3f)
            {
                if (periodR > closestDistanceR*5f)
                {
                    controllerR.SendHapticImpulse(1, 0.05f);
                    periodR = 0;
                }
            }
            periodL += UnityEngine.Time.deltaTime;
            periodR += UnityEngine.Time.deltaTime;
        }


    }
}
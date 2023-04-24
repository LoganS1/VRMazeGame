using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class distanceBasedHaptics : MonoBehaviour
{
    private Vector3 controllerPosL, controllerPosR;
    private GameObject[] walls;

    public XRBaseController controllerL, controllerR;
    public float defaultAmplitude = 0.2f;
    public float defaultDuration = 0.5f;

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

        if (closestDistanceL < 1)
        {
            controllerL.SendHapticImpulse((1 - closestDistanceL), 0.1f);
        }
        if (closestDistanceR < 1)
        {
            controllerR.SendHapticImpulse((1 - closestDistanceR), 0.1f);
        }


    }
}
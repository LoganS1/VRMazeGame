using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class menuInteraction : MonoBehaviour
{
    private GameObject[] menuItems;

    public XRBaseController controllerL, controllerR;

    // Start is called before the first frame update
    void Start()
    {
        menuItems = GameObject.FindGameObjectsWithTag("menuItem");
        Application.targetFrameRate = 90;
    }

    // Update is called once per frame
    void Update()
    {
        controllerPosL = GameObject.Find("LeftHand Controller").transform.position;
        controllerPosR = GameObject.Find("RightHand Controller").transform.position;


    }
}

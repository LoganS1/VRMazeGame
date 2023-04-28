using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlay : MonoBehaviour
{
    private GameObject end;
    private GameObject mainCamera;
    private Vector3 closestPoint;
    private Vector3 mainCameraPos;
    AudioSource audioSrc;
    public AudioClip audioClip;
    private bool done;
    // Start is called before the first frame update
    void Start()
    {
        // audioSrc = GetComponent<AudioSource>();
        end = GameObject.Find("end");
        mainCamera = GameObject.Find("Main Camera");
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        mainCameraPos = mainCamera.transform.position;
        closestPoint = end.GetComponent<Collider>().ClosestPointOnBounds(mainCameraPos);
        float distance = Vector3.Distance(closestPoint, mainCameraPos);
        if(distance < 0.5f && !done){
            audioSrc.PlayOneShot(audioSrc.clip, 1f);
            done = true;
        }
    }
}

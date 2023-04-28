using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackOutScreen : MonoBehaviour
{
    public Texture blackTexture;
    public bool screenBlackOut = false;


    void Update(){
        if(Input.GetButtonDown("Fire1")){
            if(screenBlackOut == false){
                screenBlackOut = true;
            }
            else{
                screenBlackOut = false;
            }
        }
    }


    void OnGUI(){
        if(screenBlackOut){
            GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), blackTexture);
        }
    }
}

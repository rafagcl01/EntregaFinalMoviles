using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;


public class CameraManager : MonoBehaviour
{

    private Camera camara1;  //normal 
    private Camera camara2;  //inversa
    public Camera ActiveCamera;
    private bool CamaraCambiada = false;



    void Awake()
    {
        camara1 = GameObject.Find("Camera Normal").GetComponent<Camera>();
        camara2 = GameObject.Find("Camera Inversa").GetComponent<Camera>();

        camara2.enabled = false;
    }

    // Update is called once per frame
    public void UpdateCamera(string idTablero)
    {

        if (idTablero == "normal")
        {
            camara1.enabled = true;
            camara2.enabled = false;
            CamaraCambiada = true;
        }

        else if (idTablero == "inverso")
        {
            camara1.enabled = false;
            camara2.enabled = true;
            CamaraCambiada = true;
        }
    }


    void FixedUpdate()
    {
        if (CamaraCambiada == true)
        {
            ActiveCamera = Camera.main;
            CamaraCambiada = false;
        }
    }
}


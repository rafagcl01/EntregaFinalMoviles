using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;



public class RaycastComponent : MonoBehaviour
{

    public void Update()
    {

        RaycastHit hit;


        string Terreno;


        //raycast para detectar el tipo de terreno sobre el que está el jugador
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            BoardCube onCube = hit.collider.GetComponent<BoardCube>();
            //dDebug.Log("detectado el cubo" + onCube.Row + onCube.Col);

            Terreno = onCube.FormaTablero;

            Renderer renderer = onCube.GetComponent<Renderer>();
            Material currentMaterial = renderer.material;

            //Debug.Log(onCube.currentMaterial.name);

            if (onCube.obstacle == true)
            {
                //usamos singleton para saber la causa de la muerte y posteriormente cambiar el contenido la pantalla de derrota
                DeathManager.Instance.causeOfDeath = "obstaculo";
                SceneManager.LoadScene("EndScene");



            }


            if (onCube.victory == true)
            {
                DeathManager.Instance.causeOfDeath = "victoria";
                SceneManager.LoadScene("EndScene");
            }

        }


    }
}


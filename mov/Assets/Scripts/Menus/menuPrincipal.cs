using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class menuPrincipal : MonoBehaviour
{

    public string condicionPantalla;

    public GameObject textoZombie;
    public GameObject textoObstaculo;
    public GameObject textoVictoria;

    public void BacktoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    


    public void IniciarScenaJuego()
    {
        SceneManager.LoadScene("Game");
    }

    public void Awake()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("EndScene")){

            condicionPantalla = DeathManager.Instance.causeOfDeath;
            textoVictoria = GameObject.Find("Victoria");
            textoZombie = GameObject.Find("DerrotaEnemigo");
            textoObstaculo = GameObject.Find("DerrotaObstaculo");

            if(condicionPantalla == "obstaculo"){
                textoVictoria.SetActive(false);
                textoZombie.SetActive(false);
                textoObstaculo.SetActive(true);

            } else if(condicionPantalla == "zombie"){
                textoVictoria.SetActive(false);
                textoZombie.SetActive(true);
                textoObstaculo.SetActive(false);
        
            } else if(condicionPantalla == "victoria"){
                textoVictoria.SetActive(true);
                textoZombie.SetActive(false);
                textoObstaculo.SetActive(false);       
        
            }
        }
    }

   
}

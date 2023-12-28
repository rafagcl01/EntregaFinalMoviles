using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class enemyComponent : MonoBehaviour
{

    public float playerPower;
    public float zombiePower;

    [SerializeField] GameManager World;
    [SerializeField] TextMesh powerText;

    // Start is called before the first frame update
    void Start()
    {
        World = FindAnyObjectByType<GameManager>();
        
        powerText = transform.GetComponentInChildren<TextMesh>();
        powerText.text = "Poder requerido: " + zombiePower;
    }

    public void OnTriggerEnter()
    {

        playerPower = World.playerPower;
        if (playerPower >= zombiePower)
        {
            gameObject.SetActive(false);
            Debug.Log("enemigo derrotado");

        }

        if (playerPower < zombiePower)
        {
            //usamos singleton para saber la causa de la muerte y cambiar la pantalla de derrota
            DeathManager.Instance.causeOfDeath = "zombie";
            SceneManager.LoadScene("EndScene");


        }
    }

}

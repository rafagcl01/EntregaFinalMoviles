using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerItem : MonoBehaviour
{
    GameManager world;

    public void Start()
    {
        world = FindAnyObjectByType<GameManager>();
    }
    public void OnTriggerEnter()
    {
        print("chocado");
        gameObject.SetActive(false);
        world.playerPower += 1;
    }
}

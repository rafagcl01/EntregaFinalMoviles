
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI powerText;
    public PauseManager menuPausa;

    public Player player;
    public bool Paused = false;
    public int playerPower = 0;

    private int last;
    private int now;

    private void Awake()
    {

        last = playerPower;
        powerText.text = "Poder: " + playerPower;

    }


    void Update()
    {
        now = playerPower;
        if (now > last)
        {
            powerText.text = "Poder: " + playerPower;
        }
  
        

    }
}
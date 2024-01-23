
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI powerText;
    [SerializeField] GameObject PauseMenu;

    public Player player;
    public bool Paused = false;
    public int playerPower = 0;

    private int last;
    private int now;

    public float shakeThreshold = 1f;     //ajustar para agitar el movil
    public float ChangeCooldown = 0.5f; //cooldown entre cambios

    private float lastChangeTime;


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

        if (Input.acceleration.magnitude > shakeThreshold && Time.time - lastChangeTime >= ChangeCooldown)
        {
            player.Swap();
            lastChangeTime = Time.time;
        }

    }



    ///////////////////////////////////// PAUSE

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        Paused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        Paused = true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }





}
using System.Collections.Generic;

using UnityEngine;



public class Player : MonoBehaviour
{
    GameManager World;
    Board board;
    public CameraManager CameraController;

    private string tablero = "normal";
    private Vector3 saltoTablero = new Vector3(0, 50, 0);
    private Vector3 prueba;
    public float speed;
    private bool moving;
    private Vector3 newPosition;

    private BoardCube boardPos;
 



    private void Awake()
    {
        World = FindAnyObjectByType<GameManager>();
        //CameraController = FindAnyObjectByType<CameraManager>();
    }

    public void Move(Vector3 direction)     //al implementar el interfaz, es obligado a implementar sus metodos
    {
        if (!moving)                    //MOVE SOLO CALCULA LA NUEVA POSICION PERO NO MUEVE AL PERSONAJE
        {
            newPosition = transform.position + direction * 1.05f; //este 1.05 es una unidad de cubo mas 0.05 de espacio entre cubos
            moving = true;
            //animator.SetFloat(MoveSpeed, speed);
        }
    }

    public void Swap()
    {
        if (!moving)
        {

            //CAMBIAR TABLERO
            if (tablero == "normal")
            {
                prueba = transform.position + saltoTablero;
                tablero = "inverso";
                transform.position = prueba;
                CameraController.UpdateCamera(tablero);
            }
            else if (tablero == "inverso")
            {
                tablero = "normal";
                transform.position = transform.position - saltoTablero;
                CameraController.UpdateCamera(tablero);
            }


        }
    }

    private void Update()
    {
        if (World.Paused == false)        //implementamos el menu de pausa
        {
            //implementacion de cada comando
            if (Input.GetKeyDown(KeyCode.F))
            {
                Swap();
            }

            //NUEVO

            else if (Input.GetKeyDown(KeyCode.W))        //para cada tecla, crea una instancia del comando correspondiente
            {

                Move(Vector3.forward);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {

                Move(Vector3.back);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {

                Move(Vector3.left);

            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Move(Vector3.right);
            }

        }
    }

    private void FixedUpdate()      //servia para actualizar el juego con un delta siempre igual (aqui se mueve el pers)
    {


        

        if (moving)     //moving se implementa siguiendo el patron dirtyflag solo para cuando se quiere mover el pers
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition,
                speed * Time.fixedDeltaTime);

            //ROTAR EL PERSONAJE
            if (newPosition.x > transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 90, 0);
            }
            if (newPosition.x < transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 270, 0);
            }
            if (newPosition.z > transform.position.z)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            if (newPosition.z < transform.position.z)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }



            if (Vector3.Distance(transform.position, newPosition) < speed * Time.fixedDeltaTime)
            //cuando se ha llegado suficientemente cerca de desitino, se situa directamente el pers en el destino y se vuleve 
            //a poner las animaciones de idle (0) y se desactiva el dirtyflag
            {
                transform.position = newPosition;
                moving = false;
                //animator.SetFloat(MoveSpeed, 0);
            }
        }



    }

    ////////////////// IMPLEMENTACION SUJETO ////////////////////////////


}
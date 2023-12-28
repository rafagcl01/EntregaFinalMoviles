using UnityEngine;


public class BoardCube : MonoBehaviour
{
    public int Row;
    public int Col;
    public bool obstacle;
    public bool victory;
    public string FormaTablero;

    public Material currentMaterial;

    private void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();
        currentMaterial = renderer.material;

        //ifs para saber de que escenario forma parte cada cubo
        if (transform.position.y < 10)
        {
            FormaTablero = "Normal";
        }
        else
        {
            FormaTablero = "Inverso";
        }

        //ifs para saber el tipo de terreno de cada bloque
        if (currentMaterial.name == "OBSTACULO (Instance)")
        {
            obstacle = true;
        }

        if (currentMaterial.name == "VICTORIA (Instance)")
        {
            victory = true;
        }
    }


}

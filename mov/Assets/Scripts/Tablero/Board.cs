using System;
using UnityEngine;



public class Board : MonoBehaviour
{

    private BoardCube StartingPos;
    [SerializeField] public BoardCube[,] cubes;



    private void Start()
    {
        cubes = new BoardCube[10, 10];
        foreach (BoardCube cube in transform.GetComponentsInChildren<BoardCube>())
        {
            cube.Row = (int)Math.Truncate(cube.transform.position.z);
            cube.Col = (int)Math.Truncate(cube.transform.position.x);
            cubes[cube.Row, cube.Col] = cube;
        }
    }



}


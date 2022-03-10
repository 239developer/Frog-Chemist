using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTable : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Elements;

    [SerializeField]
    private int ElementsPerX;

    [SerializeField]
    private int ElementsPerY;

    [SerializeField]
    private float Offset = 1f;
    void Start()
    {
        createTable();
    }
    //
    void createTable()
    {
        float StartX = -Offset * (ElementsPerX - 1) / 2;
        float StartY = -Offset * (ElementsPerY - 1) / 2;
        
        for (int x = 0; x < ElementsPerX; x++)
        {
            for (int y = 0; y < ElementsPerY; y++)
            {
                Instantiate(Elements[Random.Range(0, Elements.Length)], new Vector2(x * Offset + StartX, y * Offset + StartY), Quaternion.identity);
            }
        }
    }
}

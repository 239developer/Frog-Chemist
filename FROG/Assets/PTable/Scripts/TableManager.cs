using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    public GameObject parentObject, defaultCell, infoWindow;
    public float cellSpacing = 170.0f, scale = 0.15f;
    public List<GameObject> cells = new List<GameObject>();

    private Vector2 tableSize; //table dimensions in pixels

    void CreateCell(int x, int y) //empty cell
    {
        Vector3 bias = parentObject.transform.position;
        GameObject cell = GameObject.Instantiate(defaultCell, new Vector3(x * cellSpacing + bias.x, bias.y - y * cellSpacing, 0.0f), Quaternion.identity, parentObject.transform);
        cell.GetComponent<PTableCellScript>().infoWindow = infoWindow;
        cells.Add(cell);

        // Debug.Log($"created cell at {cell.transform.position}");
    }

    void CreateCell(int x, int y, int num, string name, int colorIndex)
    {
        Vector3 bias = parentObject.transform.position;
        GameObject cell = GameObject.Instantiate(defaultCell, new Vector3(x * cellSpacing + bias.x, bias.y - y * cellSpacing, 0.0f), Quaternion.identity, parentObject.transform);
        cell.GetComponent<PTableCellScript>().SetText(num, name);
        cell.GetComponent<PTableCellScript>().SetColor(colorIndex);
        cell.GetComponent<PTableCellScript>().infoWindow = infoWindow;
        cell.name = name;
        cells.Add(cell);

        // Debug.Log($"created {name} at {cell.transform.position}");
    }

    void GenerateTable(int[] p) //p for pattern
    {
        for(int x = 0; x < TableInfo.x; x++)
        {
            for(int y = 0; y < TableInfo.y; y++)
            {
                int n = p[TableInfo.x * y + x];

                switch(n)
                {
                    case -1:
                        break;

                    case 0:
                        CreateCell(x, y);
                        break;

                    default: //positives
                        CreateCell(x, y, n, TableInfo.elems[n - 1], TableInfo.group[n - 1]);
                        break;
                }
            }
        }
    }

    void TurnTable(float value)
    {
        parentObject.transform.Rotate(0.0f, 0.0f, value);
    }

    void TurnAllCells(float value)
    {
        if(cells != null)
        foreach(GameObject g in cells)
        {
            g.GetComponent<PTableCellScript>().Rotate(value);
        }
    }

    void Start()
    {
        GenerateTable(TableInfo.pattern);

        tableSize = new Vector2(TableInfo.x, TableInfo.y);
        tableSize *= cellSpacing;

        float heightK = Screen.height / tableSize.y;
        float widthK = Screen.width / tableSize.x;
        float k = 1f;
        Vector3 setPosition = Vector3.up * Screen.height;

        if(heightK < widthK)
        {
            k = heightK;
            setPosition.x = 0.5f * (Screen.width - tableSize.x * k);
        }
        else
        {
            k = widthK;
            setPosition.y = 0.5f * (Screen.height + tableSize.y * k);
        }

        parentObject.transform.position = setPosition;
        parentObject.transform.localScale *= scale * k;
    }
}

[System.Serializable]
public struct TableInfo
{
    public static int x = 18, y = 9; //size
    
    public static string[] elems = {"H", "He", "Li", "Be", "B", "C", "N", "O", "F", "Ne", "Na", "Mg", "Al", "Si", "P", "S", "Cl", "Ar", "K", "Ca", "Sc", "Ti", "V", "Cr", "Mn", "Fe", "Co", "Ni", "Cu", "Zn", "Ga", "Ge", "As", "Se", "Br", "Kr", "Rb", "Sr", "Y", "Zr", "Nb", "Mo", "Tc", "Ru", "Rh", "Pd", "Ag", "Cd", "In", "Sn", "Sb", "Te", "I", "Xe", "Cs", "Ba", "La", "Ce", "Pr", "Nd", "Pm", "Sm", "Eu", "Gd", "Tb", "Dy", "Ho", "Er", "Tm", "Yp", "Lu", "Hf", "Ta", "W", "Re", "Os", "Ir", "Pt", "Au", "Hg", "Tl", "Pb", "Bi", "Po", "At", "Rn", "Fr", "Ra", "Ac", "Th", "Pa", "U", "Np", "Pi", "Pu", "Am", "Cm", "Bk", "Cf", "Es", "Fm", "Md", "No",  "Lr", "Rf", "Db", "Sg", "Bh", "Hs", "Mt", "Ds", "Rg", "Cn", "Nh", "Fl", "Mc", "Lv", "Ts", "Og"};
    
    //pattern variable helps me know where should I place which element.
    //It stores 18x9 values for each cell(even for those that will be deleted afterwards)
    //-1 == delete cell; 0 == nothing; other numbers are for atomic numbers
    public static int[] pattern = {1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 2, 3, 4, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 5, 6, 7, 8, 9, 10,  11, 12, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 13, 14, 15, 16, 17, 18,   19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36,    37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54,     55, 56, 0, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86,      87, 88, 0, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118,       -1, -1, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, -1, -1, -1, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, -1};
    
    //0 - alkali metals; 1 - alkaline earth metals; 2 - Lanthanoids; 3 - Actinoids;
    //4 - transition metals; 5 - Post-transition metals; 6 - Metalloids;
    //7 - Reactive nonmetals; 8 - Noble gases; 9 - unknown
    public static int[] group = {7, 8, 0, 1, 6, 7, 7, 7, 7, 8, 0, 1, 5, 6, 7, 7, 7, 8, 0, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 6, 6, 7, 7, 8, 0, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 6, 6, 7, 8, 0, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 6, 8, 0, 1, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9};

    // public static int weights = ;
}
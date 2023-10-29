using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameControllerSlash : MonoBehaviour
{
    public static GameControllerSlash instance;
    
    [SerializeField] private GameObject fillPrefab;
    [SerializeField] private Transform[] allCells;

    public static Action<string> slide;
    public string lastMove;

    [SerializeField] private GameObject winPanel;

    private bool hasWon;

    private void OnEnable()
    {
        if (instance == null) instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        StartSpawnFill();
        StartSpawnFill();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (lastMove == "w")
            {
                return;
            }
            lastMove = "w";
            slide("w");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (lastMove == "d")
            {
                return;
            }
            lastMove = "d";
            slide("d");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (lastMove == "s")
            {
                return;
            }
            lastMove = "s";
            slide("s");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (lastMove == "a")
            {
                return;
            }
            lastMove = "a";
            slide("a");
        }
    }

    public void WinningCheck(int vitimas)
    {
        if (hasWon)
        {
            return;
        }
    }
    public void StartSpawnFill()
    {
        foreach (Transform cell in allCells)
        {
            if (cell.childCount != 0)
            {
                Fill tempFillComp = cell.GetChild(0).GetComponent<Fill>();
                cell.GetComponent<Cell>().fill = tempFillComp;
            }
        }
    }
}

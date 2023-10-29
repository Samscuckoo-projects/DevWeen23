using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameControllerSlash : MonoBehaviour
{
    public static GameControllerSlash instance;
    public static int ticker;
    
    [SerializeField] private GameObject fillPrefab;
    [SerializeField] private Transform[] allCells;

    public static Action<string> slide;

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
            ticker = 0;
            slide("w");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ticker = 0;
            slide("d");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ticker = 0;
            slide("s");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
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

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ticker = 0;
            SpawnFill();
        }

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

    public void SpawnFill()
    {
        int wichSpawn = UnityEngine.Random.Range(0, allCells.Length);
        if (allCells[wichSpawn].childCount != 0)
        {
            Debug.Log(allCells[wichSpawn].name + "is already filled");
            SpawnFill();
            return;
        }
        float chance = UnityEngine.Random.Range(0f, 1f);
        Debug.Log(chance);
        if (chance < .2f)
        {
            return;
        }
        else if (chance<.8f)
        {
            
            GameObject tempFill = Instantiate(fillPrefab, allCells[wichSpawn]);
            Debug.Log(2);
            Fill tempFillComp = tempFill.GetComponent<Fill>();
            allCells[wichSpawn].GetComponent<Cell>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(2);
        }
        else
        {
            
            GameObject tempFill = Instantiate(fillPrefab, allCells[wichSpawn]);
            Debug.Log(4);
            Fill tempFillComp = tempFill.GetComponent<Fill>();
            allCells[wichSpawn].GetComponent<Cell>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(4);
        }
    }
    
    public void StartSpawnFill()
    {
        int wichSpawn = UnityEngine.Random.Range(0, allCells.Length);
        if (allCells[wichSpawn].childCount != 0)
        {
            Debug.Log(allCells[wichSpawn].name + "is already filled");
            SpawnFill();
            return;
        }
        GameObject tempFill = Instantiate(fillPrefab, allCells[wichSpawn]);
        Debug.Log(2);
        Fill tempFillComp = tempFill.GetComponent<Fill>();
        allCells[wichSpawn].GetComponent<Cell>().fill = tempFillComp;
        tempFillComp.FillValueUpdate(2);
        
    }
}

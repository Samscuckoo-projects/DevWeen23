using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameControllerSlash : MonoBehaviour
{
    [SerializeField] private GameObject fillPrefab;
    [SerializeField] private Transform[] allCells;

    public static Action<string> slide;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnFill();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            slide("w");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            slide("d");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            slide("s");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            slide("a");
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
}

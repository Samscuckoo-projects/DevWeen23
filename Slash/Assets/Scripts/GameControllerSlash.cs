using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerSlash : MonoBehaviour
{
    [SerializeField] private GameObject fillPrefab;
    [SerializeField] private Transform[] allCells;
    
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
    }

    public void SpawnFill()
    {
        float chance = Random.Range(0f, 1f);
        Debug.Log(chance);
        if (chance < .2f)
        {
            return;
        }
        else if (chance<.8f)
        {
            int wichSpawn = Random.Range(0, allCells.Length);
            GameObject tempFill = Instantiate(fillPrefab, allCells[wichSpawn]);
            Debug.Log(2);
        }
        else
        {
            int wichSpawn = Random.Range(0, allCells.Length);
            GameObject tempFill = Instantiate(fillPrefab, allCells[wichSpawn]);
            Debug.Log(4);
        }
    }
}

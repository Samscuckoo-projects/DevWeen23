using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameControllerSlash : MonoBehaviour
{
    public static GameControllerSlash instance;
    
    [SerializeField] private GameObject fillPrefab;
    [SerializeField] private Transform[] allCells;

    public static Action<string> slide;
    public string lastMove;

    [SerializeField] private GameObject winPanel;
    private bool hasWon;

    private int vitimas;
    

    private void OnEnable()
    {
        if (instance == null) instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public IEnumerator WinningCheck()
    {
        vitimas--;
        if (hasWon)
        {
            yield break;
        }

        if (vitimas == 0)
        {
            yield return new WaitForSeconds(1);
            winPanel.SetActive(true);
            hasWon = true;
        }
    }

    public void Proxima()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void StartSpawnFill()
    {
        foreach (Transform cell in allCells)
        {
            if (cell.childCount != 0)
            {
                Fill tempFillComp = cell.GetChild(0).GetComponent<Fill>();
                cell.GetComponent<Cell>().fill = tempFillComp;
                if (cell.GetComponent<Cell>().fill.value == 3 ||
                    cell.GetComponent<Cell>().fill.value == 4 ||
                    cell.GetComponent<Cell>().fill.value == 5 ||
                    cell.GetComponent<Cell>().fill.value == 6)
                {
                    vitimas++;
                }
            }
        }
    }
}

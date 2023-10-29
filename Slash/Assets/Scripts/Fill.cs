using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fill : MonoBehaviour
{
    public int value;
    /*Valores representam quem é
     0 = vazio 
     1 = Marcos Maionese
     2 = Tronco
     3 = policial Pistola
     4 = Policial Gordo
     5 = Policial Shotgun
     6 = Laura Strogonoff
     7 = armadilha
     8 = pneu
     9 = parede
     10 = Troncodilha
     Móveis: 1, 2, 6, 8
     */
    [SerializeField] private float speed;
    private bool hasKilled;
    private void Update()
    {
        if (transform.localPosition != Vector3.zero)
        {
            hasKilled = false;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,
                Vector3.zero, speed * Time.deltaTime);
        }
        else if (hasKilled == false)
        {
            if (transform.parent.GetChild(0) != this.transform)
            {
                
                Destroy(transform.parent.GetChild(0).gameObject);
            }

            hasKilled = true;
        }
    }

    public void Kill()
    {
        Debug.Log("matei");
        GameControllerSlash.instance.WinningCheck();
    }

    public void EndEvil()
    {
        Debug.Log("Evil ended");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

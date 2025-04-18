using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Cell right;
    public Cell left;
    public Cell up;
    public Cell down;

    public Fill fill;

    private void OnEnable()
    {
        GameControllerSlash.slide += OnSlide;
    }

    private void OnDisable()
    {
        GameControllerSlash.slide -= OnSlide;
    }

    private void OnSlide(string whatWasSent)
    {
        if (whatWasSent == "w")
        {
            if (up != null)
            {
                return;
            }

            Cell currentCell = this;
            SlideUp(currentCell);
        }

        if (whatWasSent == "d")
        {
            if (right != null)
            {
                return;
            }

            Cell currentCell = this;
            SlideRight(currentCell);
        }

        if (whatWasSent == "s")
        {
            if (down != null)
            {
                return;
            }

            Cell currentCell = this;
            SlideDown(currentCell);
        }

        if (whatWasSent == "a")
        {
            if (left != null)
            {
                return;
            }

            Cell currentCell = this;
            SlideLeft(currentCell);
        }
    }

    void SlideUp(Cell currentCell)
    {
        if (currentCell.down == null) return;
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.down;
            while (nextCell.down != null && nextCell.fill == null)
            {
                nextCell = nextCell.down;
            }

            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == 1)
                {

                    if (nextCell.fill.value is 6 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.down.transform;
                        currentCell.down.fill = nextCell.fill;
                        if (nextCell != currentCell.down)
                        {
                            nextCell.fill = null;
                        }
                    }
                    else if (nextCell.fill.value == 8)
                    {
                        StartCoroutine(nextCell.fill.EndEvil());
                        nextCell.fill.transform.parent = currentCell.transform;
                        nextCell.fill = null;

                    }

                }
                else if (currentCell.fill.value is 2 or 8 or 9 or 10)
                {
                    if (nextCell.fill.value is 1 or 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.down.transform;
                        currentCell.down.fill = nextCell.fill;
                        if (nextCell != currentCell.down)
                        {
                            nextCell.fill = null;
                        }
                    }
                    
                }
                else if (currentCell.fill.value is 4 or 6)
                {
                    if (nextCell.fill.value == 1)
                    {
                        nextCell.fill.Kill();
                        nextCell.fill.transform.parent = currentCell.transform;
                        currentCell.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value is 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.down.transform;
                        currentCell.down.fill = nextCell.fill;
                        if (nextCell != currentCell.down)
                        {
                            nextCell.fill = null;
                        }
                    }

                }
                else if (currentCell.fill.value == 7)
                {
                    if (nextCell.fill.value == 1)
                    {
                        StartCoroutine(nextCell.fill.EndEvil());
                        nextCell.fill.transform.parent = currentCell.transform;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value is 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.down.transform;
                        currentCell.down.fill = nextCell.fill;
                        if (nextCell != currentCell.down)
                        {
                            nextCell.fill = null;
                        }
                    }
                }
                else if (currentCell.fill.value == 3)
                {
                    Debug.Log("shotgun");
                    if (nextCell.fill.value == 1)
                    {
                        nextCell.fill.Kill();
                        nextCell.fill.transform.parent = currentCell.transform;
                        currentCell.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value is 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.down.transform;
                        currentCell.down.fill = nextCell.fill;
                        if (nextCell != currentCell.down)
                        {
                            nextCell.fill = null;
                        }
                    }
                }
                else if (currentCell.fill.value == 5)
                {
                    if (nextCell.fill.value == 1)
                    {
                        StartCoroutine(nextCell.fill.EndEvil());
                        nextCell.fill.transform.parent = currentCell.down.transform;
                        currentCell.down.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value is 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.down.transform;
                        currentCell.down.fill = nextCell.fill;
                        if (nextCell != currentCell.down)
                        {
                            nextCell.fill = null;
                        }
                    }
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.down;
            while (nextCell.down != null && nextCell.fill == null)
            {
                nextCell = nextCell.down;
            }

            if (nextCell.fill != null)
            {
                if (nextCell.fill.value is 6 or 8 or 1 or 2)
                {
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                    SlideUp(currentCell);
                }
                
            }
        }

        if (currentCell.down == null) return;
        SlideUp(currentCell.down);
    }

    void SlideRight(Cell currentCell)
    {
        if (currentCell.left == null) return;
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.left;
            while (nextCell.left != null && nextCell.fill == null)
            {
                nextCell = nextCell.left;
            }

            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == 1)
                {

                    if (nextCell.fill.value is 6 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.left.transform;
                        currentCell.left.fill = nextCell.fill;
                        if (nextCell != currentCell.left)
                        {
                            nextCell.fill = null;
                        }
                    }
                    else if (nextCell.fill.value == 8)
                    {
                        StartCoroutine(nextCell.fill.EndEvil());
                        nextCell.fill.transform.parent = currentCell.transform;
                        nextCell.fill = null;

                    }

                }
                else if (currentCell.fill.value is 2 or 8 or 9 or 10)
                {
                    if (nextCell.fill.value is 1 or 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.left.transform;
                        currentCell.left.fill = nextCell.fill;
                        if (nextCell != currentCell.left)
                        {
                            nextCell.fill = null;
                        }

                    }
                  
                }
                else if (currentCell.fill.value is 4 or 6)
                {
                    if (nextCell.fill.value == 1)
                    {
                        nextCell.fill.Kill();
                        nextCell.fill.transform.parent = currentCell.transform;
                        currentCell.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value is 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.left.transform;
                        currentCell.left.fill = nextCell.fill;
                        if (nextCell != currentCell.left)
                        {
                            nextCell.fill = null;
                        }
                    }

                }
                else if (currentCell.fill.value == 7)
                {
                    if (nextCell.fill.value == 1)
                    {
                        StartCoroutine(nextCell.fill.EndEvil());
                        nextCell.fill.transform.parent = currentCell.transform;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value is 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.left.transform;
                        currentCell.left.fill = nextCell.fill;
                        if (nextCell != currentCell.left)
                        {
                            nextCell.fill = null;
                        }
                    }
                }
                else if (currentCell.fill.value == 5)
                {
                    if (nextCell.fill.value == 1)
                    {
                        nextCell.fill.Kill();
                        nextCell.fill.transform.parent = currentCell.transform;
                        currentCell.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value is 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.left.transform;
                        currentCell.left.fill = nextCell.fill;
                        if (nextCell != currentCell.left)
                        {
                            nextCell.fill = null;
                        }
                    }
                }
                else if (currentCell.fill.value == 3)
                {
                    if (nextCell.fill.value == 1)
                    {
                        StartCoroutine(nextCell.fill.EndEvil());
                        nextCell.fill.transform.parent = currentCell.left.transform;
                        currentCell.left.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value is 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.left.transform;
                        currentCell.left.fill = nextCell.fill;
                        if (nextCell != currentCell.left)
                        {
                            nextCell.fill = null;
                        }
                    }
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.left;
            while (nextCell.left != null && nextCell.fill == null)
            {
                nextCell = nextCell.left;
            }

            if (nextCell.fill != null)
            {
                if (nextCell.fill.value is 6 or 8 or 1 or 2)
                {
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                    SlideRight(currentCell);
                }
                
            }
        }

        if (currentCell.left == null) return;
        SlideRight(currentCell.left);
    }

    void SlideDown(Cell currentCell)
    {
        if (currentCell.up == null) return;
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.up;
            while (nextCell.up != null && nextCell.fill == null)
            {
                nextCell = nextCell.up;
            }

            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == 1)
                {

                    if (nextCell.fill.value is 6 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.up.transform;
                        currentCell.up.fill = nextCell.fill;
                        if (nextCell != currentCell.up)
                        {
                            nextCell.fill = null;
                        }
                    }
                    else if (nextCell.fill.value == 8)
                    {
                        StartCoroutine(nextCell.fill.EndEvil());
                        nextCell.fill.transform.parent = currentCell.transform;
                        nextCell.fill = null;

                    }

                }
                else if (currentCell.fill.value is 2 or 8 or 9 or 10)
                {
                    if (nextCell.fill.value is 1 or 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.up.transform;
                        currentCell.up.fill = nextCell.fill;
                        if (nextCell != currentCell.up)
                        {
                            nextCell.fill = null;
                        }
                    }
                    
                }
                else if (currentCell.fill.value is 4 or 6)
                {
                    if (nextCell.fill.value == 1)
                    {
                        nextCell.fill.Kill();
                        nextCell.fill.transform.parent = currentCell.transform;
                        currentCell.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value is 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.up.transform;
                        currentCell.up.fill = nextCell.fill;
                        if (nextCell != currentCell.up)
                        {
                            nextCell.fill = null;
                        }
                    }

                }
                else if (currentCell.fill.value == 7)
                {
                    if (nextCell.fill.value == 1)
                    {
                        StartCoroutine(nextCell.fill.EndEvil());
                        nextCell.fill.transform.parent = currentCell.transform;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value is 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.up.transform;
                        currentCell.up.fill = nextCell.fill;
                        if (nextCell != currentCell.up)
                        {
                            nextCell.fill = null;
                        }
                    }
                }
                else if (currentCell.fill.value == 3)
                {
                    if (nextCell.fill.value == 1)
                    {
                        nextCell.fill.Kill();
                        nextCell.fill.transform.parent = currentCell.transform;
                        currentCell.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value is 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.up.transform;
                        currentCell.up.fill = nextCell.fill;
                        if (nextCell != currentCell.up)
                        {
                            nextCell.fill = null;
                        }
                    }
                }
                else if (currentCell.fill.value == 5)
                {
                    if (nextCell.fill.value == 1)
                    {
                        StartCoroutine(nextCell.fill.EndEvil());
                        nextCell.fill.transform.parent = currentCell.up.transform;
                        currentCell.up.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value is 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.up.transform;
                        currentCell.up.fill = nextCell.fill;
                        if (nextCell != currentCell.up)
                        {
                            nextCell.fill = null;
                        }
                    }
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.up;
            while (nextCell.up != null && nextCell.fill == null)
            {
                nextCell = nextCell.up;
            }

            if (nextCell.fill != null)
            {
                if (nextCell.fill.value is 6 or 8 or 1 or 2)
                {
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                    SlideDown(currentCell);
                }
                
            }
        }

        if (currentCell.up == null) return;
        SlideDown(currentCell.up);
    }

    void SlideLeft(Cell currentCell)
    {
        if (currentCell.right == null) return;
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.right;
            while (nextCell.right != null && nextCell.fill == null)
            {
                nextCell = nextCell.right;
            }

            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == 1)
                {

                    if (nextCell.fill.value is 6 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.right.transform;
                        currentCell.right.fill = nextCell.fill;
                        if (nextCell != currentCell.right)
                        {
                            nextCell.fill = null;
                        }
                    }
                    else if (nextCell.fill.value == 8)
                    {
                        StartCoroutine(nextCell.fill.EndEvil());
                        nextCell.fill.transform.parent = currentCell.transform;
                        nextCell.fill = null;

                    }

                }
                else if (currentCell.fill.value is 2 or 8 or 9 or 10)
                {
                    if (nextCell.fill.value is 1 or 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.right.transform;
                        currentCell.right.fill = nextCell.fill;
                        if (nextCell != currentCell.right)
                        {
                            nextCell.fill = null;
                        }
                    }
                    
                }
                else if (currentCell.fill.value is 4 or 6)
                {
                    if (nextCell.fill.value == 1)
                    {
                        nextCell.fill.Kill();
                        nextCell.fill.transform.parent = currentCell.transform;
                        currentCell.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value is 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.right.transform;
                        currentCell.right.fill = nextCell.fill;
                        if (nextCell != currentCell.right)
                        {
                            nextCell.fill = null;
                        }
                    }

                }
                else if (currentCell.fill.value == 7)
                {
                    if (nextCell.fill.value == 1)
                    {
                        StartCoroutine(nextCell.fill.EndEvil());
                        nextCell.fill.transform.parent = currentCell.transform;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value is 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.right.transform;
                        currentCell.right.fill = nextCell.fill;
                        if (nextCell != currentCell.right)
                        {
                            nextCell.fill = null;
                        }
                    }
                }
                else if (currentCell.fill.value == 5)
                {
                    if (nextCell.fill.value == 1)
                    {
                        nextCell.fill.Kill();
                        nextCell.fill.transform.parent = currentCell.transform;
                        currentCell.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value is 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.right.transform;
                        currentCell.right.fill = nextCell.fill;
                        if (nextCell != currentCell.right)
                        {
                            nextCell.fill = null;
                        }
                    }
                }
                else if (currentCell.fill.value == 3)
                {
                    if (nextCell.fill.value == 1)
                    {
                        StartCoroutine(nextCell.fill.EndEvil());
                        nextCell.fill.transform.parent = currentCell.right.transform;
                        currentCell.right.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value is 6 or 8 or 2)
                    {
                        nextCell.fill.transform.parent = currentCell.right.transform;
                        currentCell.right.fill = nextCell.fill;
                        if (nextCell != currentCell.right)
                        {
                            nextCell.fill = null;
                        }
                    }
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.right;
            while (nextCell.right != null && nextCell.fill == null)
            {
                nextCell = nextCell.right;
            }

            if (nextCell.fill != null)
            {
                if (nextCell.fill.value is 6 or 8 or 1 or 2)
                {
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                    SlideLeft(currentCell);
                }
                
            }
        }

        if (currentCell.right == null) return;
        SlideLeft(currentCell.right);
    }
}

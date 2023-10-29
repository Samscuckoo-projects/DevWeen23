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
        if(currentCell.down == null) return;
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
                    if (nextCell.fill.value == 2)
                    {
                        nextCell.fill.transform.parent = nextCell.up.transform;
                        nextCell.up.fill = nextCell.fill;
                        nextCell.fill = null;
                        currentCell = nextCell;
                    }
                    else if (nextCell.fill.value == 6)
                    {
                        nextCell.fill.transform.parent = currentCell.down.transform;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value == 8)
                    {
                        nextCell.fill.EndEvil();
                        nextCell.fill.transform.parent = currentCell.transform;
                        nextCell.fill = null;
                        
                    }
                }
                else if (currentCell.fill.value == 2 ||
                         currentCell.fill.value == 8 ||
                         currentCell.fill.value == 9 ||
                         currentCell.fill.value == 10)
                {
                    if (nextCell.fill.value == 1 ||
                        nextCell.fill.value == 6 ||
                        nextCell.fill.value == 8)
                    {
                        nextCell.fill.transform.parent = currentCell.down.transform;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value == 2)
                    {
                        nextCell.fill.transform.parent = nextCell.up.transform;
                        nextCell.up.fill = nextCell.fill;
                        nextCell.fill = null;
                        currentCell = nextCell;
                    }
                }
                else if (currentCell.fill.value == 4 ||
                         currentCell.fill.value == 6)
                {
                    if (nextCell.fill.value == 1)
                    {
                        nextCell.fill.Kill();
                        nextCell.fill.transform.parent = currentCell.transform;
                        currentCell.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value == 2)
                    {
                        nextCell.fill.transform.parent = nextCell.up.transform;
                        nextCell.up.fill = nextCell.fill;
                        nextCell.fill = null;
                        currentCell = nextCell;
                    }
                    else if (nextCell.fill.value == 6 ||
                             nextCell.fill.value == 8)
                    {
                        nextCell.fill.transform.parent = currentCell.down.transform;
                        nextCell.fill = null;
                    }
                    
                }
                else if (currentCell.fill.value == 7)
                {
                    if (nextCell.fill.value == 1)
                    {
                        nextCell.fill.EndEvil();
                        nextCell.fill.transform.parent = currentCell.transform;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value == 2)
                    {
                        nextCell.fill.transform.parent = nextCell.up.transform;
                        nextCell.up.fill = nextCell.fill;
                        nextCell.fill = null;
                        currentCell = nextCell;
                    }
                    else if (nextCell.fill.value == 6 ||
                             nextCell.fill.value == 8)
                    {
                        nextCell.fill.transform.parent = currentCell.down.transform;
                        nextCell.fill = null;
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
                    else if (nextCell.fill.value == 2)
                    {
                        nextCell.fill.transform.parent = nextCell.up.transform;
                        nextCell.up.fill = nextCell.fill;
                        nextCell.fill = null;
                        currentCell = nextCell;
                    }
                    else if (nextCell.fill.value == 6 ||
                             nextCell.fill.value == 8)
                    {
                        nextCell.fill.transform.parent = currentCell.down.transform;
                        nextCell.fill = null;
                    }
                }
                else if (currentCell.fill.value == 5)
                {
                    if (nextCell.fill.value == 1)
                    {
                        nextCell.fill.EndEvil();
                        nextCell.fill.transform.parent = currentCell.transform;
                        nextCell.fill = null;
                    }
                    else if (nextCell.fill.value == 2)
                    {
                        nextCell.fill.transform.parent = nextCell.up.transform;
                        nextCell.up.fill = nextCell.fill;
                        nextCell.fill = null;
                        currentCell = nextCell;
                    }
                    else if (nextCell.fill.value == 6 ||
                             nextCell.fill.value == 8)
                    {
                        nextCell.fill.transform.parent = currentCell.down.transform;
                        nextCell.fill = null;
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
                if (nextCell.fill.value == 6 || nextCell.fill.value == 8 || nextCell.fill.value == 1)
                {
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                    SlideUp(currentCell);
                }
                else if (nextCell.fill.value == 2)
                {
                    nextCell.fill.transform.parent = nextCell.up.transform;
                    nextCell.up.fill = nextCell.fill;
                    nextCell.fill = null;
                    currentCell = nextCell;
                }
            }
        }
        if (currentCell.down == null) return;
        SlideUp(currentCell.down);
    }
    
    void SlideRight(Cell currentCell)
    {
        if(currentCell.left == null) return;
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.left;
            while (nextCell.left != null && nextCell.fill == null)
            {
                nextCell = nextCell.left;
            }

            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Kill();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if(currentCell.left.fill != nextCell.fill)
                {
                    Debug.Log("!double");
                    nextCell.fill.transform.parent = currentCell.left.transform;
                    currentCell.left.fill = nextCell.fill;
                    nextCell.fill = null;
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
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideRight(currentCell);
                Debug.Log("Slide to empty");
            }
        }
        
        if (currentCell.left == null) return;
        SlideRight(currentCell.left);
    }
    void SlideDown(Cell currentCell)
    {
        if(currentCell.up == null) return;
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.up;
            while (nextCell.up != null && nextCell.fill == null)
            {
                nextCell = nextCell.up;
            }

            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Kill();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if(currentCell.up.fill != nextCell.fill)
                {
                    Debug.Log("!double");
                    nextCell.fill.transform.parent = currentCell.up.transform;
                    currentCell.up.fill = nextCell.fill;
                    nextCell.fill = null;
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
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideDown(currentCell);
                Debug.Log("Slide to empty");
            }
        }
        
        if (currentCell.up == null) return;
        SlideDown(currentCell.up);
    }
    void SlideLeft(Cell currentCell)
    {
        if(currentCell.right == null) return;
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.right;
            while (nextCell.right != null && nextCell.fill == null)
            {
                nextCell = nextCell.right;
            }

            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Kill();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if(currentCell.right.fill != nextCell.fill)
                {
                    Debug.Log("!double");
                    nextCell.fill.transform.parent = currentCell.right.transform;
                    currentCell.right.fill = nextCell.fill;
                    nextCell.fill = null;
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
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideLeft(currentCell);
                Debug.Log("Slide to empty");
            }
        }
        
        if (currentCell.right == null) return;
        SlideLeft(currentCell.right);
    }

    
}

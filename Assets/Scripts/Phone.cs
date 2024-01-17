using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public int touchTimes;

    public void Reduce()
    {
        touchTimes -= 1;

        if (touchTimes <= 0)
        {
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
            GameManager.Instance.CheckLevelUp();
        }
    }
 }

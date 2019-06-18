using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [HideInInspector]
    public int currentPoints;
    private int lives;
    private int highscore;
    public Text PointBox;

    private void Update()
    {
        PointBox.text = currentPoints.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayManager : MonoBehaviour
{


    // -------------------------- Display Bound -------------------------- // 
    float mapX = 100.0f;
    float mapY = 100.0f;

    [HideInInspector]
    public float minX;
    [HideInInspector]
    public float maxX;
    [HideInInspector]
    public float minY;
    [HideInInspector]
    public float maxY;

    [HideInInspector]
    public Vector2 LEFT_UP;
    [HideInInspector]
    public Vector2 LEFT_DOWN;
    [HideInInspector]
    public Vector2 RIGHT_UP;
    [HideInInspector]
    public Vector2 RIGHT_DOWN;

    [HideInInspector]
    public float WIDTH;
    [HideInInspector]
    public float HEIGHT;

    [HideInInspector]
    public float LEFT;
    [HideInInspector]
    public float RIGHT;
    [HideInInspector]
    public float DOWN;
    [HideInInspector]
    public float UP;


    void Awake()
    {
        InitDisplayBound();
    }



    void InitDisplayBound()
    {
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;


        minX = horzExtent - mapX / 2.0f;
        maxX = mapX / 2.0f - horzExtent;
        minY = vertExtent - mapY / 2.0f;
        maxY = mapY / 2.0f - vertExtent;

        LEFT_UP = new Vector2(maxX - 50, minY + 50);
        LEFT_DOWN = new Vector2(maxX - 50, maxY - 50);
        RIGHT_UP = new Vector2(minX + 50, minY + 50);
        RIGHT_DOWN = new Vector2(minX + 50, maxY - 50);

        WIDTH = RIGHT_DOWN.x - LEFT_DOWN.x;
        HEIGHT = LEFT_UP.y - LEFT_DOWN.y;

        LEFT = LEFT_UP.x;
        RIGHT = RIGHT_UP.x;
        UP = LEFT_UP.y;
        DOWN = LEFT_DOWN.y;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCColorSingleton {

    public struct ColorTuple
    {
        public Color color;
        public int index;
    }
    static NPCColorSingleton instance;
    Color[] possibleColors = new Color[10];

    NPCColorSingleton()
    {
        possibleColors[0] = new Color(0, 0, 0);
        possibleColors[1] = new Color(0, 0, 1);
        possibleColors[2] = new Color(0, 1, 0);
        possibleColors[3] = new Color(0, 1, 1);
        possibleColors[4] = new Color(1, 0, 0);
        possibleColors[5] = new Color(1, 0, 1);
        possibleColors[6] = new Color(1, 1, 0);
        possibleColors[7] = new Color(1, 1, 1);
        possibleColors[8] = new Color(0.5f, 0.5f, 0.5f);
        possibleColors[9] = new Color(0.8f, 0.3f, 0);
    }

	public static NPCColorSingleton getInstance()
    {
        if (instance == null)
        {
            instance = new NPCColorSingleton();
        }
        return instance;
    }

    public ColorTuple getRandomColor()
    {
        int idx = Random.Range(0,10);
        ColorTuple T = new ColorTuple();
        T.color = possibleColors[idx];
        T.index = idx;
        return T;
    }

    public static void refresh()
    {
        instance = new NPCColorSingleton();
    }
}

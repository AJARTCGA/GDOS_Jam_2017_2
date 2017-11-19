using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFaceSingleton
{
    public struct FaceTuple
    {
        public Object faceItem;
        public int index;
    }

    static NPCFaceSingleton instance;
    Object[] objs = new Object[5];

    // Use this for initialization
    NPCFaceSingleton()
    {
        objs[0] = Resources.Load("Prefabs/PlacedFaceItems/funnyGlasses");
        objs[1] = Resources.Load("Prefabs/PlacedFaceItems/glasses");
        objs[2] = Resources.Load("Prefabs/PlacedFaceItems/pipe");
        objs[3] = Resources.Load("Prefabs/PlacedFaceItems/pointyAnimeShades");
        objs[4] = Resources.Load("Prefabs/PlacedFaceItems/pointyStarshapedAnimeShades");
    }

    public static NPCFaceSingleton getInstance()
    {
        if (instance == null)
        {
            instance = new NPCFaceSingleton();
        }
        return instance;
    }

    public FaceTuple getRandomItem()
    {
        int idx = Random.Range(0, 5);
        FaceTuple T = new FaceTuple();
        T.faceItem = objs[idx];
        T.index = idx;
        return T;
    }

    public static void refresh()
    {
        instance = new NPCFaceSingleton();
    }
}

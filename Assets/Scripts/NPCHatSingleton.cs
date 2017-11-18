using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHatSingleton
{
    public struct HatTuple
    {
        public Object hat;
        public int index;
    }

    static NPCHatSingleton instance;
    Object[] hats = new Object[7];

    // Use this for initialization
    NPCHatSingleton()
    {
        hats[0] = Resources.Load("Prefabs/PlacedHats/blackCrown");
        hats[1] = Resources.Load("Prefabs/PlacedHats/dioHat");
        hats[2] = Resources.Load("Prefabs/PlacedHats/jotaroHat");
        hats[3] = Resources.Load("Prefabs/PlacedHats/paperBag");
        hats[4] = Resources.Load("Prefabs/PlacedHats/somethingHat");
        hats[5] = Resources.Load("Prefabs/PlacedHats/topHat");
        hats[6] = Resources.Load("Prefabs/PlacedHats/whiteCrown");
    }

    public static NPCHatSingleton getInstance()
    {
        if (instance == null)
        {
            instance = new NPCHatSingleton();
        }
        return instance;
    }

    public HatTuple getRandomHat()
    {
        int idx = Random.Range(0, 7);
        HatTuple T = new HatTuple();
        T.hat = hats[idx];
        T.index = idx;
        return T;
    }

    public bool checkFullFaceHat(int idx)
    {
        //So far, this only applies to the bag
        if (idx == 3)
            return true;
        return false;
    }
}

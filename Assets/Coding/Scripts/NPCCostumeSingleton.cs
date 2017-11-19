using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCostumeSingleton
{

    const int numCostumes = 300;

    public struct CostumeIndexStruct
    {
        public int colorIdx;
        public int hatIdx;
        public int faceIdx;
    };

    public struct CostumeStruct
    {
        public Color color;
        public Object hat;
        public Object faceItem;
    };

    Dictionary<CostumeIndexStruct, bool> costumeMap;
    static NPCCostumeSingleton instance;

    NPCCostumeSingleton()
    {
        int x = 19;
        costumeMap = new Dictionary<CostumeIndexStruct, bool>();
    }

    public static NPCCostumeSingleton getInstance()
    {
        if (instance == null)
        {
            instance = new NPCCostumeSingleton();
        }
        return instance;
    }

    public CostumeStruct getCostume()
    {
        CostumeStruct T = new CostumeStruct();
        NPCColorSingleton.ColorTuple col = NPCColorSingleton.getInstance().getRandomColor();
        NPCHatSingleton.HatTuple hat = NPCHatSingleton.getInstance().getRandomHat();
        NPCFaceSingleton.FaceTuple face;
        face = new NPCFaceSingleton.FaceTuple();
        face.index = -1;
        if (!NPCHatSingleton.getInstance().checkFullFaceHat(hat.index))
        {
            face = NPCFaceSingleton.getInstance().getRandomItem();
        }
        CostumeIndexStruct idxT = new CostumeIndexStruct();
        idxT.colorIdx = col.index;
        idxT.hatIdx = hat.index;
        idxT.faceIdx = face.index;
        while(costumeMap.ContainsKey(idxT))
        {
            col = NPCColorSingleton.getInstance().getRandomColor();
            hat = NPCHatSingleton.getInstance().getRandomHat();
            face = new NPCFaceSingleton.FaceTuple();
            face.index = -1;
            if (!NPCHatSingleton.getInstance().checkFullFaceHat(hat.index))
            {
                face = NPCFaceSingleton.getInstance().getRandomItem();
            }
            idxT.colorIdx = col.index;
            idxT.hatIdx = hat.index;
            idxT.faceIdx = face.index;
        }
        costumeMap[idxT] = true;
        T.color = col.color;
        T.hat = hat.hat;
        T.faceItem = face.faceItem;
        return T;
    }
    public static void refresh()
    {
        instance = new NPCCostumeSingleton();
    }

}

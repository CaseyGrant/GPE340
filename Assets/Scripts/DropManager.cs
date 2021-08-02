using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DropManager : MonoBehaviour
{
    public List<DropItem> dropTable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject DropItem()
    {
        List<float> CDFArray = new List<float>();

        float runningTotal = 0;
        foreach (DropItem item in dropTable)
        {
            runningTotal = runningTotal + item.dropWeight;
            CDFArray.Add(runningTotal);
        }

        float randomNumber = UnityEngine.Random.Range(0, runningTotal);

        for (int i = 0; i < CDFArray.Count; i++)
        {
            if (randomNumber < CDFArray[i])
            {
                return dropTable[i].itemDrop;
            }
        }

        return null;
    }
}

[Serializable]
public class DropItem
{
    public GameObject itemDrop;
    public float dropWeight;
}
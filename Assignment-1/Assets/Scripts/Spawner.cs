using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] typeofcoins;
    public float distanceBetweenCoins;
    public float heightofcheck = 10f, rangeofcheck = 30f;
    public LayerMask layerMask;
    public Vector2 positivePosition, negativePosition;
    public int spawnChance = 50;
    void Start()
    {
        SpawnCoins();
    }
    void SpawnCoins()
    {
        for(float x = negativePosition.x; x < positivePosition.x; x += distanceBetweenCoins)
        {
            for(float z = negativePosition.y; z < positivePosition.y; z+= distanceBetweenCoins)
            {
                RaycastHit hit;
                if(Physics.Raycast(new Vector3(x,heightofcheck,z),Vector3.down, out hit, rangeofcheck, layerMask))
                {
                    if(spawnChance > Random.Range(0, 100))
                    {
                        Vector3 pos = hit.point;
                        pos.y += .2f;
                        int index = Random.Range(0, typeofcoins.Length);
                        Instantiate(typeofcoins[index], pos , transform.rotation, transform);
                    }
                }
            }
        }
    }
}

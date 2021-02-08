using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private BlockSpawner blockSpawner;

    private void Start()
    {
        blockSpawner = GameObject.Find("Block Spawner").GetComponent<BlockSpawner>();
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, -blockSpawner.speed * Time.deltaTime, 0));
    }

    
}

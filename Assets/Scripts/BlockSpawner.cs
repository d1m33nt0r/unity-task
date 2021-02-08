using UnityEngine;
using System.Collections.Generic;

public class BlockSpawner : MonoBehaviour
{
    private Vector2 min, max;
    public float speed;

    private float blockSpawnTime;
    
    private bool isFirstSpawn;

    [SerializeField]
    private List<Color> colors;

    [SerializeField]
    private GameObject block;

    [SerializeField]
    private List<Transform> points;

    private List<Transform> nextPoints;

    private void Start()
    {

        isFirstSpawn = true;
        speed = 2f;
        blockSpawnTime = 1.5f;

        nextPoints = new List<Transform>();
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        float temp = Mathf.Abs(min.x - max.x) / points.Count / 2;

        float x = Mathf.Abs(min.x - max.x) / points.Count;

        for (int i = 0; i < points.Count; i++)
        {
            points[i].position = new Vector2(min.x + (i + 1) * x - temp, max.y);
        }
    }

    public void DestroyBlocks()
    {
        Destroy(transform.GetChild(1).gameObject);
    }

    public void ResetSpawner()
    {
        GameObject blocks = new GameObject();
        blocks.name = "blocks";
        blocks.transform.parent = transform;

        isFirstSpawn = true;
        speed = 2f;
        blockSpawnTime = 1.5f;
        nextPoints = new List<Transform>();
    }

    public void StartInvokes()
    {
        InvokeRepeating("IncreaseBlockSpeed", 5f, 5f);
        Invoke("SpawnBlock", blockSpawnTime);
    }

    public void StopInvokes()
    {
        
        CancelInvoke("SpawnBlock");
        CancelInvoke("IncreaseBlockSpeed");
        CancelInvoke("SheduleSpawn");
    }

    private void IncreaseBlockSpeed()
    {
        speed += speed / 100 * 5;
        blockSpawnTime -= blockSpawnTime / 100 * 3.5f;   
    }

    private void SheduleSpawn()
    {
        SpawnBlock();
    }

    private void SpawnBlock()
    {
        if(isFirstSpawn)
        {
            isFirstSpawn = false;

            GameObject _block = (GameObject)Instantiate(block);
            _block.transform.parent = transform.GetChild(1);
            int randomIndex = Random.Range(0, points.Count);
            _block.transform.position = points[randomIndex].position;

            foreach (Transform point in points)
            {
                if (!points[randomIndex].Equals(point))
                    nextPoints.Add(point);
            }           
        }
        else
        {
            GameObject _block = (GameObject)Instantiate(block);
            _block.transform.parent = transform.GetChild(1);
            int randomIndex = Random.Range(0, nextPoints.Count);
            Transform point = nextPoints[randomIndex];
            _block.transform.position = nextPoints[randomIndex].position;

            nextPoints.Clear();

            foreach(Transform p in points)
            {
                if (!point.Equals(p))
                    nextPoints.Add(p);
            }
        }

        Invoke("SheduleSpawn", blockSpawnTime);
    }
}

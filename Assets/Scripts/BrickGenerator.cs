using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BrickGenerator : MonoBehaviour
{
    [SerializeField]
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;

    public List<GameObject> bricks;
    public int activeBricks = 0;
    public int maxActiveBricks = 0;

    public AudioSource bgmSource;

    public void GenerateBricks(int x, int y)
    {
        Vector2 v = new Vector2(0,0.6f);
        Vector2 h = new Vector2(1, 0);
        Vector2 start = -h * ((float)x / 2.0f) + new Vector2(0.5f, 0) + v * y;
        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                Vector2 pos = start + h * j + v * i;
                bricks.Add(Instantiate(prefab1, pos, Quaternion.identity));
            }
        }
    }

    public void ResetBricks()
    {
        for (int index = 0; index < bricks.Count; index++)
        {
            Destroy(bricks[index]);
        }
    }

    void Update()
    {
        Debug.Log(bricks);
        int count = countActiveBricks();

        if (count == 0)
        {
            Ball ball = GameObject.Find("ball").GetComponent<Ball>();
            ball.winState = true;
            ball.winText.enabled = true;
        }
        else
        {
            bgmSource.pitch = 1.0f + (1.0f - ((float)count /(float)maxActiveBricks)) * 0.2f;
            Debug.Log("pitch:" + bgmSource.pitch);
        }
    }
    void Start()
    {
        bricks = new List<GameObject>();
        GenerateBricks(8, 3);
        maxActiveBricks = 24;

    }
    int countActiveBricks()
    {
        int count = 0;
        foreach (GameObject obj in bricks)
        {
            if (obj != null) // Check if GameObject is not null (not missing)
            {
                count++;
            }
        }
        return count;
    }
}

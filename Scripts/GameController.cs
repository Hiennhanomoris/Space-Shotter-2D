using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public GameObject enemy1;
    public GameObject asteroid1;
    [SerializeField] private float timeWait;
    [SerializeField] private int numOfasteroid;
    [SerializeField] private Vector3 pos;
    private int score;

    public void Awake() 
    {
        if(Instance != null && Instance != this)
        {
            Instance = this;
        }
        score = 0;
        if(enemy1 == null || asteroid1 == null)
        {
            enemy1 = GameObject.FindGameObjectWithTag("enemy1");
            asteroid1 = GameObject.FindGameObjectWithTag("asteroid1");  
        }  
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());   
    }

    public IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(timeWait);
        while(true)
        {
            for(int i = 0; i < numOfasteroid; i++)
            {
                Vector3 temp = new Vector3(Random.Range(-pos.x, pos.x), pos.y, pos.z);
                Instantiate(asteroid1, temp, Quaternion.identity);
            }

            if(score%5 == 0)
            {
                Vector3 temp = new Vector3(Random.Range(-pos.x, pos.x), pos.y, pos.z);
                Instantiate(enemy1, temp, Quaternion.identity);
            }
            yield return new WaitForSeconds(timeWait);
        }
    }

    public void IncreScore(int point)
    {
        score += point;
    }
}

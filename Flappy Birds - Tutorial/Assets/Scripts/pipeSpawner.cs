using Unity.Collections;
using UnityEngine;

public class pipeSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate){
            timer += Time.deltaTime;
        }
        else {
            spawnPipe();
            timer = 0;
        }
    }
    void spawnPipe()
    {
        float lowestPopint = transform.position.y - heightOffset;
        float highestPopint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPopint,highestPopint), 0), transform.rotation);
    }
}

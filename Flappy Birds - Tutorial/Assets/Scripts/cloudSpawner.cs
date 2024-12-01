using UnityEngine;

public class cloudSpawner : MonoBehaviour
{
    public GameObject cloud;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate){
            timer += Time.deltaTime;
        }
        else {
            spawnCloud();
            timer = 0;
            spawnRate = Random.Range(2,6);
        }
    }
    void spawnCloud()
    {
        float lowestPopint = transform.position.y - heightOffset;
        float highestPopint = transform.position.y + heightOffset;

        Instantiate(cloud, new Vector3(transform.position.x, Random.Range(lowestPopint,highestPopint), 0), transform.rotation);
    }
}

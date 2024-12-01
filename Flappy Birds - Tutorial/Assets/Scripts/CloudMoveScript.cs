using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CloudMoveScript : MonoBehaviour
{
    public float moveSpeed = 1;
    public float deadZone = -20;
    public float cloud_size = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomnizeCloud();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe deleted");
            Destroy(gameObject);
        }
    }
    void randomnizeCloud()
    {
        cloud_size = Random.Range(1, 4); 
        transform.localScale = new Vector3((cloud_size/2) * 1f, (cloud_size/2) *1f, 1f);
        moveSpeed = cloud_size * 2;
    }

}

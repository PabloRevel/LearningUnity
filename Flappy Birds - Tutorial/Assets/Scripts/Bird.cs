using Unity.VisualScripting;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdCanFly = true;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdCanFly)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }
        if (transform.position.y > 13 || transform.position.y < -12)
        {
            logic.gameOver();
            birdCanFly = false;
            Destroy(gameObject);
        }
    }
   private void OnCollisionEnter2D(Collision2D collison)
   {
    logic.gameOver();
    birdCanFly = false;
   }

}

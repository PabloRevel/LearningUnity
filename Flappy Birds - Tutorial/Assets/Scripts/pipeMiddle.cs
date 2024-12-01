using Unity.VisualScripting;
using UnityEngine;

public class pipeMiddle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public LogicScript logic;
    void Start()
    {   
        // Relaciona con el objeto taggeado en unity como "Logic" (LogicManager):
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3){
            logic.addScore(1);
        }
    }
}

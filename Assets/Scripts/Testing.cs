using UnityEngine;

public class Testing : MonoBehaviour
{
    public int score = 7;
    public int speed = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizonal = Input.GetAxis("Horizontal");
        Debug.Log(moveHorizonal);

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizonal, moveVertical);

        transform.Translate(movement * speed * Time.deltaTime);

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Debug.Log("D was pressed");
        //    transform.Translate(Vector2.right * speed * Time.deltaTime);
        //}
    }
}

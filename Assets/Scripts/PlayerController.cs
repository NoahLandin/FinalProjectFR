using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float xRange = 8.5f;  // adjust to your screen bounds
    public float yRange = 4.5f;  // adjust to your screen bounds
    public GameObject Puck1;
    public GameObject Blocky;
    public GameObject scoreText;
    public GameObject gameOverText;

    void Start()
    {
        Instantiate(Blocky, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
    }

    void Update()
    {
        //

        // Get input
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Move the movement
        transform.Translate(new Vector2(moveHorizontal, moveVertical) * speed * Time.deltaTime);

        // Keep inside bounds
        float clampedX = Mathf.Clamp(transform.position.x, -xRange, xRange);
        float clampedY = Mathf.Clamp(transform.position.y, -yRange, yRange);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blocky"))
        {
            Destroy(other.gameObject);
            Debug.Log("Hit Blocky");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Blocky"))
        {
            Debug.Log("You hit a blocky!");
            Destroy(other.gameObject);
            Instantiate(Blocky, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
            Instantiate(Puck1, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);

            scoreText.GetComponent<ScoreKeeper>().UpdateScore();
        }

        if(other.gameObject.CompareTag("Puck"))
        {
            gameOverText.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float laneDistance = 2f; // Distance moved per swipe
    public float horizontalMoveSpeed = 10f; // How fast to move sideways
    public float rightLimit = 8.0f;
    public float leftLimit = -8.0f;

    private float targetX; // Where the player should move to
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private float swipeThreshold = 50f;
    public GameObject lostPanel; // Reference to the lost panel
    void Start()
    {
        targetX = transform.position.x;
    }

    void Update()
    {
        // Always move forward (frame-rate independent)
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        // Smooth sideways movement (frame-rate independent)
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.MoveTowards(currentPosition.x, targetX, horizontalMoveSpeed * Time.deltaTime);
        transform.position = currentPosition;

        // Input handling: Editor (mouse) vs Device (touch)
        if (Application.isEditor)
        {
            // Mouse input for testing in Editor
            if (Input.GetMouseButtonDown(0))
            {
                startTouchPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                endTouchPosition = Input.mousePosition;
                Vector2 swipe = endTouchPosition - startTouchPosition;

                if (Mathf.Abs(swipe.x) > swipeThreshold && Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                {
                    if (swipe.x < 0)
                        MoveLeft();
                    else
                        MoveRight();
                }
            }
        }
        else
        {
            // Touch input for mobile devices
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                HandleSwipe(touch.phase, touch.position);
            }
        }
    }


    void HandleSwipe(TouchPhase phase, Vector2 position)
    {
        switch (phase)
        {
            case TouchPhase.Began:
                startTouchPosition = position;
                break;

            case TouchPhase.Ended:
                endTouchPosition = position;
                Vector2 swipe = endTouchPosition - startTouchPosition;

                if (Mathf.Abs(swipe.x) > swipeThreshold && Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                {
                    if (swipe.x < 0)
                        MoveLeft();
                    else
                        MoveRight();
                }
                break;
        }
    }

    void MoveLeft()
    {
        if (targetX > leftLimit)
        {
            targetX -= laneDistance;
            Debug.Log("Swipe Left");
        }
    }

    void MoveRight()
    {
        if (targetX < rightLimit)
        {
            targetX += laneDistance;
            Debug.Log("Swipe Right");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            lostPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            lostPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1; // Resume the game

        SceneManager.LoadScene(0);
    }
}

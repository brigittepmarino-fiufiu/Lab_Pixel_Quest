using UnityEngine;
using UnityEngine.SceneManagement;

// This script sits on the Player (the colored square).
// It moves the player, makes the player jump, changes the player color
// and it also handles dying on spikes, bouncing on a bounce pad and
// touching the goal to go to the next level.
public class GeoController : MonoBehaviour
{
    // ---- These show up in the Inspector so they are easy to change ----
    public float speed = 6f;        // how fast we move left and right
    public float jumpPower = 9f;    // how high we jump with Space
    public float bouncePower = 16f; // how high a bounce pad throws us
    public bool followCamera = true; // should the camera follow the player?

    // ---- Things we need to talk to ----
    private Rigidbody2D rb;             // the player's physics body
    private SpriteRenderer spriteRenderer; // the player's picture

    // ---- A simple check so we can only jump when we are standing ----
    private bool onGround = false;

    // Start runs one time when the level begins.
    void Start()
    {
        // Grab the components that are on this object.
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update runs every frame.
    void Update()
    {
        // ---------- Move left and right ----------
        // "Horizontal" is A / D and the Left / Right arrow keys in Unity.
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // ---------- Jump with Space ----------
        if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            // We keep our left / right speed but add jump speed going up.
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        // ---------- Change color with the 1, 2 and 3 keys ----------
        // Color numbers go from 0 to 1 (0 is none, 1 is full).
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spriteRenderer.color = new Color(1f, 0f, 0f); // red
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spriteRenderer.color = new Color(0f, 1f, 0f); // green
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spriteRenderer.color = new Color(0f, 0f, 1f); // blue
        }
    }

    // LateUpdate runs after Update. We move the camera here so it does not
    // shake while the player is moving.
    void LateUpdate()
    {
        if (followCamera == true && Camera.main != null)
        {
            // Put the camera on top of the player (z stays at -10 so we can still see).
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }
    }

    // This runs when the player bumps into something solid (a wall or a floor).
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Simple way to know we are standing on something.
        onGround = true;
    }

    // This runs when the player leaves something solid.
    void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }

    // This runs when the player enters a trigger (spikes, bounce pads and goals).
    void OnTriggerEnter2D(Collider2D collision)
    {
        // ---------- Spikes (they have the tag "Death") ----------
        if (collision.tag == "Death")
        {
            Debug.Log("Player hit a spike - restarting level");

            // Reload the level we are in right now.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // ---------- Bounce pad (it has the tag "Bounce") ----------
        if (collision.tag == "Bounce")
        {
            // Throw the player up into the air.
            rb.velocity = new Vector2(rb.velocity.x, bouncePower);
        }

        // ---------- Goal (it has the tag "Goal") ----------
        if (collision.tag == "Goal")
        {
            GoToNextLevel();
        }
    }

    // Load the next level. If this was the last level, start over at level 1.
    void GoToNextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextLevel < SceneManager.sceneCountInBuildSettings)
        {
            // There is another level, so load it.
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            // We beat the last level, so go back to the first level.
            Debug.Log("You beat the last level!");
            SceneManager.LoadScene(0);
        }
    }
}

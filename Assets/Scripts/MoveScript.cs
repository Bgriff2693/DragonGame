using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MoveScript : MonoBehaviour
{
    // 1 - Designer variables

    /// <summary>
    /// Object speed
    /// </summary>
    public Vector2 speed = new Vector2(GameObject.Find("Dragon").GetComponent<PlayerScript>().speed.x + 10, GameObject.Find("Dragon").GetComponent<PlayerScript>().speed.y + 10);

    /// <summary>
    /// Moving direction
    /// </summary>
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;

    private int t;

    void Start()
    {
        t = 0;
    }

    void Update()
    {
        // 2 - Movement
        movement = new Vector2(
          speed.x * direction.x,
          (speed.y * direction.y) - (rigidbody2D.gravityScale * (t/5)));
        ++t;
    }

    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        rigidbody2D.velocity = movement;
    }
}
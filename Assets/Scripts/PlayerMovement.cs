using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    ///private const float Acceleration = 1;

    public Rigidbody2D rb;
    public float moveSpeed = 1f;

    ///public SpriteRenderer spriteRenderer;

    ///private Transform _transform;

    ///public Vector2 movementVector = Vector2.zero;
    public Animator animator;

    public Vector2 movement;
    
// Start is called before the first frame update
    /* private void Start()
    {
        _rigidBodyComponent = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
    } */

    // Update is called once per frame
    void Update()
    {
        /* var w = Input.GetKey(KeyCode.W) ? 0.1 : 0;
        var s = Input.GetKey(KeyCode.S) ? -0.1 : 0;
        var a = Input.GetKey(KeyCode.A) ? 0.1 : 0;
        var d = Input.GetKey(KeyCode.D) ? -0.1 : 0; */

        /* movementVector = new Vector2(-((float) a + (float) d), (float) w + (float) s);
        movementVector.Normalize();

        _rigidBodyComponent.velocity = movementVector * Acceleration;
        if (!(movementVector.magnitude > Mathf.Epsilon)) return;
        var angle = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(angle); */
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //var positionY = _transform.position.y / 0.25;
        //_spriteRenderer.sortingOrder = -(int) positionY * 100;
    }

    void FixedUpdate()
    {
        var speedMultiplier = movement.x != 0 && movement.y != 0 ? 0.75f : 1f;
        rb.MovePosition(rb.position + movement * (Time.fixedDeltaTime * speedMultiplier));
    }
}
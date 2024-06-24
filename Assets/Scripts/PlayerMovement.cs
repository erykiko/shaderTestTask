using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private FieldOfView fov;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        MoveX();
        MoveY();
        fov.SetOrigin(transform.position);
    }
    void MoveX(){
        float moveX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(moveX, 0f, 0f) * moveSpeed * Time.deltaTime;
    }
    void MoveY(){
        float moveY = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(0f, moveY, 0f) * moveSpeed * Time.deltaTime;
    }
}


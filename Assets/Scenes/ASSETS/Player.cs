
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject stand;
    public GameObject crouch;
    public Rigidbody2D _rb;
    bool _isJumping = false;
    public GameManager gameManager;

    public AudioSource JumpSound;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _isJumping = false;
        JumpSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        Jump();
        Crouch();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isJumping = false;
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && _isJumping == false)
        {
            _rb.velocity = new Vector3(0, 22, 0);
            _isJumping = true;
            JumpSound.Play();
        }
    }
    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && _isJumping == false)
        {
            crouch.SetActive(true);
            stand.SetActive(false);
        }
            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            gameManager.GameOver();
        }
    }
}

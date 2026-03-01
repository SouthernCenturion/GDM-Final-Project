using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour 
{     
    public float moveSpeed = 5f;     
    public float jumpForce = 12f;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    
    private Rigidbody2D rb;     
    private bool isGrounded = false;
    private int health = 100;
    private int score = 0;
    
    void Start()     
    {         
        rb = GetComponent<Rigidbody2D>();
        UpdateUI();
    }          
    
    void Update()     
    {         
        float moveInput = Input.GetAxis("Horizontal");         
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
                 
        if (Input.GetButtonDown("Jump") && isGrounded)         
        {             
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }     
    }

    void UpdateUI()
    {
        healthText.text = "Health: " + health;
        scoreText.text = "Score: " + score;
    }
    
    void OnCollisionEnter2D(Collision2D collision)     
    {         
        if (collision.gameObject.CompareTag("Ground"))         
        {             
            isGrounded = true;         
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10;
            UpdateUI();
                if (health <= 0)
                {
                    PlayerPrefs.SetInt("FinalScore", score);
                    SceneManager.LoadScene(0);
                }
        }
    }          
    
    void OnCollisionExit2D(Collision2D collision)     
    {         
        if (collision.gameObject.CompareTag("Ground"))         
        {             
            isGrounded = false;         
        }     
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score += 10;
            Destroy(other.gameObject);
            UpdateUI();
        }
    }
}
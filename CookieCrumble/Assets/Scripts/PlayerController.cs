using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //private inspector variable
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private Transform groundCheckPos; //ground check overlapcircle position
    [SerializeField] private float groundCheckRadius; //ground check overlapcircle radius
    [SerializeField] private LayerMask whatIsGround; //ground Layer Mask
    public AudioClip cakeSound,deadSound, jumpSound, completeSound, colorSwapsound, keySound;
    public AudioSource audio;
    bool hasKey=false;
    Transform playerDefaultPostition;
    public Sprite playerSpriteRenderer;
    //private variable
    private Rigidbody2D rBody;
    private bool isGrounded = false;
    private Animator anim;
    private bool isFacingRight = true;
    Color playerColor;
    int i = 0;
    public Sprite [] playerSprites;
    private Vector2 pos;
    bool pink, brown, vanilla;
    public bool onVertPlatform;
    public static string color;
    int  scene_number;
    public GameObject bullet;
    public Transform bulletSpawn;
    public float bulletSpeed = 30;
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pos = rBody.position;
        audio = GetComponent<AudioSource>();
        
        playerSpriteRenderer = GetComponent<SpriteRenderer>().sprite;
        scene_number = SceneManager.GetActiveScene().buildIndex;
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.F))
        {
          if(pink)
            {
                if (this.GetComponent<SpriteRenderer>().sprite != playerSprites[0])
                {
                    audio.PlayOneShot(colorSwapsound);
                }
                this.GetComponent<SpriteRenderer>().sprite = playerSprites[0];
                color = "Pink";
            }
            else if (vanilla)
            {
                if (this.GetComponent<SpriteRenderer>().sprite != playerSprites[1])
                {
                    audio.PlayOneShot(colorSwapsound);
                }
                this.GetComponent<SpriteRenderer>().sprite = playerSprites[1];
                color = "Vanilla";
            }
            else if (brown)
            {
                if (this.GetComponent<SpriteRenderer>().sprite != playerSprites[2])
                {
                    audio.PlayOneShot(colorSwapsound);
                }
                this.GetComponent<SpriteRenderer>().sprite = playerSprites[2];
                color = "Brown";
            }
        }


      

        //check if on ground
        isGrounded = GroundCheck();
        //jump code
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            audio.PlayOneShot(jumpSound);
            rBody.AddForce(new Vector2(5.0f, jumpForce));
        }

        float horiz = Input.GetAxis("Horizontal");
        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        //check if sprite needs to be flipped
        if (isFacingRight && rBody.velocity.x < 0)
            Flip();
        else if (!isFacingRight && rBody.velocity.x > 0)
            Flip();

        //send value to animator
        //anim.SetFloat("xSpeed", Mathf.Abs(rBody.velocity.x)); //also horiz works
        //anim.SetFloat("ySpeed", Mathf.Abs(rBody.velocity.y));
        //anim.SetBool("isGrounded", isGrounded);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            ScoreCounter.scoreValue = ScoreCounter.scoreValue + 1;
            audio.PlayOneShot(cakeSound);
        }
        if (collision.gameObject.CompareTag("key"))
        {
            audio.PlayOneShot(keySound);
            Destroy(collision.gameObject);
            hasKey = true;
        }
       
        if (collision.gameObject.CompareTag("door"))
        {
           
            if (hasKey)
            {
                audio.PlayOneShot(completeSound);
                StartCoroutine(WaitAndLoadScene());
                //if (scene_number==2)
                //SceneManager.LoadScene(scene_number);
                //else
                //{
                //    scene_number++;
                //    SceneManager.LoadScene(scene_number);
                //}
            }
        }
        if (collision.gameObject.CompareTag("sceneBorder"))
        {
            audio.PlayOneShot(deadSound);
            LivesSystem.life = LivesSystem.life - 1;
            rBody.position = pos;
        }
        if (collision.gameObject.CompareTag("pink"))
        {
            pink = true;
            brown = false;
            vanilla = false;
                
        }
        if (collision.gameObject.CompareTag("vanilla"))
        {
            pink = false;
            brown = false;
            vanilla = true;
        }
        if (collision.gameObject.CompareTag("brown"))
        {
            pink = false;
            brown = true;
            vanilla = false;
        }

        if (collision.gameObject.CompareTag("vert"))
        {
            onVertPlatform = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("vert"))
        {
            onVertPlatform = false;
        }
    }
    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
    }

    void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }
    IEnumerator ColorChange()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("i");
    

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            color = "";
            audio.PlayOneShot(deadSound);
            LivesSystem.life = LivesSystem.life - 1;
            this.GetComponent<SpriteRenderer>().sprite=playerSpriteRenderer;
            rBody.position = pos;
            //Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

    void Shoot()
    {
        //Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        //bullet.GetComponent<Rigidbody2D>().velocity = this.transform.forward * bulletSpeed;

        GameObject bulletInstance = Instantiate(bullet, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 1)));
        bulletInstance.GetComponent<Rigidbody2D>().velocity = transform.forward * 30;

        Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}

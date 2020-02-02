using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class playerHealth : MonoBehaviour
{
    public int health = 1;
    private float maskTimer = 0f;
    private float coffeeTimer = 0f;
    private float wheatTimer = 0f;
    private float gameTimer = 300f;
    public SpriteRenderer face; 
    public Sprite[] MaskSprite;
    public Sprite[] NoMaskSprite;
    public Animator animdead;

    public moveMe runScript;
    public CharacterController2D jumpScript;

    public GameObject loseMenu;
    public GameObject winMenu;

    public GameObject CoffeeSound;
    public GameObject WheatSound;
    public GameObject MaskSound;
    public GameObject BadVibesSound;
    public GameObject WinSound;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        runScript = GetComponent<moveMe>();
    }

    private void Update()
    {
        if (coffeeTimer >= 0.0f)
        {
            coffeeTimer -= Time.deltaTime;

            if (coffeeTimer < 0.0f)
            {
                runScript.runSpeed = 20f;
            }
        }

        if (wheatTimer >= 0.0f)
        {
            wheatTimer -= Time.deltaTime;

            if (wheatTimer < 0.0f)
            {
                jumpScript.m_JumpForce = 400f;
            }
        }

        if (maskTimer >= 0.0f)
        {
            maskTimer -= Time.deltaTime;

            if (maskTimer < 0.0f)
            {
                NoMaskSprite = Resources.LoadAll<Sprite>("noMask");
                GameObject Mask = new GameObject();
                face.sprite = NoMaskSprite[0];
                health = 1;
            }
        }

        if (gameTimer >= 0.0f)
        {
            gameTimer -= Time.deltaTime;

            if (gameTimer < 0.0f)
            {
                animdead.SetBool("isDead", true);
                Destroy(gameObject);
                lose();
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            health -= 1;

            if (health <= 0)
            {
                animdead.SetBool("isDead", true);
                Destroy(gameObject);
                lose();
            }
        }

        {
            if (other.gameObject.CompareTag("Boundry"))
            {
                animdead.SetBool("isDead", true);
                Destroy(gameObject);
                lose();
            }
        }

        if (other.gameObject.CompareTag("Grass"))
        {
            Instantiate(WheatSound, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            jumpScript.m_JumpForce = 700f;
            wheatTimer = 30f;
        }

        if (other.gameObject.CompareTag("Coffee"))
        {
            Instantiate(CoffeeSound, transform.position, Quaternion.identity);
            runScript.runSpeed = 30f;
            coffeeTimer = 30f;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Mask"))
        {
            Instantiate(MaskSound, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            MaskSprite = Resources.LoadAll<Sprite>("Mask");
            GameObject Mask = new GameObject();
            face.sprite = MaskSprite[0];
            maskTimer = 30f;
            health = 100;
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            win();
        }
    }

        public void win()
    {
        Instantiate(WinSound, transform.position, Quaternion.identity);
        winMenu.SetActive(true);
    }
    public void lose()
    {
        Instantiate(BadVibesSound, transform.position, Quaternion.identity);
        loseMenu.SetActive(true);
    }
}

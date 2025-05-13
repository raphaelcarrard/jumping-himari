using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour
{
    
    public static PlayerJump instance;
    private Rigidbody2D rb;
    private Animator anim;
    public AudioSource landSound, deadSound;

    [SerializeField]
    private float forceX, forceY;
    private bool didJump, setPower;
    private float thresholdX = 7f;
    private float thresholdY = 14f;

    private Slider powerBar;
    private float powerBarThreshold = 10f;
    private float powerBarValue = 0f;

    void Awake()
    {
        MakeInstance();
    }

    void Update()
    {
        SetPower();
        Initialize();
    }

    void Initialize()
    {
        powerBar = GameObject.Find("PowerBar").GetComponent<Slider>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        powerBar.minValue = 0f;
        powerBar.maxValue = 10f;
        powerBar.value = powerBarValue;
    }

    public void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void SetPower()
    {
        if (setPower && !didJump)
        {
            forceX += thresholdX * Time.deltaTime;
            forceY += thresholdY * Time.deltaTime;
            if (forceX < 3f)
            {
                forceX = 3f;
            }
            if (forceX > 6.5f)
            {
                forceX = 6.5f;
            }
            if (forceY < 3f)
            {
                forceY = 3f;
            }
            if (forceY > 13.5f)
            {
                forceY = 13.5f;
            }
            powerBarValue += powerBarThreshold * Time.deltaTime;
            powerBar.value = powerBarValue;
        }
    }

    public void SetPower(bool setPower)
    {
        this.setPower = setPower;
        if (!setPower && !didJump)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(forceX, forceY);
        forceX = forceY = 0;
        didJump = true;
        anim.SetBool("jump", didJump);
        powerBarValue = 0f;
        powerBar.value = powerBarValue;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (didJump)
        {
            didJump = false;
            anim.SetBool("jump", didJump);
            if (target.tag == "Platform")
            {
                if (GameManager.instance != null)
                {
                    GameManager.instance.CreateNewPlatformAndLerp(target.transform.position.x);
                    landSound.Play();
                }
                if (ScoreManager.instance != null)
                {
                    ScoreManager.instance.IncrementScore();
                    AchievementManager.instance.CheckAchievements();
                }
            }
        }
        if (target.tag == "Dead")
        {
            if (GameOverManager.instance != null)
            {
                GameOverManager.instance.ShowGameOverPanel();
            }
            Destroy(gameObject);
        }
    }
}

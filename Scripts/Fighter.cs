using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {
    public enum PlayerType
    {
        PLAYER1, PLAYER2, AI, DUMMY
    };

    public float speed;
    float move;
    float moveHorizontal;
    float moveVertical;
    public bool facingRight = true;

    private Rigidbody2D rb2d;    
    private AudioSource source;
    public Animator anim;

    public bool grounded;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce;

    bool doubleJump;

    float buttonCooler = 0.5f;
    int buttonCount = 0;

    public bool tapDash = false;

    public float timeDelay = 1f;
    float timestamp;

    public static float maxHealth = 1000f;
    public float health = maxHealth;
    public string fighterName;
    public Fighter opponent;
    GameObject fighter;
    public bool enable;
    public bool ultimate = false;

    public string horizontalButton;
    public string verticalButton;
    public string punch1Button;
    public string punch2Button;
    public string kick1Button;
    public string kick2Button;
    public string blockButton;
    public string ultimateButton;
    public string triggerButton;

    public PlayerType player;
    public FighterStates currentState = FighterStates.IDLE;

    float damage = 50f;

    public AudioClip jumpEffect;
    public AudioClip hitEffect;
    public AudioClip ultimateEffect;
    public AudioClip deadEffect;

    bool poison = false;
    int seconds;
    float timer;
    bool slow = false;

    public bool kombo1, kombo2, kombo3;
    bool dead = false;

    //AI only
    private float randomFloat, randomSetTime;
    public float aiDelay;
    private int randomInt;
    public RuntimeAnimatorController ai;

    //FIKom only
    bool immune=false, fikomKombo1, fikomKombo2, fikomKombo2_1;

    //FPsi only
    public GameObject bullet1, bullet2, fist, ball, ultBeam1, ultBeam2, ultBeam3;

    //FK only
    public GameObject syringe;
    public bool monster;

    //FE only
    public GameObject cc, coin;

    //FK & FE
    public AudioClip regenEffect;
    public int komboCount = 0;
    bool feKombo;

    //FT only
    public GameObject ruler, gokart;

    //FH only
    public AudioClip splitEffect;
    bool fhKombo1, fhKombo2;
    int counterChance;

    //FSRD only
    public GameObject ink, dragon;
    bool fsrdKombo1, fsrdKombo2;

    //FTI only
    public GameObject laser;
    public GameObject[] cameo;
    bool ftiKombo1, ftiKombo2;

    //FTI & FPsi
    private GameObject projectileChild;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        source.volume = PlayerPrefs.GetFloat("SfxVolume");

        if (player == PlayerType.PLAYER1)
        {
            horizontalButton = "Horizontal";
            verticalButton = "Vertical";
            punch1Button = "Punch1";
            punch2Button = "Punch2";
            kick1Button = "Kick1";
            kick2Button = "Kick2";
            blockButton = "Block";
            ultimateButton = "Ultimate";
            triggerButton = "LeftTrigger";
        }
        else if (player == PlayerType.PLAYER2)
        {
            horizontalButton = "Horizontal_P2";
            verticalButton = "Vertical_P2";
            punch1Button = "Punch1_P2";
            punch2Button = "Punch2_P2";
            kick1Button = "Kick1_P2";
            kick2Button = "Kick2_P2";
            blockButton = "Block_P2";
            ultimateButton = "Ultimate_P2";
            triggerButton = "LeftTrigger_P2";
        }

        if (GameManager.gm.gameMode != "practice")
        {
            if (player == PlayerType.PLAYER2 || player == PlayerType.AI)
            {
                fighter = GameObject.Find("Player 1");
                opponent = fighter.GetComponent<Fighter>();
                facingRight = false;
            }
            else if (player == PlayerType.PLAYER1)
            {
                fighter = GameObject.Find("Player 2");
                opponent = fighter.GetComponent<Fighter>();
            }
        }
    }

    void UpdatePlayerInput()
    {
        if (gameObject.tag == "FPsi")
            FPsi();
        else if (gameObject.tag == "FIKom")
            FIKom();
        else if (gameObject.tag == "FK")
            FK();
        else if (gameObject.tag == "FE")
            FE();
        else if (gameObject.tag == "FT")
            FT();
        else if (gameObject.tag == "FH")
            FH();
        else if (gameObject.tag == "FSRD")
            FSRD();
        else if (gameObject.tag == "FTI")
            FTI();

        if (Time.time >= timestamp)
        {
            kombo1 = false;
            kombo2 = false;
            kombo3 = false;
        }
    }

    void UpdateAiInput()
    {
        anim.runtimeAnimatorController = ai as RuntimeAnimatorController;

        anim.SetFloat("opponent_Health", opponent.healthPercent);
        anim.SetBool("opponent_Attack", opponent.attacking);
        anim.SetFloat("distanceToOpponent", getDistanceToOpponent());
        anim.SetFloat("player_Health", healthPercent);

        if (Time.time - randomSetTime > 1)
        {
            if(gameObject.tag=="FIKom")
                randomInt = Random.Range(1, 4);
            else
                randomInt = Random.Range(1, 6);
            randomFloat = Random.value;
            randomSetTime = Time.time;
        }
        anim.SetInteger("random_Int", randomInt);
        anim.SetFloat("random_Float", randomFloat);

        if (Time.time >= aiDelay)
            anim.SetFloat("Delay", 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.tag != "FPsi")
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            anim.SetBool("Ground", grounded);
        }

        if (enable)
        {
            if (player == PlayerType.PLAYER1 || player == PlayerType.PLAYER2)
            {
                if (dead == false)
                    UpdatePlayerInput();
            }
            else if (player == PlayerType.AI)
                UpdateAiInput();
        }

        if (poison == true)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                health -= health * 0.03f;
                timer = 0;
                seconds += 1;
            }                
            if(seconds== 5)
            {
                poison = false;
                seconds = 0;
            }                
        }

        if (slow == true)
        {
            speed -= (speed - 1);
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                seconds += 1;
                timer = 0;
            }
            if (seconds == 5)
            {
                speed += 1;
                slow = false;
                seconds = 0;
            }
        }

        if (health <= 0 && currentState != FighterStates.DEAD)
        {
            dead = true;
            anim.SetBool("Dead", true);
            source.clip = deadEffect;
            source.Play();
        }
        else if (health > 0)
        {
            dead = false;
            anim.SetBool("Dead", false);
        }
    }

    void Jump()
    {
        if (grounded)
        {
            anim.SetBool("Ground", false);
            rb2d.velocity = new Vector2(0, jumpForce);
            doubleJump = true;
        }

        if (!grounded && doubleJump)
        {
            rb2d.velocity = new Vector2(0, jumpForce * 1.7f);
            doubleJump = false;
            source.clip=jumpEffect;
            source.Play();
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private float getDistanceToOpponent()
    {
        return Mathf.Abs(transform.position.x - opponent.transform.position.x);
    }

    public bool defending
    {
        get
        {
            return currentState == FighterStates.DEFEND;
        }
    }

    public bool attacking
    {
        get
        {
            return currentState == FighterStates.ATTACK;
        }
    }

    public float healthPercent
    {
        get
        {
            return health / maxHealth;
        }
    }

    public Rigidbody2D body
    {
        get
        {
            return this.rb2d;
        }
    }

    void FIKom()
    {
        if ((Input.GetButton(horizontalButton) || Input.GetAxisRaw(horizontalButton) != 0) && Time.time >= timestamp)
            move = Input.GetAxis(horizontalButton);
        else
            move = 0;

        anim.SetFloat("Speed", Mathf.Abs(move));

        if(move!=0)
            rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);

        if (Input.GetAxisRaw(verticalButton) > 0 && Time.time >= timestamp)
            Jump();

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        if (Input.GetButtonDown(horizontalButton))
        {
            if (buttonCooler > 0 && buttonCount == 1)
            {
                speed *= 2f;
            }
            else
            {
                buttonCooler = 0.5f;
                buttonCount += 1;
            }
        }

        if (Input.GetAxisRaw(triggerButton) != 0)
        {
            if (tapDash == false)
            {
                speed *= 2f;
                tapDash = true;
            }
        }
        else if (Input.GetAxisRaw(triggerButton) == 0)
        {
            tapDash = false;
        }

        if (buttonCooler > 0)
            buttonCooler -= 1 * Time.deltaTime;
        else
            buttonCount = 0;

        if (move == 0)
        {
            if (Input.GetButtonUp(punch1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Punch1");
                timestamp = Time.time + timeDelay;
                kombo1 = true;
                kombo3 = true;
            }
            if (Input.GetButtonDown(punch2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Punch2");
                timestamp = Time.time + timeDelay;
                kombo2 = true;
            }
            if (Input.GetButtonDown(kick1Button) && Time.time >= timestamp || Input.GetButtonDown(kick2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Dodge");
            }
            if (Input.GetButton(blockButton))
            {
                anim.SetBool("Block", true);
                if (defending)
                {
                    speed = 0f;
                    jumpForce = 0f;
                    anim.ResetTrigger("Punch1");
                    anim.ResetTrigger("Punch2");
                    anim.ResetTrigger("Dodge");
                    timestamp = Time.time + timeDelay / 2;
                }
            }
            else
            {
                anim.SetBool("Block", false);
                speed = 2f;
                jumpForce = 3f;
            }

            if (kombo1 == true)
            {
                if (Input.GetButtonDown(punch1Button))
                {
                    anim.SetTrigger("Punch1");
                    kombo1 = false;
                    kombo3 = false;
                    fikomKombo1 = true;
                    timestamp = Time.time + timeDelay;
                }
            }

            if (Input.GetButtonDown(punch2Button) && fikomKombo1 == true)
            {
                anim.SetTrigger("Kombo1");
                fikomKombo1 = false;
                timestamp = Time.time + timeDelay;
            }

            if (kombo2 == true)
            {
                if (Input.GetButtonDown(punch1Button))
                {
                    anim.SetTrigger("Kombo2");
                    kombo2 = false;
                    timestamp = Time.time + timeDelay;
                }
            }

            if (kombo3 == true)
            {
                if (Input.GetButtonDown(punch2Button))
                {
                    anim.SetTrigger("Kombo1");
                    kombo1 = false;
                    kombo3 = false;
                    fikomKombo2 = true;
                    timestamp = Time.time + timeDelay;
                }
            }

            if (Input.GetButtonDown(punch1Button) && fikomKombo2 == true)
            {
                anim.SetTrigger("Kombo3");
                fikomKombo1 = false;
                fikomKombo2_1 = true;
                timestamp = Time.time + timeDelay;
            }

            if (Input.GetButtonDown(punch2Button) && fikomKombo2_1 == true)
            {
                anim.SetTrigger("Kombo4");
                fikomKombo2_1 = false;
                timestamp = Time.time + timeDelay;
            }

            if (Input.GetButtonDown(ultimateButton) && ultimate == false && healthPercent <= 0.2)
            {
                anim.SetTrigger("Ult_Start");
                ultimate = true;
                timestamp = Time.time + timeDelay;
            }
        }

        if (speed>=4)
        {
            if (Input.GetButtonDown(punch2Button))
            {
                anim.SetTrigger("RunPunch");
                speed = 0f;
            }
        }

        if (grounded == false)
        {
            if (Input.GetButtonDown(punch1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpPunch1");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(punch2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpPunch2");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(kick2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpKick2");
                timestamp = Time.time + timeDelay;
            }
            anim.ResetTrigger("Punch1");
            anim.ResetTrigger("Punch2");
            anim.ResetTrigger("Dodge");
        }

        if (grounded == true)
        {
            anim.ResetTrigger("JumpPunch1");
            anim.ResetTrigger("JumpPunch2");
            anim.ResetTrigger("JumpKick2");
        }

        if (Time.time >= timestamp)
        {
            
            fikomKombo1 = false;
            fikomKombo2 = false;
            anim.ResetTrigger("Kombo1");
            anim.ResetTrigger("Kombo2");
            anim.ResetTrigger("Kombo3");
            anim.ResetTrigger("Kombo4");
        }
    }

    void FPsi()
    {
        if ((Input.GetButton(horizontalButton) || Input.GetAxisRaw(horizontalButton) != 0) && Time.time >= timestamp)
            moveHorizontal = Input.GetAxis(horizontalButton);
        else
            moveHorizontal = 0;

        if ((Input.GetButton(verticalButton) || Input.GetAxisRaw(verticalButton) != 0) && Time.time >= timestamp)
            moveVertical = Input.GetAxis(verticalButton);
        else
            moveVertical = 0;

        anim.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        rb2d.velocity = new Vector2(moveHorizontal, moveVertical) * speed;

        if (moveHorizontal > 0 && !facingRight)
            Flip();
        else if (moveHorizontal < 0 && facingRight)
            Flip();

        if (moveHorizontal == 0 && moveVertical == 0)
        {
            if (Input.GetButtonDown(punch1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Punch1");
                timestamp = Time.time + timeDelay;
                kombo1 = true;
            }
            if (Input.GetButtonDown(punch2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Punch2");
                timestamp = Time.time + timeDelay;
                kombo2 = true;
            }
            if (Input.GetButtonDown(kick1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Kick1");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(kick2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Kick2");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButton(blockButton))
            {
                anim.SetBool("Block", true);
                if (defending)
                {
                    speed = 0f;
                    jumpForce = 0f;
                    anim.ResetTrigger("Punch1");
                    anim.ResetTrigger("Punch2");
                    anim.ResetTrigger("Kick1");
                    anim.ResetTrigger("Kick2");
                    timestamp = Time.time + timeDelay / 2;
                }
            }
            else
            {
                anim.SetBool("Block", false);
                speed = 2f;
                jumpForce = 4f;
            }
            if (kombo1 == true)
            {
                if (Input.GetButtonDown(punch2Button))
                {
                    anim.SetTrigger("Kombo1");
                    kombo1 = false;
                }
            }
            if (kombo2 == true)
            {
                if (Input.GetButtonDown(punch1Button))
                {
                    anim.SetTrigger("Kombo2");                    
                    kombo2 = false;
                }
            }
            if (Input.GetButtonDown(ultimateButton))
            {
                anim.SetTrigger("Ult_Start");
                ultimate = true;
                timestamp = Time.time + timeDelay;
            }
        }
    }

    void FK()
    {
        if ((Input.GetButton(horizontalButton) || Input.GetAxisRaw(horizontalButton) != 0) && Time.time >= timestamp)
            move = Input.GetAxis(horizontalButton);
        else
            move = 0;

        anim.SetFloat("Speed", Mathf.Abs(move));

        if(move!=0)
            rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);

        if (Input.GetAxisRaw(verticalButton) > 0 && ultimate == false && Time.time >= timestamp)
            Jump();

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        if (Input.GetButtonDown(horizontalButton))
        {
            if (buttonCooler > 0 && buttonCount == 1)            
                speed *= 2f;            
            else
            {
                buttonCooler = 0.5f;
                buttonCount += 1;
            }
        }

        if (Input.GetAxisRaw(triggerButton) != 0)
        {
            if (tapDash == false)
            {
                speed *= 2f;
                tapDash = true;
            }
        }
        else if (Input.GetAxisRaw(triggerButton) == 0)        
            tapDash = false;        

        if (buttonCooler > 0)
            buttonCooler -= 1 * Time.deltaTime;
        else
            buttonCount = 0;

        if (move == 0)
        {
            if (Input.GetButtonDown(punch1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Punch1");
                if (monster == true)
                    timestamp = Time.time + timeDelay * 0.5f;
                else
                    timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(punch2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Punch2");
                if (monster == true)
                    timestamp = Time.time + timeDelay * 0.5f;
                else
                {
                    timestamp = Time.time + timeDelay;
                    kombo1 = true;
                    kombo2 = true;
                }
            }
            if (Input.GetButtonDown(kick1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Kick1");
                if(monster!=true)
                    timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(kick2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Kick2");
                if (monster != true)
                {
                    timestamp = Time.time + timeDelay;
                    kombo3 = true;
                }
            }
            if (Input.GetButton(blockButton))
            {
                anim.SetBool("Block", true);
                if (defending)
                {
                    speed = 0f;
                    jumpForce = 0f;
                    anim.ResetTrigger("Punch1");
                    anim.ResetTrigger("Punch2");
                    anim.ResetTrigger("Kick1");
                    anim.ResetTrigger("Kick2");
                    timestamp = Time.time + timeDelay / 2;
                }
            }
            else
            {
                anim.SetBool("Block", false);
                speed = 2f;
                jumpForce = 3f;
            }
            
            if (kombo1 == true)
            {
                if (Input.GetButtonDown(punch1Button))
                {
                    anim.SetTrigger("Kombo1");
                    timestamp = Time.time + timeDelay;
                    kombo1 = false;
                }
            }

            if (kombo2 == true)
            {
                if (Input.GetButtonDown(punch2Button))
                {
                    if (komboCount == 1)
                        anim.SetTrigger("Kombo2");
                    if (komboCount == 2)
                        anim.SetTrigger("Kombo2");
                    if (komboCount == 3)
                        anim.SetTrigger("Kombo2_1");
                    komboCount += 1;
                    timestamp += 0.33f;

                    if (komboCount > 3)
                    {
                        kombo2 = false;
                        komboCount = 0;
                    }
                }
            }

            if (kombo3 == true)
            {
                if (Input.GetButtonDown(punch1Button))
                {
                    anim.SetTrigger("Kombo3");
                    timestamp = Time.time + timeDelay;
                    kombo3 = false;
                }
            }

            if (Input.GetButtonDown(ultimateButton) && ultimate == false && healthPercent <= 0.2)
            {
                anim.SetTrigger("Ultimate");
                anim.SetBool("Monster", true);
                ultimate = true;
                timestamp = Time.time + timeDelay * 3f;
            }
        }

        if (grounded == false)
        {
            if (Input.GetButtonDown(punch1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpPunch1");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(punch2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpPunch2");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(kick1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpKick1");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(kick2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpKick2");
                timestamp = Time.time + timeDelay;
            }
            anim.ResetTrigger("Punch1");
            anim.ResetTrigger("Punch2");
            anim.ResetTrigger("Kick1");
            anim.ResetTrigger("Kick2");
        }

        if (grounded == true)
        {
            anim.ResetTrigger("JumpPunch1");
            anim.ResetTrigger("JumpPunch2");
            anim.ResetTrigger("JumpKick1");
            anim.ResetTrigger("JumpKick2");
        }

        if (Time.time >= timestamp)
        {
            anim.ResetTrigger("Kombo1");
            anim.ResetTrigger("Kombo2");
            anim.ResetTrigger("Kombo2_1");
            anim.ResetTrigger("RunPunch");
            komboCount = 0;
        }

        if (speed>=4)
        {
            if (Input.GetButtonDown(punch2Button))
            {
                anim.SetTrigger("RunPunch");
                speed = 0f;
            }
        }

        if (ultimate == true)
            monster = true;
        else
            monster = false;
    }

    void FE()
    {
        if ((Input.GetButton(horizontalButton) || Input.GetAxisRaw(horizontalButton) != 0) && Time.time >= timestamp)
            move = Input.GetAxis(horizontalButton);
        else
            move = 0;

        anim.SetFloat("Speed", Mathf.Abs(move));

        if (move != 0)
            rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);

        if (Input.GetAxisRaw(verticalButton) > 0 && Time.time >= timestamp)
            Jump();

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        if (Input.GetButtonDown(horizontalButton))
        {
            if (buttonCooler > 0 && buttonCount == 1)
                speed *= 2f;
            else
            {
                buttonCooler = 0.5f;
                buttonCount += 1;
            }
        }

        if (Input.GetAxisRaw(triggerButton) != 0)
        {
            if (tapDash == false)
            {
                speed *= 2f;
                tapDash = true;
            }
        }
        else if (Input.GetAxisRaw(triggerButton) == 0)
            tapDash = false;

        if (buttonCooler > 0)
            buttonCooler -= 1 * Time.deltaTime;
        else
            buttonCount = 0;

        if (move == 0)
        {
            if (Input.GetButtonDown(punch1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Punch1");
                timestamp = Time.time + timeDelay;
                kombo1 = true;                
            }
            if (Input.GetButtonDown(punch2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Punch2");
                timestamp = Time.time + timeDelay;
                kombo2 = true;
            }
            if (Input.GetButtonDown(kick1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Kick1");
                timestamp = Time.time + timeDelay;
                kombo3 = true;
            }
            if (Input.GetButtonDown(kick2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Kick2");
                timestamp = Time.time + timeDelay;                
            }
            if (Input.GetButton(blockButton))
            {
                anim.SetBool("Block", true);
                if (defending)
                {
                    speed = 0f;
                    jumpForce = 0f;
                    anim.ResetTrigger("Punch1");
                    anim.ResetTrigger("Punch2");
                    anim.ResetTrigger("Kick1");
                    anim.ResetTrigger("Kick2");
                    timestamp = Time.time + timeDelay / 2;
                }
            }
            else
            {
                anim.SetBool("Block", false);
                speed = 2f;
                jumpForce = 3f;
            }

            if (kombo1 == true)
            {
                if (Input.GetButtonDown(punch2Button))
                {
                    anim.SetTrigger("Kombo1");
                    komboCount += 1;
                    timestamp += 0.33f;
                    if (komboCount > 3)
                    {
                        kombo1 = false;
                        komboCount = 0;
                    }
                }
            }

            if (kombo2 == true)
            {
                if (Input.GetButtonDown(punch1Button))
                {
                    anim.SetTrigger("Kombo2");
                    timestamp = Time.time + timeDelay;
                    kombo2 = false;
                }
            }

            if (kombo3 == true)
            {
                if (Input.GetButtonDown(punch2Button))
                {
                    anim.SetTrigger("Kombo3");
                    timestamp = Time.time + timeDelay;
                    kombo3 = false;
                    feKombo = true;
                }
            }

            if(Input.GetButtonDown(punch1Button) && feKombo == true)
            {
                anim.SetTrigger("Kombo4");
                timestamp = Time.time + timeDelay;
                feKombo = false;
            }

            if (Input.GetButtonDown(ultimateButton) && ultimate == false && healthPercent <= 0.2)
            {
                anim.SetTrigger("Ultimate");
                ultimate = true;
                timestamp = Time.time + timeDelay;
            }
        }

        if (grounded == false)
        {
            if (Input.GetButtonDown(punch1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpPunch1");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(punch2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpPunch2");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(kick1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpKick1");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(kick2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpKick2");
                timestamp = Time.time + timeDelay;
            }
            anim.ResetTrigger("Punch1");
            anim.ResetTrigger("Punch2");
            anim.ResetTrigger("Kick1");
            anim.ResetTrigger("Kick2");
        }

        if (grounded == true)
        {
            anim.ResetTrigger("JumpPunch1");
            anim.ResetTrigger("JumpPunch2");
            anim.ResetTrigger("JumpKick1");
            anim.ResetTrigger("JumpKick2");
        }

        if (Time.time >= timestamp)
        {
            feKombo = false;
            anim.ResetTrigger("Kombo1");
            anim.ResetTrigger("Kombo2");
            anim.ResetTrigger("Kombo3");
            anim.ResetTrigger("Kombo4");
            anim.ResetTrigger("RunKick");
        }

        if (speed >= 4)
        {
            if (Input.GetButtonDown(kick1Button))
            {
                anim.SetTrigger("RunKick");
                speed = 0f;
            }
        }
    }

    void FT()
    {
        if ((Input.GetButton(horizontalButton) || Input.GetAxisRaw(horizontalButton) != 0) && Time.time >= timestamp)
            move = Input.GetAxis(horizontalButton);
        else
            move = 0;

        anim.SetFloat("Speed", Mathf.Abs(move));

        if (move != 0)
            rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);

        if (Input.GetAxisRaw(verticalButton) > 0 && Time.time >= timestamp)
            Jump();

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        if (Input.GetButtonDown(horizontalButton))
        {
            if (buttonCooler > 0 && buttonCount == 1)
                speed *= 2f;
            else
            {
                buttonCooler = 0.5f;
                buttonCount += 1;
            }
        }

        if (Input.GetAxisRaw(triggerButton) != 0)
        {
            if (tapDash == false)
            {
                speed *= 2f;
                tapDash = true;
            }
        }
        else if (Input.GetAxisRaw(triggerButton) == 0)
            tapDash = false;

        if (buttonCooler > 0)
            buttonCooler -= 1 * Time.deltaTime;
        else
            buttonCount = 0;

        if (move == 0)
        {
            if (Input.GetButtonDown(punch1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Punch1");
                timestamp = Time.time + timeDelay;
                kombo1 = true;
            }
            if (Input.GetButtonDown(punch2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Punch2");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(kick1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Kick1");
                timestamp = Time.time + timeDelay;
                kombo3 = true;
            }
            if (Input.GetButtonDown(kick2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Kick2");
                timestamp = Time.time + timeDelay;
                kombo2 = true;
            }
            if (Input.GetButton(blockButton))
            {
                anim.SetBool("Block", true);
                if (defending)
                {
                    speed = 0f;
                    jumpForce = 0f;
                    anim.ResetTrigger("Punch1");
                    anim.ResetTrigger("Punch2");
                    anim.ResetTrigger("Kick1");
                    anim.ResetTrigger("Kick2");
                    timestamp = Time.time + timeDelay / 2;
                }
            }
            else
            {
                anim.SetBool("Block", false);
                speed = 2f;
                jumpForce = 3f;
            }

            if (kombo1 == true)
            {
                if (Input.GetButtonDown(punch2Button))
                {
                    anim.SetTrigger("Kombo1");
                    kombo1 = false;
                    timestamp = Time.time + timeDelay * 1.5f;
                }
            }

            if (kombo2 == true)
            {
                if (Input.GetButtonDown(punch2Button))
                {
                    anim.SetTrigger("Kombo2");
                    kombo2 = false;
                    timestamp = Time.time + timeDelay * 1.5f;
                }
            }

            if (kombo3 == true)
            {
                if (Input.GetButtonDown(punch2Button))
                {
                    anim.SetTrigger("Kombo3");
                    kombo3 = false;
                    timestamp = Time.time + timeDelay * 2f;
                }
            }

            if (Input.GetButtonDown(ultimateButton) && ultimate == false && healthPercent <= 0.2)
            {
                anim.SetTrigger("Ult_Start");
                ultimate = true;
                timestamp = Time.time + timeDelay;
            }
        }

        if (grounded == false)
        {
            if (Input.GetButtonDown(punch1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpPunch1");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(punch2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpPunch2");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(kick1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpKick1");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(kick2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpKick2");
                timestamp = Time.time + timeDelay;
            }
            anim.ResetTrigger("Punch1");
            anim.ResetTrigger("Punch2");
            anim.ResetTrigger("Kick1");
            anim.ResetTrigger("Kick2");
        }

        if (grounded == true)
        {
            anim.ResetTrigger("JumpPunch1");
            anim.ResetTrigger("JumpPunch2");
            anim.ResetTrigger("JumpKick1");
            anim.ResetTrigger("JumpKick2");
        }

        if (Time.time >= timestamp)
        {
            anim.ResetTrigger("Kombo1");
            anim.ResetTrigger("Kombo2");
            anim.ResetTrigger("Kombo3");
            anim.ResetTrigger("RunKick");
        }

        if (speed >= 4)
        {
            if (Input.GetButtonDown(kick2Button))
            {
                anim.SetTrigger("RunKick");
                speed = 0f;
            }
        }
    }

    void FH()
    {
        if ((Input.GetButton(horizontalButton) || Input.GetAxisRaw(horizontalButton) != 0) && Time.time >= timestamp)
            move = Input.GetAxis(horizontalButton);
        else
            move = 0;

        anim.SetFloat("Speed", Mathf.Abs(move));

        if (move != 0)
            rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);

        if (Input.GetAxisRaw(verticalButton) > 0 && Time.time >= timestamp)
            Jump();

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        if (Input.GetButtonDown(horizontalButton))
        {
            if (buttonCooler > 0 && buttonCount == 1)
                speed *= 2f;
            else
            {
                buttonCooler = 0.5f;
                buttonCount += 1;
            }
        }

        if (Input.GetAxisRaw(triggerButton) != 0)
        {
            if (tapDash == false)
            {
                speed *= 2f;
                tapDash = true;
            }
        }
        else if (Input.GetAxisRaw(triggerButton) == 0)
            tapDash = false;

        if (buttonCooler > 0)
            buttonCooler -= 1 * Time.deltaTime;
        else
            buttonCount = 0;

        if (move == 0)
        {
            if (Input.GetButtonDown(punch1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Punch1");
                timestamp = Time.time + timeDelay;
                kombo2 = true;
            }
            if (Input.GetButtonDown(punch2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Punch2");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(kick1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Kick1");
                timestamp = Time.time + timeDelay;
                kombo1 = true;
            }
            if (Input.GetButtonDown(kick2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Kick2");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButton(blockButton))
            {
                anim.SetBool("Block", true);
                if (defending)
                {
                    speed = 0f;
                    jumpForce = 0f;
                    anim.ResetTrigger("Punch1");
                    anim.ResetTrigger("Punch2");
                    anim.ResetTrigger("Kick1");
                    anim.ResetTrigger("Kick2");
                    timestamp = Time.time + timeDelay / 2;
                }
            }
            else
            {
                anim.SetBool("Block", false);
                speed = 2f;
                jumpForce = 3f;
            }

            if (kombo1 == true)
            {
                if (Input.GetButtonDown(kick2Button))
                {
                    anim.SetTrigger("Kombo1");
                    kombo1 = false;
                    fhKombo1 = true;
                    timestamp = Time.time + timeDelay;
                }
            }

            if(fhKombo1==true && Input.GetButtonDown(kick1Button)) { 
                anim.SetTrigger("Kombo1_2");
                fhKombo1 = false;
                timestamp = Time.time + timeDelay * 1.5f;
            }

            if (kombo2 == true)
            {
                if (Input.GetButtonDown(punch2Button))
                {
                    anim.SetTrigger("Kombo2");
                    kombo2 = false;
                    fhKombo2 = true;
                    timestamp = Time.time + timeDelay;
                }
            }

            if(fhKombo2==true&& Input.GetButtonDown(punch1Button))
            {
                anim.SetTrigger("Kombo2_2");
                fhKombo2 = false;
                timestamp = Time.time + timeDelay;
            }

            if (Input.GetButtonDown(ultimateButton) && ultimate == false && healthPercent <= 0.2)
            {
                anim.SetTrigger("Ultimate");
                ultimate = true;
                timestamp = Time.time + timeDelay;
            }
        }

        if (grounded == false)
        {
            if (Input.GetButtonDown(punch1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpPunch1");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(punch2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpPunch2");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(kick1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpKick1");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(kick2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpKick2");
                timestamp = Time.time + timeDelay;
            }
            anim.ResetTrigger("Punch1");
            anim.ResetTrigger("Punch2");
            anim.ResetTrigger("Kick1");
            anim.ResetTrigger("Kick2");
        }

        if (grounded == true)
        {
            anim.ResetTrigger("JumpPunch1");
            anim.ResetTrigger("JumpPunch2");
            anim.ResetTrigger("JumpKick1");
            anim.ResetTrigger("JumpKick2");
        }

        if (Time.time >= timestamp)
        {
            fhKombo1 = false;
            fhKombo2 = false;
            anim.ResetTrigger("Kombo1");
            anim.ResetTrigger("Kombo2");
            anim.ResetTrigger("RunKick");
        }

        if (speed >= 4)
        {
            if (Input.GetButtonDown(kick2Button))
            {
                anim.SetTrigger("RunKick");
                speed = 0f;
            }
        }
    }

    void FSRD()
    {
        if ((Input.GetButton(horizontalButton) || Input.GetAxisRaw(horizontalButton) != 0) && Time.time >= timestamp)
            move = Input.GetAxis(horizontalButton);
        else
            move = 0;

        anim.SetFloat("Speed", Mathf.Abs(move));

        if (move != 0)
            rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);

        if (Input.GetAxisRaw(verticalButton) > 0 && ultimate == false && Time.time >= timestamp)
            Jump();

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        if (Input.GetButtonDown(horizontalButton))
        {
            if (buttonCooler > 0 && buttonCount == 1)
                speed *= 2f;
            else
            {
                buttonCooler = 0.5f;
                buttonCount += 1;
            }
        }

        if (Input.GetAxisRaw(triggerButton) != 0)
        {
            if (tapDash == false)
            {
                speed *= 2f;
                tapDash = true;
            }
        }
        else if (Input.GetAxisRaw(triggerButton) == 0)
            tapDash = false;

        if (buttonCooler > 0)
            buttonCooler -= 1 * Time.deltaTime;
        else
            buttonCount = 0;

        if (move == 0)
        {
            if (Input.GetButtonDown(punch1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Punch1");
                timestamp = Time.time + timeDelay;
                kombo2 = true;
            }
            if (Input.GetButtonDown(punch2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Punch2");
                timestamp = Time.time + timeDelay;
                kombo1 = true;
            }
            if (Input.GetButtonDown(kick1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Kick1");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(kick2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Kick2");
                timestamp = Time.time + timeDelay;
                kombo3 = true;
            }
            if (Input.GetButton(blockButton))
            {
                anim.SetBool("Block", true);
                if (defending)
                {
                    speed = 0f;
                    jumpForce = 0f;
                    anim.ResetTrigger("Punch1");
                    anim.ResetTrigger("Punch2");
                    anim.ResetTrigger("Kick1");
                    anim.ResetTrigger("Kick2");
                    timestamp = Time.time + timeDelay / 2;
                }
            }
            else
            {
                anim.SetBool("Block", false);
                speed = 2f;
                jumpForce = 3f;
            }

            if (kombo1 == true)
            {
                if (Input.GetButtonDown(punch1Button))
                {
                    anim.SetTrigger("Kombo1");
                    timestamp = Time.time + timeDelay;
                    kombo1 = false;
                    fsrdKombo1 = true;
                }
            }

            if (fsrdKombo1 == true && Input.GetButtonDown(punch2Button))
            {
                anim.SetTrigger("Kombo1_2");
                timestamp = Time.time + timeDelay;
                fsrdKombo1 = false;
            }

            if (kombo2 == true)
            {
                if (Input.GetButtonDown(punch2Button))
                {
                    anim.SetTrigger("Kombo2");
                    timestamp = Time.time + timeDelay;
                }
            }

            if (kombo3 == true)
            {
                if (Input.GetButtonDown(punch2Button))
                {
                    anim.SetTrigger("Kombo3");
                    timestamp = Time.time + timeDelay;
                    kombo3 = false;
                    fsrdKombo2 = true;
                }
            }

            if (fsrdKombo2 == true && Input.GetButtonDown(punch2Button))
            {
                anim.SetTrigger("Kombo3_2");
                timestamp = Time.time + timeDelay;
                fsrdKombo2 = false;
            }

            if (Input.GetButtonDown(ultimateButton) && ultimate == false && healthPercent <= 0.2)
            {
                anim.SetTrigger("Ultimate");
                ultimate = true;
                timestamp = Time.time + timeDelay * 2.5f;
            }
        }

        if (grounded == false)
        {
            if (Input.GetButtonDown(punch1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpPunch1");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(punch2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpPunch2");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(kick1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpKick1");
                timestamp = Time.time + timeDelay;
            }
            anim.ResetTrigger("Punch1");
            anim.ResetTrigger("Punch2");
            anim.ResetTrigger("Kick1");
            anim.ResetTrigger("Kick2");
        }

        if (grounded == true)
        {
            anim.ResetTrigger("JumpPunch1");
            anim.ResetTrigger("JumpPunch2");
            anim.ResetTrigger("JumpKick1");
        }

        if (Time.time >= timestamp)
        {
            anim.ResetTrigger("Kombo1");
            anim.ResetTrigger("Kombo1_2");
            anim.ResetTrigger("Kombo2");
            anim.ResetTrigger("Kombo3");
            anim.ResetTrigger("Kombo3_2");
            anim.ResetTrigger("RunPunch");
            fsrdKombo1 = false;
            fsrdKombo2 = false;
        }

        if (speed >= 4)
        {
            if (Input.GetButtonDown(punch1Button))
            {
                anim.SetTrigger("RunPunch");
                speed = 0f;
            }
        }
    }

    void FTI()
    {
        if ((Input.GetButton(horizontalButton) || Input.GetAxisRaw(horizontalButton) != 0) && Time.time >= timestamp)
            move = Input.GetAxis(horizontalButton);
        else
            move = 0;

        anim.SetFloat("Speed", Mathf.Abs(move));

        if (move != 0)
            rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);

        if (Input.GetAxisRaw(verticalButton) > 0 && Time.time >= timestamp)
            Jump();

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        if (Input.GetButtonDown(horizontalButton))
        {
            if (buttonCooler > 0 && buttonCount == 1)
                speed *= 2f;
            else
            {
                buttonCooler = 0.5f;
                buttonCount += 1;
            }
        }

        if (Input.GetAxisRaw(triggerButton) != 0)
        {
            if (tapDash == false)
            {
                speed *= 2f;
                tapDash = true;
            }
        }
        else if (Input.GetAxisRaw(triggerButton) == 0)
            tapDash = false;

        if (buttonCooler > 0)
            buttonCooler -= 1 * Time.deltaTime;
        else
            buttonCount = 0;

        if (move == 0)
        {
            if (Input.GetButtonUp(punch1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Punch1");
                timestamp = Time.time + timeDelay;
                kombo1 = true;
            }
            if (Input.GetButtonUp(punch2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Punch2");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(kick1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Kick1");
                timestamp = Time.time + timeDelay;
                kombo2 = true;
            }
            if (Input.GetButtonDown(kick2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("Kick2");
                timestamp = Time.time + timeDelay;
            }
            if (((Input.GetButtonDown(punch1Button) && Input.GetButton(punch2Button)) || (Input.GetButton(punch1Button) && Input.GetButtonDown(punch2Button))) && Time.time >= timestamp)
            {
                anim.SetTrigger("Kombo1");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButton(blockButton))
            {
                anim.SetBool("Block", true);
                if (defending)
                {
                    speed = 0f;
                    jumpForce = 0f;
                    anim.ResetTrigger("Punch1");
                    anim.ResetTrigger("Punch2");
                    anim.ResetTrigger("Kick1");
                    anim.ResetTrigger("Kick2");
                    timestamp = Time.time + timeDelay / 2;
                }
            }
            else
            {
                anim.SetBool("Block", false);
                speed = 2f;
                jumpForce = 3f;
            }

            if (kombo1 == true)
            {
                if (Input.GetButtonDown(kick2Button))
                {
                    anim.SetTrigger("Kombo2");
                    ftiKombo1 = true;
                    timestamp = Time.time + timeDelay;
                }
            }

            if(ftiKombo1==true&& Input.GetButtonDown(punch1Button))
            {
                anim.SetTrigger("Kombo2_2");
                ftiKombo1 = false;
                timestamp = Time.time + timeDelay;
            }

            if (kombo2 == true)
            {
                if(Input.GetButtonUp(punch1Button) && Input.GetButtonUp(punch1Button))
                {
                    anim.SetTrigger("Kombo3");
                    ftiKombo2 = true;
                    timestamp = Time.time + timeDelay;
                }
            }

            if(ftiKombo2==true && Input.GetButtonDown(punch1Button) && Input.GetButtonDown(punch1Button))
            {
                anim.SetTrigger("Kombo3_2");
                ftiKombo2 = false;
                timestamp = Time.time + timeDelay;
            }

            if (Input.GetButtonDown(ultimateButton) && ultimate == false && healthPercent <= 0.2)
            {
                anim.SetTrigger("Ult_Start");
                ultimate = true;
                timestamp = Time.time + timeDelay;
            }
        }

        if (grounded == false)
        {
            if (Input.GetButtonDown(punch1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpPunch1");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(punch2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpPunch2");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(kick1Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpKick1");
                timestamp = Time.time + timeDelay;
            }
            if (Input.GetButtonDown(kick2Button) && Time.time >= timestamp)
            {
                anim.SetTrigger("JumpKick2");
                timestamp = Time.time + timeDelay;
            }
            anim.ResetTrigger("Punch1");
            anim.ResetTrigger("Punch2");
            anim.ResetTrigger("Kick1");
            anim.ResetTrigger("Kick2");
            anim.ResetTrigger("Kombo1");
        }

        if (grounded == true)
        {
            anim.ResetTrigger("JumpPunch1");
            anim.ResetTrigger("JumpPunch2");
            anim.ResetTrigger("JumpKick1");
            anim.ResetTrigger("JumpKick2");
        }

        if (Time.time >= timestamp)
        {
            ftiKombo1 = false;
            ftiKombo2 = false;
            anim.ResetTrigger("Kombo1");
            anim.ResetTrigger("Kombo2");
            anim.ResetTrigger("Kombo2_2");
            anim.ResetTrigger("Kombo3");
            anim.ResetTrigger("Kombo3_2");
            anim.ResetTrigger("RunKick");
            anim.ResetTrigger("RunPunch");
        }

        if (speed >= 4)
        {
            if (Input.GetButtonDown(kick2Button))
            {
                anim.SetTrigger("RunKick");
                speed = 0f;
            }

            if (Input.GetButtonDown(punch1Button))
            {
                anim.SetTrigger("RunPunch");
                speed = 0f;
            }
        }
    }

    //FIKom exclusive
    void Immune()
    {
        immune = !immune;
    }

    //FPsi exclusive
    void Bullet1()
    {
        if (facingRight)
            Instantiate(bullet1, new Vector2(gameObject.transform.position.x + 0.7f, gameObject.transform.position.y + 0.1f), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(bullet1, new Vector2(gameObject.transform.position.x - 0.7f, gameObject.transform.position.y + 0.1f), Quaternion.Euler(0, 180, 0));
    }

    void Bullet2()
    {
        if (facingRight)
            Instantiate(bullet2, new Vector2(gameObject.transform.position.x + 0.8f, gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(bullet2, new Vector2(gameObject.transform.position.x - 0.8f, gameObject.transform.position.y), Quaternion.Euler(0, 180, 0));
    }

    void Dash()
    {
        if (facingRight)
            rb2d.AddForce(new Vector2(1500, 0));
        if (!facingRight)
            rb2d.AddForce(new Vector2(-1500, 0));
    }

    void FistOfFury()
    {
        if (facingRight)
            Instantiate(fist, new Vector2(gameObject.transform.position.x + 0.483f, gameObject.transform.position.y - 0.072f), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(fist, new Vector2(gameObject.transform.position.x - 0.483f, gameObject.transform.position.y - 0.072f), Quaternion.Euler(0, 180, 0));
    }

    void Ball()
    {
        if (facingRight)
            projectileChild = Instantiate(ball, new Vector2(gameObject.transform.position.x + 0.9f, gameObject.transform.position.y + 0.1f), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            projectileChild = Instantiate(ball, new Vector2(gameObject.transform.position.x - 0.9f, gameObject.transform.position.y + 0.1f), Quaternion.Euler(0, 180, 0));
        projectileChild.transform.parent = gameObject.transform;
    }

    void UltBeam1()
    {
        if (facingRight)
            Instantiate(ultBeam1, new Vector2(gameObject.transform.position.x + 0.9f, gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(ultBeam1, new Vector2(gameObject.transform.position.x - 0.9f, gameObject.transform.position.y), Quaternion.Euler(0, 180, 0));
    }

    void UltBeam2()
    {
        if (facingRight)
            Instantiate(ultBeam2, new Vector2(gameObject.transform.position.x + 1f, gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(ultBeam2, new Vector2(gameObject.transform.position.x - 1f, gameObject.transform.position.y), Quaternion.Euler(0, 180, 0));
    }

    void UltBeam3()
    {
        if (facingRight)
            Instantiate(ultBeam3, new Vector2(gameObject.transform.position.x + 1f, gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(ultBeam3, new Vector2(gameObject.transform.position.x - 1f, gameObject.transform.position.y), Quaternion.Euler(0, 180, 0));
    }

    //FK exclusive
    void Syringe()
    {
        if (facingRight)
            Instantiate(syringe, new Vector2(gameObject.transform.position.x + 1.2f, gameObject.transform.position.y - 0.3f), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(syringe, new Vector2(gameObject.transform.position.x - 1.2f, gameObject.transform.position.y - 0.3f), Quaternion.Euler(0, 180, 0));
    }

    void Regen()
    {
        anim.SetBool("Monster", true);
        health = health + ((maxHealth - health) - 3 * health) - 100;
        source.clip = regenEffect;
        source.Play();
    }

    //FE exclusive
    void CC()
    {
        if (facingRight)
            Instantiate(cc, new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y - 0.3f), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(cc, new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y - 0.3f), Quaternion.Euler(0, 180, 0));
    }

    void Coin()
    {
        if (facingRight)
            Instantiate(coin, new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y - 0.3f), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(coin, new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y - 0.3f), Quaternion.Euler(0, 180, 0));
    }

    //FT exclusive
    void Evade()
    {
        rb2d.AddForce(new Vector2(0, 200));
    }

    void Ruler()
    {
        if (facingRight)
            Instantiate(ruler, new Vector2(gameObject.transform.position.x + 0.9f, gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(ruler, new Vector2(gameObject.transform.position.x - 0.9f, gameObject.transform.position.y), Quaternion.Euler(0, 180, 0));
    }

    //FH exclusive
    void Counter()
    {
        counterChance = Random.Range(1, 5);
        if (counterChance == 1)
        {
            anim.SetTrigger("Counter");
            timestamp = Time.time + timeDelay / 2;
            counterChance = 0;
        }
    }

    void PainSplit()
    {
        health += opponent.health / 2;
        opponent.health -= opponent.health / 2;
        source.clip = splitEffect;
        source.Play();
    }

    //FSRD exclusive
    void Ink()
    {
        if (facingRight)
            Instantiate(ink, new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y - 0.628f), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(ink, new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y - 0.628f), Quaternion.Euler(0, 180, 0));
    }

    void Dragon()
    {
        if (facingRight)
            Instantiate(dragon, new Vector2(gameObject.transform.position.x - 0.6f, gameObject.transform.position.y - 0.24f), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(dragon, new Vector2(gameObject.transform.position.x + 0.6f, gameObject.transform.position.y - 0.24f), Quaternion.Euler(0, 180, 0));
    }

    //FTI exclusive
    void Lazer()
    {
        if (facingRight)
            projectileChild = Instantiate(laser, new Vector2(gameObject.transform.position.x + 0.689f, gameObject.transform.position.y - 0.07f), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            projectileChild = Instantiate(laser, new Vector2(gameObject.transform.position.x - 0.689f, gameObject.transform.position.y - 0.07f), Quaternion.Euler(0, 180, 0));
        projectileChild.transform.parent = gameObject.transform;
    }

    void Cameo1()
    {
        if (facingRight)
            Instantiate(cameo[0], new Vector2(gameObject.transform.position.x + 1.3f, gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(cameo[0], new Vector2(gameObject.transform.position.x - 1.3f, gameObject.transform.position.y), Quaternion.Euler(0, 180, 0));
    }

    void Cameo2()
    {
        if (facingRight)
            Instantiate(cameo[1], new Vector2(gameObject.transform.position.x + 1.3f, gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(cameo[1], new Vector2(gameObject.transform.position.x - 1.3f, gameObject.transform.position.y), Quaternion.Euler(0, 180, 0));
    }

    void Cameo3()
    {
        if (facingRight)
            Instantiate(cameo[2], new Vector2(gameObject.transform.position.x + 1.3f, gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(cameo[2], new Vector2(gameObject.transform.position.x - 1.3f, gameObject.transform.position.y), Quaternion.Euler(0, 180, 0));
    }

    void Cameo4()
    {
        if (facingRight)
            Instantiate(cameo[3], new Vector2(gameObject.transform.position.x + 1.3f, gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(cameo[3], new Vector2(gameObject.transform.position.x - 1.3f, gameObject.transform.position.y), Quaternion.Euler(0, 180, 0));
    }

    void Cameo5()
    {
        if (facingRight)
            Instantiate(cameo[4], new Vector2(gameObject.transform.position.x + 1.3f, gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(cameo[4], new Vector2(gameObject.transform.position.x - 1.3f, gameObject.transform.position.y), Quaternion.Euler(0, 180, 0));
    }

    void Cameo6()
    {
        if (facingRight)
            Instantiate(cameo[5], new Vector2(gameObject.transform.position.x + 1.3f, gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(cameo[5], new Vector2(gameObject.transform.position.x - 1.3f, gameObject.transform.position.y), Quaternion.Euler(0, 180, 0));
    }

    void Cameo7()
    {
        if (facingRight)
            Instantiate(cameo[6], new Vector2(gameObject.transform.position.x + 1.3f, gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(cameo[6], new Vector2(gameObject.transform.position.x - 1.3f, gameObject.transform.position.y), Quaternion.Euler(0, 180, 0));
    }

    void Cameo8()
    {
        if (facingRight)
            Instantiate(cameo[7], new Vector2(gameObject.transform.position.x + 1.3f, gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
        else if (!facingRight)
            Instantiate(cameo[7], new Vector2(gameObject.transform.position.x - 1.3f, gameObject.transform.position.y), Quaternion.Euler(0, 180, 0));
    }

    public void Ultimate(Ultimate ult)
    {
        anim.SetTrigger("Ultimate");
        if (gameObject.tag == "FT")
        {
            if (facingRight)
                Instantiate(gokart, new Vector2(gameObject.transform.position.x - 8f, gameObject.transform.position.y - 0.55f), Quaternion.Euler(0, 0, 0));
            else if (!facingRight)
                Instantiate(gokart, new Vector2(gameObject.transform.position.x + 8f, gameObject.transform.position.y - 0.55f), Quaternion.Euler(0, 180, 0));
        }
        timestamp = Time.time + timeDelay * 5;
    }

    public void UltimateSound()
    {
        source.clip = ultimateEffect;
        source.Play();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (immune == false)
        {
            source.clip = hitEffect;
            if (col.gameObject.tag == "Deadly")
            {
                if (health >= damage)
                {
                    if (defending)
                        health -= damage * 0.5f;
                    else
                    {
                        health -= damage;
                        timestamp = Time.time + timeDelay / 2;
                        anim.SetTrigger("Hit");
                    }
                }
                else
                    health = 0;

                if (col.gameObject.name == "Syringe(Clone)")
                    poison = true;

                if (col.gameObject.name == "Slowbox")
                    slow = true;

                if (col.gameObject.name == "Pullbox")
                {
                    if(col.gameObject.transform.position.x < gameObject.transform.position.x)
                        gameObject.transform.position = new Vector2(col.gameObject.transform.position.x - 1.3f, col.gameObject.transform.position.y);
                    else
                        gameObject.transform.position = new Vector2(col.gameObject.transform.position.x + 1.3f, col.gameObject.transform.position.y);
                }

                if (gameObject.tag == "FH")
                {
                    Counter();
                }
            }
            else if (col.gameObject.tag == "Kombo")
            {
                if (health >= damage)
                {
                    if (defending)
                        health -= damage * 1.3f * 0.5f;
                    else
                    {
                        health -= damage * 1.3f;
                        timestamp = Time.time + timeDelay / 2;
                        anim.SetTrigger("Hit");
                    }
                }
                else
                    health = 0;

                if (gameObject.tag == "FH")
                {
                    Counter();
                }
            }
            else if (col.gameObject.tag == "Spam")
            {
                if (health >= damage)
                {
                    if (defending)
                        health -= damage * 0.7f * 0.5f;
                    else
                    {
                        health -= damage * 0.7f;
                        timestamp = Time.time + timeDelay / 2;
                        anim.SetTrigger("Hit");
                    }
                }
                else
                    health = 0;

                if (gameObject.tag == "FH")
                {
                    Counter();
                }
            }
            else if (col.gameObject.tag == "Ranged")
            {
                if (health >= damage)
                {
                    if (defending)
                        health -= damage * 0.9f * 0.5f;
                    else
                    {
                        health -= damage * 0.9f;
                        timestamp = Time.time + timeDelay / 2;
                        anim.SetTrigger("Hit");
                    } 
                }
                else
                    health = 0;

                if (gameObject.tag == "FH")
                {
                    Counter();
                }
            }
            else if (col.gameObject.tag == "Kombo")
            {
                if (health >= damage)
                {
                    if (defending)
                        health -= damage * 1.3f * 0.5f;
                    else
                    {
                        health -= damage * 1.3f;
                        timestamp = Time.time + timeDelay / 2;
                        anim.SetTrigger("Hit");
                    }
                }
                else
                    health = 0;

                if (gameObject.tag == "FH")
                {
                    Counter();
                }
            }
            else if (col.gameObject.tag == "Electric")
            {
                if (health >= damage)
                {
                    if (defending)
                        health -= damage * 0.3f * 0.5f;
                    else
                    {
                        health -= damage * 0.3f;
                        timestamp = Time.time + timeDelay / 2;
                        anim.SetTrigger("Hit");
                    }
                }
                else
                    health = 0;

                if (gameObject.tag == "FH")
                {
                    Counter();
                }
            }
            else if (col.gameObject.tag == "Impact")
            {
                if (health >= damage)
                {
                    if (defending)
                        health -= damage * 4f * 0.5f;
                    else
                    {
                        health -= damage * 4f;
                        timestamp = Time.time + timeDelay / 2;
                        anim.SetTrigger("Hit");
                    }
                }
                else
                    health = 0;
            }
            else if (col.gameObject.tag == "Knockback")
            {
                if (health >= damage)
                {
                    if (defending)
                        health -= damage * 1.5f * 0.5f;
                    else
                    {
                        health -= damage * 1.5f;
                        timestamp = Time.time + timeDelay / 2;
                        if (monster == false)
                        {
                            anim.SetTrigger("Knockback");
                            if (col.transform.position.x < transform.position.x)
                                rb2d.AddForce(new Vector2(100, 70));
                            if (col.transform.position.x > transform.position.x)
                                rb2d.AddForce(new Vector2(-100, 70));
                        }
                    }
                }
                else
                    health = 0;
            }
            if (health > 0)
                source.Play();
        }        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (immune == false)
        {
            source.clip = hitEffect;
            if (col.gameObject.tag == "Deadly")
            {
                if (health >= damage)
                {
                    if (defending)
                        health -= damage * 0.5f;
                    else
                    {
                        health -= damage;
                        timestamp = Time.time + timeDelay / 2;
                        anim.SetTrigger("Hit");
                    }
                        
                }
                else
                    health = 0;

                if (health > 0)
                    source.Play();
            }
        }        
    }
}

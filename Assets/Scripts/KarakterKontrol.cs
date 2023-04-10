using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    [Header("MEVEMENT")]
    public float speed;
    public float playerRunSpeed;
    public bool runActive;
    private Animator _animator;
    
    [Header("STAMINA")]
    [SerializeField]private float health;
    public float stamina;
    public float maxStamina = 100;


    [Header("KEYCODES")]
    public KeyCode jumpkey = KeyCode.Space;
    public KeyCode Dooblejumpkey = KeyCode.Space;
    public KeyCode RunKey = KeyCode.LeftShift;
    public KeyCode EtkilesimTusu = KeyCode.E;


    
    [Header("JUMP")]
    public float jumpForce;
    public float jumpCooldown;
    public bool jumpReady;
    public bool groundedPlayer;
    public bool DoobleJumpReady;

    [Header("Etkilesim")]
    public bool etkilesimegecildi;
    public GameObject karakterCanvas;

    
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();
    Rigidbody _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        karakterCanvas.gameObject.SetActive(true);
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void Update() 
    {
        SpeedControl();
        groundedPlayer = GetComponentInChildren<GroundedChechk>().Grounded;
        health = gameObject.GetComponent<KarakterHealth>().PlayerHealth;

        if(stamina >= maxStamina)
        {
            stamina = maxStamina;
        }
        if (stamina <= 0)
            stamina = 0;
    }


    void MovePlayer() 
    {
        float targetMovingSpeed = speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        Vector3 targetVelocity =new Vector3( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);
        _rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, _rigidbody.velocity.y, targetVelocity.y);
        

        
        if(Input.GetKey(RunKey) && stamina >= 1)
        {
            speed = playerRunSpeed;
            stamina --;
        }else
        {
            speed = 4;
        }

        // ZIPLAMA metodu
        if(Input.GetKey(jumpkey) && jumpReady && groundedPlayer)
        {
            jumpReady = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
        if(Input.GetKeyDown(Dooblejumpkey) && DoobleJumpReady && groundedPlayer == false || (Input.GetKeyDown(Dooblejumpkey) && Input.GetKey(RunKey) && DoobleJumpReady && groundedPlayer == false ))
        {
            DoobleJump();
        }
    }

    
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
        if(flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            _rigidbody.velocity = new Vector3(limitedVel.x, _rigidbody.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f , _rigidbody.velocity.z);

        _rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        DoobleJumpReady = true;
    }
    
    private void DoobleJump()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f , _rigidbody.velocity.z);

        _rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        DoobleJumpReady = false;
    }


    private void ResetJump()
    {
        jumpReady = true;
    }


    private void OnTriggerStay(Collider other) {
        if(other.tag == "Elma" && Input.GetKey(EtkilesimTusu))
        {
            etkilesimegecildi = true;
            etkilesimeGec();
            Destroy(other.gameObject);
        }
    }

    void etkilesimeGec()
    {
        if (etkilesimegecildi)
        {
            Debug.Log("Elma yedin! (Stamina fullendi!)");
            stamina += 50;
            etkilesimegecildi = false;
        }
    }

}
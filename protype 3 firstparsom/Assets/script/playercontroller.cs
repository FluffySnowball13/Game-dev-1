using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce;
    [Header("Camera")]
    public float lookSensitivity;   // Mouse look sensitivity
    public float maxLookX; //lowest down position we can look
    public float minLookX;  //Highest up we can look
    private float rotX; //Current X rotation of the camera
    [Header("GameObjects & Components")]// GameObjects & Components
    private Camera cam;
    private Rigidbody rb;
    private Weapon weapon;
    [Header("stats")]
    public int curHP;
    public int maxHP;

    void Awake()
    {
        //Get the components
        cam = Camera.main; 
        rb = GetComponent<Rigidbody>();
        weapon = GetComponent<Weapon>();
        // Disable Cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        //initialize the UI
        GameUi.instance.UpdateHealthBar(curHP, maxHP);
        GameUi.instance.UpdateScoreText(0);
        GameUi.instance.UpdateAmmoText(weapon.curAmmo,weapon.maxAmmo);
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        if(curHP <= 0)
            Die();
        GameUi.instance.UpdateHealthBar(curHP, maxHP);
    }
    void Die()
    {
        GameManager.instance.LoseGame();
    }

   
     // Update is called once per frame
    void Update()
    {

        //Don't do anything pause
        if(GameManager.instance.gamePaused == true)
            return;
        Move();
        CamLook();
        // Jump when spacebar is pressed
        if(Input.GetButtonDown("Jump"))
        Jump();

        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
            {
                weapon.Shoot();
            }
        }
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //Face the direction of the camera
        Vector3 dir = transform.right * x + transform.forward * z;
        // Jump direction
        dir.y = rb.velocity.y;
        // Move in the direction of the camera
        rb.velocity = dir;

    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;
        //Clamps the camera up and down rotation
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX); 
        // Apply Rotation to Camera
        cam.transform.localRotation = Quaternion.Euler(-rotX,0,0);
        transform.eulerAngles += Vector3.up * y; 
    }


       public void GiveHealth (int amountToGive)
    {
        curHP = Mathf.Clamp(curHP + amountToGive, 0, maxHP);
        GameUi.instance.UpdateHealthBar(curHP, maxHP);
    }

    public void GiveAmmo (int amountToGive)
    {
        weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        GameUi.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
    }
}


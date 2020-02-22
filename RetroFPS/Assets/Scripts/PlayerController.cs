using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movespeed = 5f;
    public static PlayerController instance;
    private Vector2 moveInput;
    private Vector2 mouseInput;
    public float mousesensitivity = 4f;

    public Camera viewcam;


    public int currentHealth;
    public int maxHealth =100;

    
    public bool HasDied;

    public GameObject bulletimpact;
    public int currentAmmo;

    public Animator gunAnim;
    public Animator PlayerAnim;
    public Text HealthText, ammoText;

    public AudioClip shootfx;
    public AudioClip takedamagefx;

    private void Awake()
    {
        instance = this;

    }

    void Start()
    {
        currentHealth = maxHealth;
        HealthText.text = currentHealth.ToString() + "%";

        ammoText.text = currentAmmo.ToString();
    }

    void Update()
    {
        if(!HasDied)
        {
            //player movement 
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            Vector3 moveHorizontal = transform.up * -moveInput.x;

            Vector3 moveVertical = transform.right * moveInput.y;


            rb.velocity = (moveHorizontal + moveVertical) * movespeed;

            // player  mouse view control 

            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mousesensitivity;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x); // X-axis 

            viewcam.transform.localRotation = Quaternion.Euler(viewcam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));


            // player shooting using ray casting

            if (Input.GetMouseButtonDown(0))
            {
                
                if (currentAmmo > 0)
                {
                    Ray ray = viewcam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))//if player hits something
                    {
                        //Debug.Log("looking at " + hit.transform.name);
                        Instantiate(bulletimpact, hit.point, transform.rotation);
                        if (hit.transform.tag == "Enemy")
                        {
                            hit.transform.parent.GetComponent<EnemyController>().TakeDamage(); // calling the EC to take damage when raycast hits enemy
                        }
                    }
                    else
                    {
                        Debug.Log("looking at nothing");
                    }
                    currentAmmo--;
                    gunAnim.SetTrigger("Shoot");
                    UpdateAmmoUI();
                    AudioManager.Instance.PlaySFX(shootfx, 3.0f);
                }

            }

            if(moveInput != Vector2.zero)
            {
                PlayerAnim.SetBool("isMoving", true);
            }
            else
            {
                PlayerAnim.SetBool("isMoving", false);
            }
        }
        

    }



    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        AudioManager.Instance.PlaySFX(takedamagefx, 3.0f);
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
            LockCursor();
            HasDied = true;
            currentHealth = 0;
        }
        HealthText.text = currentHealth.ToString() + "%";
    }

    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        HealthText.text = currentHealth.ToString() + "%";
    }


    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UpdateAmmoUI()
    {
        ammoText.text = currentAmmo.ToString();
    }
}

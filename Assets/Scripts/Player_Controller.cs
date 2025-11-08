using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class Player_Controller : MonoBehaviour
{
    private Vector3 direction;
    private Vector2 rotation;
    private Vector2 camerarotation;
    private Vector2 MouseInput;
    public GameObject Camera;
    public Interact_Volume Volume;
    private float x_rotation;
    public GameObject AmmoFeedback;
    public Rigidbody Projectile;
    public float speed = 4;
    float verticalRotation;
    public Vector3 jump = new Vector3(0.0f, 2.0f, 0.0f);
	public float jumpForce = 2.0f;
	public bool isGrounded;    public static Player_Controller Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Cursor.lockState = CursorLockMode.Locked;
        EnhancedTouchSupport.Enable();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(direction * 5 * Time.deltaTime);
        transform.Rotate(rotation * 20 * Time.deltaTime);
    
        verticalRotation = Mathf.Clamp(verticalRotation - camerarotation.x, -90f, 90f);
        Camera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        if (Data.Instance.Ammo > 0)
        {
            AmmoFeedback.SetActive(true);
        }
        else
        {
            AmmoFeedback.SetActive(false);
        }
        if (Data.Instance.Hp <= 0)
        {
            Application.Quit();
            Destroy(gameObject);
            
        }
        if (transform.position.y < -15)
        {
            Application.Quit();
            Destroy(gameObject);
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 ZQSD = value.Get<Vector2>();
        direction.x = ZQSD.x;
        direction.z = ZQSD.y;
    }

    void OnLook(InputValue value)
    {
        MouseInput = value.Get<Vector2>();
        camerarotation.x = MouseInput.y;
        rotation.y = MouseInput.x;
    }
    void OnInteract()
    {
        if (Volume.InteractBuffer != null)
        {
            Volume.InteractBuffer.SendMessage("PickUp");
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX_Pickup");
        }
    }
    void OnThrow()
    {
        if (Data.Instance.Ammo > 0)
        {
            Vector3 Offset = new Vector3(0, 0.5f, 0) + Camera.transform.forward;
            Vector3 ThrowOrigin = transform.position + Offset;
            Quaternion ThrowOrientation = Quaternion.LookRotation(new Vector3(Random.Range(0, 45), Random.Range(0, 45), Random.Range(0, 45)));
            Rigidbody p = Instantiate(Projectile, ThrowOrigin, ThrowOrientation);
            p.linearVelocity = Camera.transform.forward * speed;
            Data.Instance.Ammo += -1;
        }
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    void OnJump()
    {
        GetComponent<Rigidbody>().AddForce(jump * jumpForce, ForceMode.Impulse);
    	isGrounded = false;
    }
}
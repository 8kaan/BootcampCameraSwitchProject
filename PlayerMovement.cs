using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;


    public float rotationSpeed = 1000f; // D�nd�rme h�z�
    public float verticalRotationLimit = 80f; // Yukar� ve a�a�� bakma s�n�r�

    private float horizontalInput;
    private float verticalInput;
    private float verticalRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Yere temas kontrol�
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Hareket y�n�
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        // Z�plama
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -0.8f * gravity);
        }

        // Yer�ekimi uygulama
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Sa� ve sol y�n tu�lar� veya fare hareketi ile input al
        horizontalInput = Input.GetAxis("Mouse X");
        verticalInput = Input.GetAxis("Mouse Y");

        // Yatay d�n�� (sa�a-sola bakma)
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);

        // Dikey d�n�� (yukar�-a�a�� bakma)
        verticalRotation -= verticalInput * rotationSpeed * Time.deltaTime;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);

        // Local olarak X ekseninde dikey d�n�� uygulay�n (sadece kafa i�in)
        transform.localEulerAngles = new Vector3(verticalRotation, transform.localEulerAngles.y, 0);
    }
}

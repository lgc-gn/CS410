using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    // Three new variables to help in implementing single/double jump
    // grounded: Need to check if the ball is on the ground to be able to jump
    // doubleJump: Another bool to check if the player already double jumped in the air
    // jumpHeight: Control the height the player can jump
    private bool grounded;
    private bool doubleJump;
    public float jumpHeight = .5f;

    // playerInput variable to be declared in Start()
    private PlayerInput playerInput;
    private InputAction jumpAction;

    // Storing the color of the score text for later

    private Color originalColor;


    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    private int numPickups;

    // Decided to use FindGameObjectsWithTag function to avoid a hardcoded pickup count
    // https://discussions.unity.com/t/count-tags/373463
    // Probably not required but makes it easier if I wanted to add more pickups

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        count = 0;

        winTextObject.SetActive(false);

        numPickups = GameObject.FindGameObjectsWithTag("Pickup").Length;

        //print(numPickups);

        playerInput = GetComponent<PlayerInput>();
        jumpAction = playerInput.actions["Jump"];
        jumpAction.performed += ctx => Jump();

        originalColor = countText.color;

    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }


    void Jump()
    {
        // Regular Jump
        if (grounded)
        {
            print("Jumped");

            // Needed to use Forcemode.Impulse to get the jump working, for some reason without it there would be no movement.

            // Had a weird bug in that jumpHeight did not affect the height of the jump at all if I used ForceMode.Impulse
            // Instead had to multiply it here, probably some other way to fix it.
            rb.AddForce(Vector3.up * (jumpHeight * .75f), ForceMode.Impulse);
            doubleJump = true;
        }

        // Double jump
        else if (grounded == false & doubleJump == true)
        {
            doubleJump = false;

            // Reset the y velocity of the player, otherwise gravity on the player kills the momentum of the double jump
            Vector3 nullVelocity = rb.linearVelocity;
            nullVelocity.y = 0;
            rb.linearVelocity = nullVelocity;

            rb.AddForce(Vector3.up * (jumpHeight * .6f), ForceMode.Impulse);
            print("Double jumped");
        }


    }

    // Need to check if the player object is grounded, using a Raycast to see if ground is beneath the player
    void CheckIfGrounded()
    {
        float rayLength = 1.125f;
        grounded = Physics.Raycast(transform.position, Vector3.down, rayLength);
    }


    #region UI Methods

    // Coroutine method to help the score count flash green when a pickup is collected
    // Kind of just wanted to mess with coroutines.

    IEnumerator FlashScoreColor()
    {
        countText.color = Color.green; 
        yield return new WaitForSeconds(0.2f); 
        countText.color = originalColor; 
    }


    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        StartCoroutine(FlashScoreColor());

        if (count >= numPickups)
        {
            winTextObject.SetActive(true);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

    #endregion

    #region Update Method

    private void FixedUpdate()
    {

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        CheckIfGrounded();

        rb.AddForce(movement * speed);
    }

    #endregion

}

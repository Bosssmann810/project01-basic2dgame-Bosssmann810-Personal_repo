using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerinputs : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    public Vector2 inputMovement;
    public Vector2 oldMovement;
    public float speed;
    public GameObject normal;
    public GameObject upsideDown;
    public Servicehub servicehub;

    [SerializeField] private Animator playerAnimController;

    private int MoveInputXHash = Animator.StringToHash("MoveInputX");
    private int MoveInputYHash = Animator.StringToHash("MoveInputY");
    private int IsMovingHash = Animator.StringToHash("IsMoving");
    private int OldXHash = Animator.StringToHash("OldInputX");
    private int OldYHash = Animator.StringToHash("OldInputY");

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        upsideDown.SetActive(false);
        normal.SetActive(true);
        playerAnimController = GetComponentInChildren<Animator>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + inputMovement * speed * Time.fixedDeltaTime);

    }
    public void Update()
    {
        HandleAnimation();
    }
    public void OnFlip(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            normal.SetActive(false);
            upsideDown.SetActive(true);

        }
        if (context.canceled)
        {
            normal.SetActive(true);
            upsideDown.SetActive(false);
        }
    }
    public void OnPause()
    {
        Debug.Log("pressed escape");
        servicehub.gameStateManager.TogglePause();

    }
    public void HandleAnimation()
    {
        if (inputMovement != Vector2.zero )
        {
            playerAnimController.SetBool(IsMovingHash, true);
            playerAnimController.SetFloat(MoveInputXHash, inputMovement.x);
            playerAnimController.SetFloat(MoveInputYHash, inputMovement.y);
            oldMovement = inputMovement;
        }
        else if (inputMovement == Vector2.zero )
        {
            playerAnimController.SetBool(IsMovingHash, false);
            playerAnimController.SetFloat(OldYHash, oldMovement.y);
            playerAnimController.SetFloat(OldXHash, oldMovement.x);
        }
    } 
}


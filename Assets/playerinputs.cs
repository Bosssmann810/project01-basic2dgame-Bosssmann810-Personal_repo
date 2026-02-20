using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerinputs : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    public Vector2 inputMovement;
    public float speed;
    public GameObject normal;
    public GameObject upsideDown;
    public Servicehub servicehub;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        upsideDown.SetActive(false);
        normal.SetActive(true);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + inputMovement * speed * Time.fixedDeltaTime);
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
}


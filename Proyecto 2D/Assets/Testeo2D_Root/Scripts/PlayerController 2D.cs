using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Libreria para que funcione el New Input Sistem

public class PlayerController2D : MonoBehaviour
{
     

     


    //Referencias generales
    [SerializeField]Rigidbody2D playerRb; //Ref al rigibody del player
    [SerializeField] PlayerInput playerInput; // Ref al gestor del input del jugador




    [Header("Movement Parametres")]
    private Vector2 moveInput; //Almac�n del input del player
    public float speed;

    [Header("Jump Parametres")]
    public float jumpForce;
    [SerializeField] bool isGraunded;



    // Start is called before the first frame update
    void Start()
    {
        //Autoreferenciar componentes: nhombre de variable = GetCpomponent()
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
       playerRb.velocity = new Vector3(moveInput.x * speed, playerRb.velocity.y, 0);
    }

   




    #region Input Events
    //Para crear un evento:
    //Se define public sin tipo de dato (Void) y con una referencia al Input (Callback.Context)
    public void HandleMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void HandleJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

        
    }


    #endregion




}

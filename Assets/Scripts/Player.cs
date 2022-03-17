using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //variables para la velocidad y fuerza de salto
    public float speed = 5f;
    public float jumpForce = 10f;
    //variable para saber si estamos en el suelo
    public bool isGrounded;
    //variable para almacenar el input de movimiento
    float dirX;
    
    //variables de componentes
    public SpriteRenderer spriteRenderer;
    public Animator _animator;
    Rigidbody2D _rBody;
    private GameManager gameManager;


    void Awake()
    {
        //asiganamos los componentes a las variables
        _animator = GetComponent<Animator>();
        _rBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        Debug.Log(dirX);

        //transform.position += new Vector3(dirX, 0, 0) * speed * Time.deltaTime;
        
        if(dirX == -1)
        {
            spriteRenderer.flipX = true;
            _animator.SetBool("Running", true);
        }
        else if(dirX == 1)
        {
            spriteRenderer.flipX = false;
            _animator.SetBool("Running", true);
        }
        else
        {
            _animator.SetBool("Running", false);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            _rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _animator.SetBool("Jumping", true);
        }
    }

    void FixedUpdate()
    {
        _rBody.velocity = new Vector2(dirX * speed, _rBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Si el objeto que entra en el trigger tiene el tag de Goombas
        /*if(collider.gameObject.CompareTag("Goombas"))
        {
            Debug.Log("Goomba muerto");
        }*/

        //si el objeto que entra en el trigger tiene la layer 6
        if(collider.gameObject.layer == 6)
        {
            Debug.Log("Goomba muerto");
            //llamamos a la funcion DeathGoomba del script GameManager
            gameManager.DeathGoomba(collider.gameObject);
        }

        //Si el trigger entra en la deadzone
        if(collider.gameObject.CompareTag("DeadZone"))
        {
            Debug.Log("Estoy muerto");
            gameManager.DeathMario();
            SceneManager.LoadScene(2);
        }

        if(collider.gameObject.tag == "Coin")
        {
            gameManager.Coin(collider.gameObject);
        }
        if(collider.gameObject.CompareTag("Bandera"))
        {
            Debug.Log("Nivel completado");
            SceneManager.LoadScene(1);
        }
        
    }   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private Rigidbody2D myRigidbody;
    //private Animator animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    
    public float speed;

    private Vector3 change;
    
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        //myRigidbody = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;

        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        //Debug.Log(change);

        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        if (canMove && change != Vector3.zero)
        {
            MoveCharacter();

            _animator.SetFloat("moveX", change.x);
            _animator.SetFloat("moveY", change.y);

            _animator.SetBool("moving", true);
        }
        else
        {
            //myRigidbody.velocity = Vector2.zero;
            //animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        _rigidbody.MovePosition(transform.position + change 
            * speed * Time.deltaTime);
    }
}

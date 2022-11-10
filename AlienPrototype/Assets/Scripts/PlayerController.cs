using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private float speed = 25f;
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private Transform player;

    private Vector2 _startTouchPosition, _endTouchPosition;
    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;
    private bool isJumpAllowed = false;
    public static bool inAir = false;
    private Vector2 jumpVec;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Start ()
    {
        MovePlayer.GiveMeRigibody();
    }

    void Update()
    {
        //Debug.Log(_rb.velocity);
        SwipeCheck();

    }

    void FixedUpdate()
    {
        JumpIfAllowed();
    }

    //void OnMouseDrag()
    //{
    //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    player.position = Vector3.MoveTowards(player.position, new Vector2(mousePos.x, player.position.y), speed * Time.deltaTime);
    //}

    //private void MoveCheck()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        moveTo = Input.GetTouch(0).position;

    //    }
    //}

    private void SwipeCheck()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _startTouchPosition = Input.GetTouch(0).position;
        }


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _endTouchPosition = Input.GetTouch(0).position;
            //Debug.Log(_endTouchPosition - _startTouchPosition);
            if (_endTouchPosition.y > _startTouchPosition.y && _rb.velocity.y == 0 && (_endTouchPosition - _startTouchPosition).y > 150)
            {
                isJumpAllowed = true;

            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(1).phase == TouchPhase.Began)
        {
            _startTouchPosition = Input.GetTouch(1).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(1).phase == TouchPhase.Ended)
        {
            _endTouchPosition = Input.GetTouch(1).position;
            //Debug.Log(_endTouchPosition-_startTouchPosition);
            if (_endTouchPosition.y > _startTouchPosition.y && _rb.velocity.y == 0 && (_endTouchPosition - _startTouchPosition).y>150)
            {
                isJumpAllowed = true;
            }
        }
    }

    private void JumpIfAllowed()
    {
        if (isJumpAllowed)
        {
            inAir = true;
            //_rb.AddForce(Vector2.up * jumpForce);

            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);

            isJumpAllowed = false;

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            inAir = false;
        }
    }

    private void OnCollisionEnter2d(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            inAir = false;
        }
       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            inAir = true;
        }
    }
}
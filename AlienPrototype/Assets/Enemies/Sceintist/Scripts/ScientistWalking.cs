using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistWalking : MonoBehaviour
{
    [Header (" оличество жизней")]
    [Tooltip ("“ут нужно указать количество жизней этого противника")]
    [SerializeField]
    private float health;

    [Header ("—корость передвижени€")]
    [Tooltip ("“ут нужно указать скорость передвижени€ этого противника")]
    [SerializeField]
    private float speed;

    private static ScientistWalking instance;
    public static ScientistWalking Instance { get => instance; set => instance = value; }

    private Rigidbody2D _rigidbody;
    //private Animator _animator;

    private PlayerController character = null;

    private string enemyState = "Walk";

    public float Health { get => health; set => health = value; }
    public string EnemyState { get => enemyState; set => enemyState = value; }
    

    private void ChangeDirection()
    {
        Debug.Log(transform.localScale);
        
        transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        character = collider.gameObject.GetComponent<PlayerController>();

        if (character != null)
        {
            enemyState = "Stop";

            //_animator.SetBool("Attack", true);
        } 
        
        if (collider.gameObject.tag == "EnemyTurnBack")
        {
            ChangeDirection();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyState = "Walk";

            //_animator.SetBool("Attack", false);
        }
    }

    private void Awake()
    {
        instance = this;

        _rigidbody = GetComponent<Rigidbody2D>();
        //_animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyState)
        {
            case "Stop":

                _rigidbody.velocity = Vector2.zero;

                break;

            case "Walk":

                Vector2 velocity = _rigidbody.velocity;

                velocity.x = speed * transform.localScale.x * -1;

                _rigidbody.velocity = velocity;

                break;
        }
        
    }
}

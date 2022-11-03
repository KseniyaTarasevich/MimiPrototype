using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D _rb;
    [SerializeField] private float speed = 2f;
    [SerializeField] private PlayerController playerController;

    private void Awake()
    {
        _rb = playerController.GetComponent<Rigidbody2D>();
    }

    void OnMouseDrag()
    {
        Debug.Log("kek "+ PlayerController.inAir);
        if (PlayerController.inAir == false)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("mousePos "+mousePos);
        //Debug.Log( "dif" + (new Vector3(mousePos.x, player.position.y) - player.position));
            //player.position = Vector3.MoveTowards(player.position, new Vector2(mousePos.x, player.position.y), speed * Time.deltaTime);

        

        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _rb.velocity = new Vector3( Mathf.Clamp((new Vector3(mousePos.x, player.position.y) - player.position).x, -1, 1) * speed, 0, 0);
        }
        //float h = speed * Input.GetAxis("Mouse X");
        //float v = speed * Input.GetAxis("Mouse Y");

        //Debug.Log(h + " " + v);
        //player.Rotate(v, h, 0);

        //Debug.Log("захватывающий геймплей");
        //}
    }

        //private void Update()
        //{
        //    float h = speed * Input.GetAxis("Mouse X");
        //    float v = speed * Input.GetAxis("Mouse Y");

        //    Debug.Log(h + " " + v);
        //    player.Rotate(v, h, 0);

        //    Debug.Log("захватывающий геймплей");
        //}
    }



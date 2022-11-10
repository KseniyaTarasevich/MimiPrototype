using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{
    private Transform player;
    private static Rigidbody2D _rb;
    [SerializeField] private float speed = 2f;

    private static MovePlayer _instance;
    public static MovePlayer Instance { get => _instance; }

    public void GiveMeRigibody(Rigidbody2D _playerRigidbody)
    {
        _rb = _playerRigidbody;
        player = _rb.gameObject.transform;
    }

    void OnMouseDrag()
    {
        if (_rb == null) return;

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

    private void Awake()
    {
        _instance = this;
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



using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{
    public Transform player;

    [SerializeField] private float speed = 15f;
    void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        player.position = Vector3.MoveTowards(player.position, new Vector2(mousePos.x, player.position.y), speed * Time.deltaTime);

        Debug.Log("захватывающий геймплей");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private string playerTag;
    [SerializeField] private float movingSpeed;

    [SerializeField] private float leftBoundary;
    [SerializeField] private float rightBoundary;
    [SerializeField] private float bottomBoundary;
    [SerializeField] private float upperBoundary;


    private void Awake()
    {
        if (this.playerTransform == null)
        {
            if (this.playerTag == "")
            {
                this.playerTag = "Player";
            }

            this.playerTransform = GameObject.FindGameObjectWithTag(this.playerTag).transform;
        }

        this.transform.position = new Vector3()
        {
            x = this.playerTransform.position.x + 10,
            y = this.playerTransform.position.y + 10,
            z = this.playerTransform.position.z - 10
        };
    }

    private void Update()
    {
        if (this.playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = this.playerTransform.position.x + 10,
                y = this.playerTransform.position.y + 10,
                z = this.playerTransform.position.z - 10
            };

            Vector3 position = Vector3.Lerp(this.transform.position, target, this.movingSpeed * Time.deltaTime);

            this.transform.position = position;
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBoundary, rightBoundary), Mathf.Clamp(transform.position.y, bottomBoundary, upperBoundary), transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(new Vector2(leftBoundary,upperBoundary), new Vector2(rightBoundary,upperBoundary));
        Gizmos.DrawLine(new Vector2(leftBoundary, bottomBoundary), new Vector2(rightBoundary, bottomBoundary));
        Gizmos.DrawLine(new Vector2(leftBoundary, upperBoundary), new Vector2(leftBoundary, bottomBoundary));
        Gizmos.DrawLine(new Vector2(rightBoundary, upperBoundary), new Vector2(rightBoundary, bottomBoundary));

    }
}

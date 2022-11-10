using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAndControllerAttach : MonoBehaviour
{
    /* ������ ����������� ������ � ���������� � ��������� ��� ��� ������ */

    private MovePlayer _controller;

    private CameraController _camera;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _camera = Camera.current.gameObject.GetComponent<CameraController>();

        _controller = GameObject.FindGameObjectWithTag("Controller").gameObject.GetComponent<MovePlayer>();

        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // ��������� ������
        CameraController.Instance.Attach(gameObject.transform);

        // ��������� ����������
        MovePlayer.Instance.GiveMeRigibody(_rigidbody);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

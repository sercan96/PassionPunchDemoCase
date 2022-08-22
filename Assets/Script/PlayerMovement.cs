using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    public static bool IsPlayerMove;
    private float _playerAngle;

    public static Vector3 direction;
    private Camera _cam;
    private Vector3 input;

    void Start()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        Move();
        RotatePlayer();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * _speed;

        input = new Vector3(horizontal, 0, vertical);

        if (input.magnitude > 0f)
        {
            Player.Instance.OpenAndCloseAnimator(true);
            IsPlayerMove = true;
            transform.Translate(input);
        }
        else
        {
            IsPlayerMove = false;
            Player.Instance.OpenAndCloseAnimator(false);
        }
    }

    void RotatePlayer()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out var distance))
            direction = ray.GetPoint(distance);
        
        Vector3 offset = direction - transform.position;
        if (offset.magnitude >= 1)
            transform.LookAt(direction);
    }
}
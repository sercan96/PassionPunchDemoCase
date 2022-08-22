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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)
            || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow))
        {
            Player.Instance.OpenAndCloseAnimator(true);
            IsPlayerMove = true;
            float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
            float vertical = Input.GetAxis("Vertical") * Time.deltaTime * _speed;
            transform.Translate(horizontal,0f,vertical);
        }
        else
        {
            IsPlayerMove = false;
            Player.Instance.OpenAndCloseAnimator(false);
        }

    }

    void RotatePlayer()
    {
        // _playerAngle += Input.GetAxis("Mouse X") * PlayerRotateSpeed * Time.deltaTime;
        // _playerAngle = Mathf.Clamp(_playerAngle, 0, 180);
        // transform.localRotation = Quaternion.AngleAxis(_playerAngle, Vector3.up);
        
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out var distance))
            direction = ray.GetPoint(distance);

        // transform.position = Vector3.MoveTowards(transform.position, new Vector3(_direction.x, 0f, _direction.z),
        //     _playerSpeed * Time.deltaTime);

        // Bugı önlemek için yazdık.
        Vector3 offset = direction - transform.position;
        if (offset.magnitude >= 1)
            transform.LookAt(direction);
    }

    
}

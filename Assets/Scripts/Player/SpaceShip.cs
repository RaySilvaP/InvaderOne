using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class SpaceShip : Movement
{
    // Update is called once per frame
    void Update()
    {
        SetDirection();
        Accelerate();
    }

    void FixedUpdate()
    {
        transform.Translate(Speed);
    }

    private void SetDirection()
    {
        if (Input.GetKey(KeyCode.D))
            _direction.x = 1;
        else if (Input.GetKey(KeyCode.A))
            _direction.x = -1;
        else
            _direction.x = 0;

        if (Input.GetKey(KeyCode.W))
            _direction.y = 1;
        else if (Input.GetKey(KeyCode.S))
            _direction.y = -1;
        else
            _direction.y = 0;
    }
}

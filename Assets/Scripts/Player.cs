using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x, y, 0);

        UpdateMotor(moveDelta);
    }
}

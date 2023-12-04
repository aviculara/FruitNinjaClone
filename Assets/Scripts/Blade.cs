using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody2D rb;
    public float minVelocity = 0.1f;
    private Vector3 lastMousePos;
    private Vector3 mouseVelocity;
    private new Collider2D collider;


    // Awake is called before the first frame update and before the start methods
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>(); //Blade object has the Blade script, and also has a 2d collider
        //Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        collider.enabled = isMouseMoving();
        SetBladeToMouse();
    }

    private void SetBladeToMouse()
    {
        //var is commonly used with anonymous types, where the type name is not explicitly defined.
        var mousePos = Input.mousePosition;
        mousePos.z = 10; //position adjusted for the z position of fruits
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private bool isMouseMoving()
    {
        Vector3 currentMousePos = transform.position;
        float traveled = (lastMousePos - currentMousePos).magnitude;

        lastMousePos = currentMousePos;
        if(traveled > minVelocity)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

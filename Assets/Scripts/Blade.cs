using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody2D rb;
    // Awake is called before the first frame update and before the start methods
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetBladeToMouse();
    }

    private void SetBladeToMouse()
    {
        //var is commonly used with anonymous types, where the type name is not explicitly defined.
        var mousePos = Input.mousePosition;
        mousePos.z = 10; //position adjusted for the z position of fruits
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    float vertical;
    float horizontal;
    bool b_input;
    bool a_input;
    bool x_input;
    bool y_input;


    bool rb_input;
    float rt_axis;
    bool rt_input;
    bool lb_input;

    float lt_axis;
    bool lt_input;

    StateManager states;
    CameraManager camManager;

    float delta;

    void Start()
    {
        states = GetComponent<StateManager>();
        states.Init();

        camManager = CameraManager.singleton;
        camManager.Init(this.transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        delta = Time.fixedDeltaTime;
        GetInput();
        UpdateStates();
        states.FixedTick(delta);
        camManager.Tick(delta);
    }

    void Update()
    {
        delta = Time.deltaTime;
        states.Tick(delta);

    }
    void GetInput()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        b_input = Input.GetButton("B");
        a_input = Input.GetButton("A");
        x_input = Input.GetButton("X");
        y_input = Input.GetButton("Y");
        rt_input = Input.GetButton("RT");
        rt_axis = Input.GetAxis("RT");
        if (rt_axis != 0)
            rt_input = true;

        lt_input = Input.GetButton("LT");
        lt_axis = Input.GetAxis("LT");
        if (lt_axis != 0)
            lt_input = true;
        rb_input = Input.GetButton("RB");
        lb_input = Input.GetButton("LB");
    }

    void UpdateStates()
    {
        states.horizontal = horizontal;
        states.vertical = vertical;

        Vector3 v = vertical * camManager.transform.forward;
        Vector3 h = horizontal * camManager.transform.right;
        states.moveDir = (v + h).normalized;
        float m = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
        states.moveAmount = Mathf.Clamp01(m);

        if (b_input)
        {
            states.run = (states.moveAmount > 0);
        }
        else
        {
            states.run = false;
        }


        states.rt = rt_input;
        states.lt = lt_input;
        states.rb = rb_input;
        states.lb = lb_input;

        if (y_input)
        {
            states.isTwoHanded = !states.isTwoHanded;
            states.HandleTwoHanded();
        }
    }
}

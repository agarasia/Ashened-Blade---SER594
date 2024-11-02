using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimatorHook : MonoBehaviour
{
    Animator anim;
    StateManager states;

    public float rm_multi;


    public void Init(StateManager st){
        states=st;
        anim=st.anim;
    }
    void onAnimatorMove(){
        if(states.canMove)
            return;

        states.rigid.drag=0;

        if(rm_multi == 0)
           rm_multi == 1;

        Vector3 delta= anim.deltaPosition;
        delta.y=0;

        Vector3 v=(delta* multiplier)/states.delta;
        states.rigid.velocity=v;
    }

}

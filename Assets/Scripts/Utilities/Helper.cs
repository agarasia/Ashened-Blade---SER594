using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class Helper : MonoBehaviour
    {
        [Range(0, 1)]
        public float vertical;
        public bool twoHanded;

        public string[] oh_attacks;
        public string[] th_attacks;
        public bool useItem;
        public bool interacting;
        public bool playAnim;
        public bool enableRootMotion;

        Animator anim;
        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            enableRootMotion = !anim.GetBool("canMove");
            anim.applyRootMotion = enableRootMotion;

            interacting = anim.GetBool("interacting");

            if (enableRootMotion) return;

            if (useItem)
            {
                anim.Play("use_item");
                useItem = false;
            }

            if (interacting)
            {
                playAnim = false;
                vertical = Mathf.Clamp(vertical, 0, 0.5f);
            }
            anim.SetBool("two_Handed", twoHanded);

            if (playAnim)
            {
                string targetAnim;

                if (twoHanded)
                {
                    int r = Random.Range(0, th_attacks.Length);
                    targetAnim = th_attacks[r];
                }
                else
                {
                    int r = Random.Range(0, oh_attacks.Length);
                    targetAnim = oh_attacks[r];
                }
                vertical = 0f;
                anim.CrossFade(targetAnim, 0.2f);
                // anim.SetBool("canMove", false);
                // enableRootMotion = true;
                playAnim = false;
            }
            anim.SetFloat("vertical", vertical);
        }
    }
}

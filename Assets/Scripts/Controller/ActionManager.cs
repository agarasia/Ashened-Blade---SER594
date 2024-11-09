using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class ActionManager : MonoBehaviour
    {
        public List<Action> actionSlots = new List<Action>();
        public void Init()
        {
            if(actionSlots.Count!=0)
                return;
            
        }
        ActionManager(){
            for(int i=0;i<4;i++)
            {
                Action a =new Action();
                a.input=(ActionInput)i;
                actionSlots.Add(a);
            }
        }

        public ActionInput GetAction(StateManager st)
        {
            if(st.rb)
                return ActionInput.rb;
            if(st.lb)
                return ActionInput.lb;
            if(st.rt)
                return ActionInput.rt;
            if(st.lt)
                return ActionInput.lt;

            return ActionInput.rb;
        }
    }

    public enum ActionInput{
        rb,lb,rt,lt
    }
    [System.Serializable]
    public class Action{
        public ActionInput input;
        public string targetAnim;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define a delegate
public delegate void BaseDelegate();

public class FSM <T>
{
    public T currentState; //The callback index which should be execute in current

    private Dictionary<T, BaseDelegate> states; //The callback array of all states

    // Add state callback method
    public void AddCallback (T state, BaseDelegate statesDelegate)
    {   // Detect weather already include the state
        if(statesDelegate != null && !states.ContainsKey(state))
        {   // Add state callback
            states.Add(state, statesDelegate);
        }
    }

    //Use constructor for initialization
    public FSM(T defaultState)
    {   //Member variables initialization
        states = new Dictionary<T, BaseDelegate>();
        currentState = defaultState;
    }

    //Update is called once per frame
    public void Update()
    {   //Detecting weather state and callback are exist
        if (states.ContainsKey(currentState))
        {   //Obtain callback via current index
            BaseDelegate state = states[currentState];
            //Detecting weather the callback is null
            if (state != null)
            {   //Execute callback
                state();
            }
        }
    }
}
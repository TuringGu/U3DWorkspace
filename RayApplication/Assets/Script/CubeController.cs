
using System.Collections;
using UnityEngine;

// States of cube
public enum CubeStates
{
    Idle,   //  Idle state
    Move,   //  Moving state
}

public class CubeController:MonoBehaviour
{
    public float speed; //  Cube moving speed

    private FSM<CubeStates> _fsm;   //  State machine
    private Material mat;   //  Cube material

    void Awake()
    {
        speed = 3;  // Initial value
        mat = GetComponent<Renderer>().material;
        _fsm = new FSM<CubeStates>(CubeStates.Idle);
        _fsm.AddCallback(CubeStates.Idle, new BaseDelegate(OnIdleState));
        _fsm.AddCallback(CubeStates.Move, new BaseDelegate(OnMoveState));
    }

    void Update()
    {
        _fsm.Update();
    }

    private void OnIdleState()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if(h != 0f || v != 0f)
        {
            _fsm.currentState = CubeStates.Move;
        }
    }

    private void OnMoveState()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h == 0f && v == 0f)
        {
            mat.color = Color.white;
            _fsm.currentState = CubeStates.Idle;
        }
        // Move cube
        Vector3 target = new Vector3(h, 0f, v).normalized;
        transform.position += Time.deltaTime * speed * target;
        float f = Mathf.Abs(h) > Mathf.Abs(v) ? Mathf.Abs(h) : Mathf.Abs(v);
        Color c = new Color(1f, 1 - f, 1 - f);
        mat.color = c;
    }
}
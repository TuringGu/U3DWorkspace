using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stands for the states of light
public enum LightStates
{
    Close = 0,
    Open,
}

public class LightController:MonoBehaviour {
    // Public
    public float fadeSpeed;     // The light intensity changing speed
    public float _maxIntensity; // Max intensity in animation

    // Private
    private Light _light;           // Current object light component
    private float _minIntensity;    // Min intensity in animation
    private bool _isAnimation;      // Weather doing light animation
    private bool _isReset;          // Weather be in 2nd state of animation
    private FSM<LightStates> _fsm;  // States machine

    // Use this for initialization
    void Awake()
    {
        fadeSpeed = 2f;
        _maxIntensity = 4f;
        _minIntensity = 0f;
        _isAnimation = false;
        _isReset = false;
        _light = GetComponent<Light>();
        _light.intensity = 0f;  // Set current light intensity is 0

        // States machine initialization and set default state
        _fsm = new FSM<LightStates>(LightStates.Close);
        // Add states callback (Note: Order is important)
        _fsm.AddCallback(LightStates.Close, new BaseDelegate(OnCloseState));
        _fsm.AddCallback(LightStates.Open, new BaseDelegate(OnOpenState));
    }

    //Update is called once per frame
    void Update()
    {
        _fsm.Update();
    }

    // When light state is open
    private void OnOpenState()
    {   // Implement light flickering effect
        if (_isAnimation)
        {   // Doing light animation
            if (!_isReset)
            {   // Judge weather the light intensity is min
                if (_light.intensity <= _minIntensity)
                {   // Going 2nd state of animation
                    _isReset = true;
                    return;
                }
                // Doing the 1st state of animation: intensity decrease
                _light.intensity -= Time.deltaTime * fadeSpeed;
            }
            else
            {   // Judge weather the ligth intensity is max
                if (_light.intensity >= _maxIntensity)
                {   // Modify intensity
                    _light.intensity = _maxIntensity;
                    // Stop 2nd state of animation
                    _isReset = false;
                    // Stop Animation
                    _isAnimation = false;
                    return;
                }
                // Doing the 2st state of animation: intensity increase
                _light.intensity += Time.deltaTime * fadeSpeed;
            }
        }
        else
        {   // Not doing light animation
            // Generate a random intensity light
            _minIntensity = Random.Range(0.3f, 0.7f);
            // Restart the animation
            _isAnimation = true;
        }

        // Detect key event: press C to turn off the light
        if (Input.GetKeyDown(KeyCode.C))
        {
            _light.intensity = 0f;
            // Update current light state
            _fsm.currentState = LightStates.Close;
        }
    }

    // When light state is close
    private void OnCloseState()
    {   //Detect key event: press O to turn on the light
        if (Input.GetKeyDown(KeyCode.O))
        {   // The animation of turn on
            _isAnimation = true;
            // Doing the 2nd state of animation
            _isReset = true;
            // Update current light state
            _fsm.currentState = LightStates.Open;
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightStates
{
    Close,
    Open,
}

public class LightController : MonoBehaviour {
    public float fadeSpeed ;    // The light intensity changing speed
    public float _maxIntensity; // Max intensity in animation

    private Light _light;               // Current object light component
    private LightStates _currentState;  // Current light state
    private float _minIntensity;        // Min intensity in animation
    private bool _isAnimation;          // Weather doing light animation
    private bool _isReset;              // Weather be in 2nd state of animation

    // Use this for initialization
    void Awake()
    {
        _light = GetComponent<Light>();
        fadeSpeed = 2f;
        _maxIntensity = 4f;
        _currentState = LightStates.Close;
        _minIntensity = 0f;
        _isAnimation = false;
        _isReset = false;
    }

    // Update is called once per frame
    void Update () {
		// State detect
        switch(_currentState)
        {
            case LightStates.Open:
                OnOpenState();
                break;
            case LightStates.Close:
                OnCloseState();
                break;
        }
	}

    // When light state is open
    private void OnOpenState()
    {   // Implement light flickering effect
        if (_isAnimation)
        {   // Doing light animation
            if(!_isReset)
            {   // Judge weather the light intensity is min
                if(_light.intensity <= _minIntensity)
                {   // Going 2nd state of animation
                    _isReset = true;
                    return;
                }
                // Doing the 1st state of animation: intensity decrease
                _light.intensity -= Time.deltaTime * fadeSpeed;
            }
            else
            {   // Judge weather the ligth intensity is max
                if(_light.intensity >= _maxIntensity)
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
        if(Input.GetKeyDown(KeyCode.C))
        {
            _light.intensity = 0f;
            // Update current light state
            _currentState = LightStates.Close;
        }
    }

    // When light state is close
    private void OnCloseState()
    {   //Detect key event: press C to turn off the light
        if(Input.GetKeyDown(KeyCode.O))
        {   // The animation of turn on
            _isAnimation = true;
            // Doing the 2nd state of animation
            _isReset = true;
            // Update current light state
            _currentState = LightStates.Open;
        }
    }
}

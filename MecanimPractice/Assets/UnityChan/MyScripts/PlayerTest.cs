using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Every state about (4 ~ 10 s)
enum PoseWaitType {
	Wait00 = 0,		// stand, default pose (null pose)
	Wait01,		
	Wait02,		
	Wait03,		
	Wait04,		
}



public class PlayerTest : MonoBehaviour {

	public float _poseTimeDefault;	// Default pose waiting time
	public float _poseDetectInterval;	// Time interval to detect

	public int _poseWaitType;		// The pose type
	//public float _posingProbability;	// Probability to posing

	//public float _posingWantTime;	// Charactor begin want to posing
	//public  float _posingMustTime;	// Charactor must posing (0 <= want < must)


	private Animator _animator;





	void Awake() {
		_animator = GetComponent<Animator> ();

		// Initialization
		_poseTimeDefault = 0.0f;
		_poseDetectInterval = 4.0f;

		//_posingWantTime = 4.0f;
		//_posingMustTime = 20.0f;
		_poseWaitType = (int)PoseWaitType.Wait00;	// Default wait pose type

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		_poseTimeDefault += Time.deltaTime;	// Time update
        _poseWaitType = _animator.GetInteger("poseWaitType");  // Current pose type udpate

		// Charactor wants to posing (int default pose)
		if (_poseWaitType == (int)PoseWaitType.Wait00 && (!_animator.GetBool("isPose"))) {
			// Pose Detect
			if (_poseTimeDefault >= _poseDetectInterval) {
				// Posing	
                switch(Random.Range(1, 13))
                {   // Generate ramdom pose type
                    case 2:
                        {
                            _animator.SetInteger("poseWaitType", (int)PoseWaitType.Wait01);
                            _animator.SetBool("isPose", true);
                            break;
                        }
                    case 5:
                        {
                            _animator.SetInteger("poseWaitType", (int)PoseWaitType.Wait02);
                            _animator.SetBool("isPose", true);
                            break;
                        }
                    case 8:
                        {
                            _animator.SetInteger("poseWaitType", (int)PoseWaitType.Wait03);
                            _animator.SetBool("isPose", true);
                            break;
                        }
                    case 11:
                        {
                            _animator.SetInteger("poseWaitType", (int)PoseWaitType.Wait04);
                            _animator.SetBool("isPose", true);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                _poseTimeDefault = 0.0f;    // reset
            }
		}
        else if (_animator.GetBool("isPose") && (_poseTimeDefault > 4.7f))
        {   // Not in default pose
            // Wait for pose anime ends
            _animator.SetInteger("poseWaitType", (int)PoseWaitType.Wait00);    // Default pose
            _animator.SetBool("isPose", false);
        }		
	}
		// Wait pose type judge

//		double hours = System.DateTime.Now.Hour; 				// Current hour
//		double minutes = System.DateTime.Now.Minute;  			// Current minute
//		double seconds = System.DateTime.Now.Second;  			// Current second
//		double milliseconds = System.DateTime.Now.Millisecond;  // Current millisecond
//
//		print ("hours: " + hours);
//		print ("minutes: " + minutes);
//		print ("seconds: " + seconds);

}

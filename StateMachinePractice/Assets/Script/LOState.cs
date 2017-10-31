using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM {

	public class LOState:IState {

		private string _name;	// State name
		private string _tag;	// State tag

		/// <summary>
		/// State name
		/// </summary>
		/// <value>StateName</value>
		public string Name {
			get {
				return _name;
			}
		}

		/// <summary>
		/// State tag
		/// </summary>
		/// <value>State tag</value>
		public string Tag {
			get {
				return _tag;
			}
			set {
				_tag = value;
			}
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="name"> StateName </param>
		public LOState(string name) {
			_name = name;
		}

		/// <summary>
		/// Callback of enter state
		/// </summary>
		/// <param name="prev">PreviousState</param>
		public void EnterCallback (IState prev)
		{
			
		}

		/// <summary>
		/// Callback of quit state
		/// </summary>
		/// <param name="next">NextState</param>
		public void ExitCallback (IState next)
		{
			
		}

		/// <summary>
		/// Callback of Update
		/// </summary>
		/// <param name="deltaTime">Time.deltaTime</param>
		public void UpdateCallback (float deltaTime)
		{
			
		}

		/// <summary>
		/// Callback of LateUpdate
		/// </summary>
		/// <param name="deltaTime">Time.deltaTime</param>
		public void LateUpdateCallback (float deltaTime)
		{
			
		}

		/// <summary>
		/// Callback of fixedUpdate
		/// </summary>
		public void FixedUpdateCallback ()
		{
			
		}
			
	}
}
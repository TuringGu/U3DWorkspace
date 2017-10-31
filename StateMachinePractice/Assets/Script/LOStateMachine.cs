
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM {

	/// <summary>
	/// State Machine class need to inherated from 
	/// state class and implement state machine interface
	/// </summary>
	public class LOStateMachine : LOState, IStateMachine {

		private IState _currentState;	// Current state
		private IState _defaultState;	// Default state


		/// <summary>
		/// Current state
		/// </summary>
		/// <value>The current state of state machine</value>
		public IState CurrentState {
			get {
				return _currentState;
			}
		}
		/// <summary>
		/// Default state
		/// </summary>
		/// <value>The default state of state machine</value>
		public IState DefaultState {
			get {
				return _defaultState;
			}
			set {
				_defaultState = value;
			}
		}

		/// <summary>
		/// Constructor of LOStateMachine
		/// </summary>
		public LOStateMachine(string name) : base (name) {
			
		}


		/// <summary>
		/// Adds the state.
		/// </summary>
		/// <param name="state">The state want to add</param>
		public void AddState (IState state)
		{
			
		}

		/// <summary>
		/// Removes the state.
		/// </summary>
		/// <param name="state">The state want to remove</param>
		public void RemoveState (IState state)
		{
			
		}

		/// <summary>
		/// Gets the state by using specific tag.
		/// </summary>
		/// <returns>The state which be found</returns>
		/// <param name="tag">The tag of state</param>
		public IState GetStateWithTag (string tag)
		{
			return null;
		}



	}
}
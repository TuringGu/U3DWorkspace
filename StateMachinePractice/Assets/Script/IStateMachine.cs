using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM {

	/// <summary>
	/// State machine interface
	/// </summary>
	public interface IStateMachine {

		/// <summary>
		/// Current state
		/// </summary>
		/// <value> The current state of state machine </value>
		IState CurrentState { get;}

		/// <summary>
		/// Default state
		/// </summary>
		/// <value> The default state of state machine</value>
		IState DefaultState { set; get;}

		/// <summary>
		/// Adds the state.
		/// </summary>
		/// <param name="state"> The state want to add </param>
		void AddState(IState state);

		/// <summary>
		/// Removes the state.
		/// </summary>
		/// <param name="state"> The state want to remove </param>
		void RemoveState (IState state);

		/// <summary>
		/// Gets the state by using specific tag.
		/// </summary>
		/// <returns> The state which be found </returns>
		/// <param name="tag"> The tag of state </param>
		IState GetStateWithTag (string tag);


	}
}
	

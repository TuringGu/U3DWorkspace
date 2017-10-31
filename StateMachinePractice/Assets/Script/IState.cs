using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
	/// <summary>
	/// State interface
	/// </summary>
	public interface IState
	{
		/// <summary>
		/// State name
		/// </summary>
		/// <value> StateName </value>
		string Name { get; }

		/// <summary>
		/// State tag
		/// </summary>
		/// <value> State tag </value>
		string Tag { set; get; }

		/// <summary>
		/// Callback of enter state
		/// </summary>
		/// <param name="prev"> PreviousState </param>
		void EnterCallback(IState prev);

		/// <summary>
		/// Callback of quit state
		/// </summary>
		/// <param name="next"> NextState </param>
		void ExitCallback(IState next);

		/// <summary>
		/// Callback of Update
		/// </summary>
		/// <param name="deltaTime"> Time.deltaTime </param>
		void UpdateCallback(float deltaTime);

		/// <summary>
		/// Callback of LateUpdate
		/// </summary>
		/// <param name="deltaTime"> Time.deltaTime </param>
		void LateUpdateCallback(float deltaTime);

		/// <summary>
		/// Callback of fixedUpdate
		/// </summary>
		void FixedUpdateCallback();
	}
}
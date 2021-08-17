using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// RandomWalk class
// Placed on a walker prefab
// Moves a random walker using randomized values

public class RandomWalk : MonoBehaviour 
{

	// Class fields
	// Will any class fields help the walker start and stop moving?


	void Start () 
	{
		
	}

    void Update()
    {
        // Only call Walk() when a user presses the 'M' key
        Walk();
    }

	/// <summary>
	/// Walk()
	/// Purpose: Calculates the position of a walker after he has taken a randomized step
	/// Params:  none
	/// Returns: none
	/// </summary>
	void Walk()
	{
		// Generate a random number

		// Based on the number generated, the walker will move positively, negatively, or remain in place on the X axis

		// Generate another random number

		// Based on the number generated, the walker will move positively, negatively, or remain in place on the Z axis

	}
}

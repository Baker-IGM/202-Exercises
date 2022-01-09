using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum TerrainMode
{
    Flat,
    Ramp,
    Perlin
}

// TerrainGeneration class
// Placed on a terrain game object
// Generates a Perlin noise-based heightmap
[RequireComponent (typeof(TerrainCollider))]
public class TerrainGeneration : MonoBehaviour 
{

	private TerrainData myTerrainData;
    [Tooltip ("The size of the terrain")]
	public Vector3 worldSize = new Vector3(200, 50, 200);
    [Tooltip("Number of vertices along X and Z axes")]
    [Min (1)]
    public int resolution = 129;
	float[,] heightArray;

    [SerializeField]
    [Tooltip ("The terrain generation mode")]
    TerrainMode terrainMode;

    [SerializeField]
    [Tooltip ("The to use for Flat Terrain Mode")]
    float flatValue = 1f;


    void Start()
    {
        myTerrainData = gameObject.GetComponent<TerrainCollider>().terrainData;
        myTerrainData.size = worldSize;
        myTerrainData.heightmapResolution = resolution;

        DrawTerrain();
    }
	

	void Update () 
	{
        //  Redraws the terrain when the 'D' key has been pressed
		if(Keyboard.current.dKey.wasPressedThisFrame)
        {
            DrawTerrain();
        }
	}

	/// <summary>
	/// Flat()
	/// Assigns heightArray identical values
	/// </summary>
	void Flat(float value)
	{
		// Fill heightArray with 1's
		for(int i = 0; i < resolution; i++)
		{
			for(int j = 0; j < resolution; j++)
			{
				heightArray [i, j] = value;
			}
		}
	}
		

	/// <summary>
	/// Ramp()
	/// Assigns heightsArray values that form a linear ramp
	/// </summary>
	void Ramp()
	{
		// Fill heightArray with linear values


	}

	/// <summary>
	/// Perlin()
	/// Assigns heightsArray values using Perlin noise
	/// </summary>
	void Perlin()
	{
		// Fill heightArray with Perlin-based values


	}

    void DrawTerrain()
    {
        heightArray = new float[resolution, resolution];

        // Fill the height array with values!
        //  Change the value of terrainMode in the inspector to see different terrrain generation modes
        switch(terrainMode)
        {
            case TerrainMode.Flat:
                //  Change the value of rampValue in the inspector to see the diffent ramp values
                Flat(flatValue);
                break;
            case TerrainMode.Ramp:
                Ramp();
                break;
            case TerrainMode.Perlin:
                Perlin();
                break;
        }

        // Assign values from heightArray into the terrain object's heightmap
        myTerrainData.SetHeights(0, 0, heightArray);
    }
}

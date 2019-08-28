using System.Collections;
using UnityEngine;

public class ShuffleArray : MonoBehaviour
{
    /// Public so you can fill the array in the inspector
	public GameObject[] scenarios;


    void Start()
    {
        // Shuffle scenarios array
        Shuffle(scenarios);
    }


    public void Shuffle(GameObject[] a)
    {
        
        // Loops through array
        for (int i = a.Length - 1; i > 0; i--)
        {
            // Randomize a number between 0 and i (so that the range decreases each time)
            int rnd = Random.Range(0, i);

            // Save the value of the current i, otherwise it'll overright when we swap the values
            GameObject temp = a[i];

            // Swap the new and old values
            a[i] = a[rnd];
            a[rnd] = temp;
        }

        // Print
        for (int i = 0; i < a.Length; i++)
        {
         //   Debug.Log(a[i]);
        }
    }
}

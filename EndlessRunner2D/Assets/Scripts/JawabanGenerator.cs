using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawabanGenerator : MonoBehaviour
{
    public GameObject thejawaban;
    public Transform generationPoint;
    public float distanceBetween;
    private float platformWidth;
    private float lebarJawaban;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public GameObject[] theJawabans;
    private int jawabanSelector;
    private float[] jawabanWidths;

    // Start is called before the first frame update
    void Start()
    {
        //platformWidth = thejawaban.GetComponent<BoxCollider2D>().size.x;
        jawabanWidths = new float[theJawabans.Length];
        for (int i = 0; i < theJawabans.Length; i++)
        {
            jawabanWidths[i] = theJawabans[i].GetComponent<BoxCollider2D>().size.x;
        }
    }

    // Update is called once per frame
    void Update()
        {

            if (transform.position.x < generationPoint.position.x)
            {
                distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

                for (int i = theJawabans.Length - 1; i > 0; i--)
                {
                    // Randomize a number between 0 and i (so that the range decreases each time)
                    int rnd = Random.Range(0, i);

                    // Save the value of the current i, otherwise it'll overright when we swap the values
                    GameObject temp = theJawabans[i];

                    // Swap the new and old values
                    theJawabans[i] = theJawabans[rnd];
                    theJawabans[rnd] = temp;
                }

                // Print
                for (int i = 0; i < theJawabans.Length; i++)
                {
                    //Debug.Log(theJawabans[i]);
                    
                }

            jawabanSelector = Random.Range(0, theJawabans.Length);


            transform.position = new Vector3(transform.position.x + jawabanWidths[jawabanSelector] + distanceBetween, transform.position.y);

                Instantiate (/*thejawaban*/theJawabans[jawabanSelector], transform.position, transform.rotation);
            }
        }

    }

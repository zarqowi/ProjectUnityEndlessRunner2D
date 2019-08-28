using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public bool grounded;
    public LayerMask whatIsGround;
    public float jumpForce;
    public float moveSpeed;
    Rigidbody2D myRigidbody;
    Collider2D myCollider;

    public AudioSource WRONG_SOUND, TRUE_SOUND;

    [SerializeField]
    private GameObject jawabanCollider;
    private int poin;
    

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
        }
        transform.position = new Vector3(transform.position.x + 0.002f , transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Jawaban")
        {
            TextMeshPro txtPilih = col.gameObject.GetComponent<TextMeshPro>(); 
            //Debug.Log("OnCollisionEnter2D : " +  txtPilih.text);
            if (GameAction.ARRAY_SOAL.Contains(txtPilih.text))
            {
                TRUE_SOUND.Play();
                GameAction.TRUE_ANS++;
                GameAction.KATA_JAWAB.Add(txtPilih.text);
                int idx = GameAction.ARRAY_BENAR.IndexOf(txtPilih.text);
                GameAction.KATA_SOAL[idx] = txtPilih.text;

                string strFix = string.Join(" ", GameAction.KATA_SOAL.ToArray());
                strFix = strFix.ToLower();
                strFix = GameControls.UppercaseWords(strFix);

                GameAction.TEXT_SOAL = strFix;
                GameAction.ARRAY_SOAL.Remove(txtPilih.text); 

                if (GameAction.TRUE_ANS >= GameAction.ITEM_LEVEL[GameAction.GAME_LEVEL])
                {
                    GameAction.SCORES += 10;
                    GameAction.GAME_STATUS = true;
                }
            }
            else
            {
                GameAction.TRY_COUNT++;
                WRONG_SOUND.Play();
            }
            col.gameObject.transform.position = new Vector3(col.gameObject.transform.position.x - 1000, col.gameObject.transform.position.y);
            
        }
    }

}
   

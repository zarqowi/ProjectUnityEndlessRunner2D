using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControls : MonoBehaviour
{
    public GameObject PLAT_BASE;
    public GameObject PLAYER_SPAWNER;
    public GameObject PLAYERs;
    public GameObject PANEL_OVER,PANEL_PLAY;

    public Text Txt_SOAL,Txt_SCORES;
    public List<string>[] ARRAY_LIRIK_SOAL;
    public List<string>  ARRAY_KATA;
    public TextMeshPro[] Txt_JAWABAN;

    // Start is called before the first frame update
    void Start() 
    {
    
        // Vector3 newPos = PLAYER_SPAWNER.transform.position; 
        // Instantiate (PLAT_BASE,newPos, transform.rotation);
        PLAYERs.SetActive(true);
        PANEL_OVER.SetActive(false);
        PANEL_PLAY.SetActive(true);

        string[] listSoal = GameAction.LIRIK_LAGU[GameAction.INDEX_PILIHAN];
        List<List<string>> ListSOAL_VALID = new List<List<string>>();
        ARRAY_KATA = new List<string>();
        foreach (string s in listSoal){
            string[] strLirik = s.Split(' '); 
            List<string> arrLirik = new List<string>();
            foreach (string sas in strLirik){
                string sa = sas.ToLower();
                sa = UppercaseWords(sa);
                if (!arrLirik.Contains(sa)){
                    arrLirik.Add(sa);
                }
                if (!ARRAY_KATA.Contains(sa))
                {
                    ARRAY_KATA.Add(sa);
                }
                

            }
            if (arrLirik.Count > GameAction.ITEM_LEVEL[GameAction.GAME_LEVEL])
            {
                ListSOAL_VALID.Add(arrLirik);
            } 
        }
        int i = Random.Range(0, ListSOAL_VALID.Count);
        while (ListSOAL_VALID.Count < GameAction.JML_SOAL[GameAction.GAME_LEVEL])
        {
            ListSOAL_VALID.Add(ListSOAL_VALID[i]);
            i = Random.Range(0, ListSOAL_VALID.Count);
        }

        ARRAY_LIRIK_SOAL = new List<string>[GameAction.JML_SOAL[GameAction.GAME_LEVEL]] ;
        List<string>[] arrSoal = new List<string>[ListSOAL_VALID.Count];
        i = 0;
        int[] indexSoal = new int[ListSOAL_VALID.Count];
        foreach (List<string> lst in ListSOAL_VALID)
        {
            //Debug.Log(string.Join(", ", lst.ToArray()));
            arrSoal[i] = lst;
            indexSoal[i] = i;
            i++;
        }
        printArray(indexSoal);
        indexSoal= Shuffle(indexSoal);
        printArray(indexSoal);

        for (i = 0; i < ARRAY_LIRIK_SOAL.Length; i++)
        {
            ARRAY_LIRIK_SOAL[i] = ListSOAL_VALID[indexSoal[i]] ;
        }

        foreach (List<string> lst in ARRAY_LIRIK_SOAL)
        {
            Debug.Log(string.Join(", ", lst.ToArray()));
        }
        GameAction.TRY_COUNT = 0; 
        showSoal();
        
    }

    public static string UppercaseWords(string value)
    {
        char[] array = value.ToCharArray(); 
        if (array.Length >= 1)
        {
            if (char.IsLower(array[0]))
            {
                array[0] = char.ToUpper(array[0]);
            }
        } 
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i - 1] == ' ')
            {
                if (char.IsLower(array[i]))
                {
                    array[i] = char.ToUpper(array[i]);
                }
            }
        }
        return new string(array);
    }
    public void backToPilih()
    {
        SceneManager.LoadScene("PilihLagu");
    }

    public void ulangiGame()
    {

        if (GameAction.MODE_GAME == 0)
        {
            GameAction.resetSetting();
            GameAction.INDEX_PILIHAN = 0;


        }
        Start();

        GameAction.TRY_COUNT = 0;
        GameAction.SCORES = 0;
        GameAction.TRUE_ANS = 0;
        GameAction.CURR_NOMER = 0;



        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void over()
    {
        GameAction.TEXT_SOAL = "PERMAINAN BERAKHIR..";
        Txt_SCORES.text = "Nilai : " + GameAction.SCORES.ToString();
        PLAYERs.SetActive(false);
        PANEL_OVER.SetActive(true);
        PANEL_PLAY.SetActive(false);
    }
    public void showSoal()
    {
        if (GameAction.CURR_NOMER >= GameAction.JML_SOAL[GameAction.GAME_LEVEL])
        {
            over();
            return;

        }
        GameAction.TRUE_ANS = 0;
        GameAction.KATA_JAWAB = new List<string>();
        GameAction.ARRAY_SOAL = new List<string>();
        GameAction.KATA_SOAL = new List<string>();
        GameAction.ARRAY_BENAR = new List<string>();
        GameAction.TEXT_BENAR = string.Join(" ", ARRAY_LIRIK_SOAL[GameAction.CURR_NOMER].ToArray()); 

        int i = 0;
        int[] indexKata = new int[ARRAY_LIRIK_SOAL[GameAction.CURR_NOMER].Count];

        foreach ( string  strs in ARRAY_LIRIK_SOAL[GameAction.CURR_NOMER])
        {
            GameAction.ARRAY_BENAR.Add(strs);
            GameAction.KATA_SOAL.Add(strs);
            indexKata[i] = i;
            i++;
        }

        printArray(indexKata);
        indexKata = Shuffle(indexKata);
        printArray(indexKata);

        for (i = 0; i < GameAction.ITEM_LEVEL[GameAction.GAME_LEVEL]; i++)
        {
            GameAction.ARRAY_SOAL.Add(ARRAY_LIRIK_SOAL[GameAction.CURR_NOMER][indexKata[i]]);
            GameAction.KATA_SOAL[indexKata[i]] = " <?> ";
        }

        i = 0;
        indexKata = new int[ARRAY_KATA.Count];
        foreach ( string  strs in ARRAY_KATA )
        { 
            indexKata[i] = i;
            i++;
        }

        indexKata = Shuffle(indexKata);

        for (i = 0; i < Txt_JAWABAN.Length; i++)
        { 
            Txt_JAWABAN[i].text = ARRAY_KATA[indexKata[i]];
        }
        i = 0;
        indexKata = new int[Txt_JAWABAN.Length ];
        for (i = 0; i < Txt_JAWABAN.Length;i++ )
        {
            indexKata[i] = i; 
        }


        indexKata = Shuffle(indexKata);

        for (i = 0; i < GameAction.ITEM_LEVEL[GameAction.GAME_LEVEL]; i++)
        { 
            Txt_JAWABAN[indexKata[i]].text = GameAction.ARRAY_SOAL[i];
        }
        for (  i = 0; i < Txt_JAWABAN.Length; i++)
        {
            Txt_JAWABAN[i].gameObject.SetActive(true);
        }
        //ARRAY_KATA

        Debug.Log(string.Join(" ", GameAction.ARRAY_SOAL));

        string strFix = string.Join(" ", GameAction.KATA_SOAL.ToArray());
        strFix = strFix.ToLower();
        strFix = UppercaseWords(strFix);

        GameAction.TEXT_SOAL = strFix;

    }


    public void printArray(int[] a)
    {
        string str = "";
        foreach (int x in a)
        {
            str += x.ToString() + " ";
        }
      //  Debug.Log(str);
    }

    public int[] Shuffle(int[] a)
    { 
        for (int i = a.Length - 1; i > 0; i--)
        { 
            int rnd = Random.Range(0, i);
            int temp = a[i]; 
            a[i] = a[rnd];
            a[rnd] = temp;
        }

        return a;
    }
    // Update is called once per frame
    float timeNow = 0.0f;
    void Update()
    {

        if (GameAction.TRY_COUNT >= 3)
        {
            over();
            return;
        }
        Txt_SOAL.text = GameAction.TEXT_SOAL;
        if (GameAction.GAME_STATUS)
        {
            GameAction.TEXT_SOAL = GameAction.TEXT_BENAR;
             
            for (int i = 0; i < Txt_JAWABAN.Length; i++)
            {
                Txt_JAWABAN[i].text = ("");
            }
            timeNow = Time.fixedDeltaTime+150;

            GameAction.GAME_STATUS = false;
        }
        if (timeNow > 0.0f)
        {
            timeNow--;
            if (timeNow <= 0.0f)
            {
                GameAction.CURR_NOMER++;
                if (GameAction.CURR_NOMER <  GameAction.JML_SOAL[GameAction.GAME_LEVEL])
                {
                    showSoal();
                }
                else
                {
                    if (GameAction.MODE_GAME == 0)
                    {
                        GameAction.resetSetting();
                        GameAction.INDEX_PILIHAN++;
                        if (GameAction.INDEX_PILIHAN < GameAction.LIRIK_LAGU.Length)
                        {
                            GameAction.LAGU_PILIHAN = GameAction.JUDUL_LAGU[GameAction.INDEX_PILIHAN];
                            Start();
                            showSoal();
                        }
                        else
                        {
                            over();
                        }
                    }
                    else
                    {
                        over();
                    }
     
                }
            }
           // Debug.Log(timeNow);
        }
    }
}

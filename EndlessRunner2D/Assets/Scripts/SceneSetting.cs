using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSetting : MonoBehaviour
{
    public void ChangeScene(string namaScene){
        SceneManager.LoadScene(namaScene);
    }

    public void Keluar(){
        Application.Quit();
    }
}

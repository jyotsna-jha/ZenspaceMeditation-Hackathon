using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtohome : MonoBehaviour
{
    public void GoToSceneOne(){
        SceneManager.LoadScene("home-screen");
    }
}

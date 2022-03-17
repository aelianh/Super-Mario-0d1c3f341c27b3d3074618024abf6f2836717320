using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadLVL0()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadLVL1()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLVL2()
    {
        SceneManager.LoadScene(2);
    }
}

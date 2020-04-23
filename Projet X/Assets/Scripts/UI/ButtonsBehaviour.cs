using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start_The_Game()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit_The_Game()
    {
        Application.Quit();
    }

    public void Parametre_Size()
    {
        
    }

    public void Parametre_Sound()
    {
        
    }
    //Adrien Lorge
}

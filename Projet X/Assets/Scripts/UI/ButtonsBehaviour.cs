using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//ADRIEN LORGE
public class ButtonsBehaviour : MonoBehaviour
{

    public void Quit_The_Game()
    {
        Application.Quit();
    }

    public void Play1()
    {
        SceneManager.LoadScene("Game");
    }

    public void Play2()
    {
        //Même chose que 1 mais deux joueurs.TODO
    }

    public void Parametre_Sound()
    {
        
    }
    
}

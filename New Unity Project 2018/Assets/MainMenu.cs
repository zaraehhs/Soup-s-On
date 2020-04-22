using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Playgame() {
        global.recipeChoice = 0; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

     public void quit() {
        Application.Quit(); 
    }

    public void Playagain() {
        SceneManager.LoadScene("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class recipeSelect : MonoBehaviour
{
    // Start is called before the first frame update

    public void sunriseSoup() {
        global.recipeChoice = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void tastyAndPasty() {
         global.recipeChoice = 2;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void twoVeggieSoup() {
        global.recipeChoice = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void zucchiniFellas(){
        global.recipeChoice = 11;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void mushroomMumbo() {
        global.recipeChoice = 21;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MeanAndGreen() {
        global.recipeChoice = 22;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}

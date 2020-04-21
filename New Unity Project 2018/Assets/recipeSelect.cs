using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class recipeSelect : MonoBehaviour
{
    // Start is called before the first frame update

//Easy Soups 
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

     public void SpicyCarrotSoup() {
        global.recipeChoice = 4;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

//Medium Soups 

    public void zucchiniFellas(){
        global.recipeChoice = 11;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void pizzaSoup(){
        global.recipeChoice = 12;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void soothingGinger(){
        global.recipeChoice = 13;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void salsaSoup(){
        global.recipeChoice = 14;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


//Hard
    public void mushroomMumbo() {
        global.recipeChoice = 21;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MeanAndGreen() {
        global.recipeChoice = 22;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
public void crunchyPepper(){
        global.recipeChoice = 23;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }public void redPotato(){
        global.recipeChoice = 24;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

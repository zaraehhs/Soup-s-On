using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    public GameObject recipetitleO;
    public Text recipeTitle;
    public Text foodText1;
    public Text foodText2;
    public Text foodText3;
    public int recipeChoice;
    public string food1Name;
    public string food2Name;
    public string food3Name;
    
    public int food1Tot;
    public int food2Tot;
    public int food3Tot;

    int wrongCount;
    public int tomatoCount;
    public int carrotCount;
    public int potatoCount;
    public int mushroomCount;
    // Start is called before the first frame update
    void Start()
    {
        
        recipeTitle = GameObject.Find("recipeTitle").GetComponent<Text>();
        foodText1 = GameObject.Find("foodText1").GetComponent<Text>();
        foodText2 = GameObject.Find("foodText2").GetComponent<Text>();
        foodText3 = GameObject.Find("foodText3").GetComponent<Text>();
        
        food1Name = null;
        food2Name = null;
        food3Name = null;


        wrongCount = 0;
        tomatoCount = 0;
        carrotCount = 0;
        
        recipeChoice = 1;
        
        if (recipeChoice == 1)
        {
            Debug.Log("recipe1 chosen");
            //recipetitleO.GetComponent<Text>().text = "Tomato and Carrot Soup";
            recipeTitle.text = "Tomato and Carrot Soup";
            food1Name = "tomato";
            food1Tot = 3;
            food2Name = "carrot";
            food2Tot = 2;
        }
        updateRecipeDisplay();
        //recipeDisplay = GameObject.Find("recipe").GetComponent<Text>();

        //scoreDisplay = GameObject.Find("score").GetComponent<Text>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    

    public void addCount(string food)
    {
        if (food == "tomato")
        {
            tomatoCount++;
        }
        if(food == "carrot")
        {
            carrotCount++;
        }
        if (food == "potato")
        {
            potatoCount++;
        }
        if (food == "mushroom")
        {
            mushroomCount++;
        }

        updateRecipeDisplay();
    }
    public void updateRecipeDisplay()
    {
        foodText1.text = food1Name + ": " + getCount(food1Name) + " / " + food1Tot;
        foodText2.text = food2Name + ": " + getCount(food2Name) + " / " + food2Tot;
        if (food3Name != null)
        {
            foodText3.text = food3Name + ": " + getCount(food3Name) + " / " + food3Tot;
        }
    }

    public int getCount(string food)
    {
        if (food == "tomato")
        {
            return tomatoCount;
        }
        if(food == "carrot")
        {
            return carrotCount;
        }
        if (food == "potato")
        {
            return potatoCount;
        }
        if (food == "mushroom")
        {
            return potatoCount;
        }
        return 0;
    }
}

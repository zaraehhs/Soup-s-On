using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    public GameObject recipetitle;
    public Text clockText;
    public Text recipeTitle;
    public Text foodText1;
    public Text foodText2;
    public Text foodText3;
    public Text foodText4;
    public Text messageText;
    public int recipeChoice;
    public string food1Name;
    public string food2Name;
    public string food3Name;
    public string food4Name;

    public int food1Tot;
    public int food2Tot;
    public int food3Tot;
    public int food4Tot;

    int wrongCount;
    public int tomatoCount;
    public int carrotCount;
    public int potatoCount;
    public int mushroomCount;

    public bool stoveOn = false;

    public float seconds, minutes;
    public float bonusSeconds;
    // Start is called before the first frame update
    void Start()
    {
        bonusSeconds = 0;
        clockText = GameObject.Find("clock").GetComponent<Text>();
        recipeTitle = GameObject.Find("recipeTitle").GetComponent<Text>();
        foodText1 = GameObject.Find("foodText1").GetComponent<Text>();
        foodText2 = GameObject.Find("foodText2").GetComponent<Text>();
        foodText3 = GameObject.Find("foodText3").GetComponent<Text>();
        foodText4 = GameObject.Find("foodText4").GetComponent<Text>();
        messageText = GameObject.Find("message").GetComponent<Text>();
        messageText.text = "Turn on the stove with right knob";
        //food4


        food1Name = "";
        food2Name = "";
        food3Name = "";
        food4Name = "";
        
        wrongCount = 0;
        tomatoCount = 0;
        carrotCount = 0;
        mushroomCount = 0;
        potatoCount = 0;
        
        recipeChoice = 1;

        if(recipeChoice == 1)
        {
            recipeTitle.text = "Custom Recipe";
            foodText1.text = "Put an Ingredient in the pot to start!";
            food1Name = "";
            food2Name = "";
            food3Name = "";
            food4Name = "";
            //food4
        }
        
        if (recipeChoice == 2)
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
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f) + bonusSeconds;
        if (seconds >= 60)
        {
            seconds -= 60;
            minutes += 1;
        }
        clockText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

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
        if(food != food1Name && food != food2Name && food != food3Name && food != food4Name)//food4
        {
            if (recipeChoice == 1)
            {
                addCustomFood(food);
            }
            else
            {
                messageText.text = "This recipe doesnt use " + food + "!";
                wrongCount++;
                //clock.GetComponent<timer>().addTime(gameObject.tag);
            }
            
        }
        
        
      
        updateRecipeDisplay();
    }
    public void updateRecipeDisplay()
    {
        if (recipeChoice == 1)
        {
            if (food1Name != "")
            {
                foodText1.text = food1Name + ": " + getCount(food1Name);
            }
            if (food2Name != "")
            {
                foodText2.text = food2Name + ": " + getCount(food2Name);
            }
            
           
            if (food3Name != "")
            {
                foodText3.text = food3Name + ": " + getCount(food3Name);
            }
            if (food4Name != "")
            {
                foodText4.text = food4Name + ": " + getCount(food4Name);
            }
        }
        else
        {
            foodText1.text = food1Name + ": " + getCount(food1Name) + " / " + food1Tot;
            foodText2.text = food2Name + ": " + getCount(food2Name) + " / " + food2Tot;
            if (food3Name != "")
            {
                foodText3.text = food3Name + ": " + getCount(food3Name) + " / " + food3Tot;
            }
            if (food4Name != "")
            {
                foodText4.text = food4Name + ": " + getCount(food4Name) + " / " + food4Tot;
            }
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

    public void addCustomFood(string food)
    {
        if(food1Name == "")
        {
            food1Name = food;
            return;
        }else if(food2Name == "")
        {
            food2Name = food;
            return;
        }else if(food3Name == "")
        {
            food3Name = food;
            return;
        }
        else if (food4Name == "")
        {
            food4Name = food;
            messageText.text = "Maximum ingredients reached";
            return;
        }
        else
        {
            Debug.Log("maximum custom foods already");
        }

    }
    void addTime()
    {
        bonusSeconds += 10;
    }
}

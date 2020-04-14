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
    public int zucchiniCount;
    public int onionCount;
    public int cucumberCount;
    public int garlicCount;
    public int gingerCount;
    public int pepperCount;

    

    public float seconds, minutes;
    public float bonusSeconds;

    
    public bool stoveOn;
    // Start is called before the first frame update
    void Start()
    {
        stoveOn = false; 
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
        zucchiniCount = 0;
        onionCount = 0;
        cucumberCount = 0;
        garlicCount = 0;
        gingerCount = 0;
        pepperCount = 0;

    //recipeChoice = 1;
        recipeChoice = global.recipeChoice;
        if (recipeChoice == 0)
        {
            recipeTitle.text = "Custom Recipe";
            foodText1.text = "Put an Ingredient in the pot to start!";
            food1Name = "";
            food2Name = "";
            food3Name = "";
            food4Name = "";
            //food4
        }
        //easy
        if (recipeChoice == 1)
        {
            Debug.Log("recipe1 chosen");
            //recipetitleO.GetComponent<Text>().text = "Tomato and Carrot Soup";
            recipeTitle.text = "Sunrise Soup";
            food1Name = "tomato";
            food1Tot = 3;
            food2Name = "carrot";
            food2Tot = 3;
        }
        if (recipeChoice == 2)
        {
            recipeTitle.text = "Tasty and Pasty";
            food1Name = "potato";
            food1Tot = 3;
            food2Name = "broccoli";
            food2Tot = 3;
        }
        if (recipeChoice == 3)
        {
            recipeTitle.text = "Two Veggie Soup";
            food1Name = "carrot";
            food1Tot = 3;
            food2Name = "broccoli";
            food2Tot = 3;
        }
        //med
        if(recipeChoice == 11)
        {
            recipeTitle.text = "Zucchini and the fellas";
            food1Name = "zucchini";
            food1Tot = 2;
            food2Name = "onion";
            food2Tot = 2;
            food3Name = "potato";
            food3Tot = 4;
            
        }
        //hard
        if (recipeChoice == 21)
        {
            recipeTitle.text = "Mushroom Mumbo";
            food1Name = "mushroom";
            food1Tot = 4;
            food2Name = "tomato";
            food2Tot = 3;
            food3Name = "garlic";
            food3Tot = 3;
            food3Name = "onion";
            food3Tot = 2;
        }
        if (recipeChoice == 22)
        {
            recipeTitle.text = "Mean and Green";
            food1Name = "cucumber";
            food1Tot = 3;
            food2Name = "zucchini";
            food2Tot = 2;
            food3Name = "broccoli";
            food3Tot = 3;
            
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

        if (!stoveOn)
        {
            messageText.text = "Turn the stove on with the right knob";
        }
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
        if (food == "cucumber")
        {
            cucumberCount++;
        }
        if (food == "garlic")
        {
            garlicCount++;
        }
        if (food == "onion")
        {
            onionCount++;
        }
        if (food == "cucumber")
        {
            cucumberCount++;
        }
        if (food == "zucchini")
        {
            zucchiniCount++;
        }
        if (food == "ginger")
        {
            gingerCount++;
        }
        if (food == "pepper")
        {
            pepperCount++;
        }
        if (food != food1Name && food != food2Name && food != food3Name && food != food4Name)//food4
        {
            if (recipeChoice == 0)
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
        if (recipeChoice == 0)
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
        if (food == "cucumber")
        {
            return cucumberCount;
        }
        if (food == "garlic")
        {
            return garlicCount;
        }
        if (food == "onion")
        {
            return onionCount;
        }
        if (food == "cucumber")
        {
            return cucumberCount;
        }
        if (food == "zucchini")
        {
            return zucchiniCount;
        }
        if (food == "ginger")
        {
            return gingerCount;
        }
        if (food == "pepper")
        {
            return pepperCount;
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
            messageText.text = "";
            return;
        }
        else
        {
            messageText.text = "Added " + food + " to Soup";
            //Debug.Log("maximum custom foods already");
        }

    }
    void addTime()
    {
        bonusSeconds += 10;
    }

    public void setMessage(string message)
    {
        messageText.text = message;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private int banana;
    public float cooldown;
    private float counter;
    public Text BananaText;
    public List<string> Names = new List<string>();
    public List<int> Numbers = new List<int>();
    public List<int> Costs= new List<int>();
    public List<int> Cooldowns = new List<int>();
    public List<int> Rates = new List<int>();

    public Text CookerButtonText;
    public Text OvenButtonText;
    public Text BakeryButtonText;

    

    private List<float> Counters = new List<float> { 0, 0, 0 };
    private int buff;
    


    
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        banana = 0;
        BananaText.text = " 0";

        /*
        int result = 0;
        result = 5 + 2;
        Debug.Log(result);

        for(int i = 0; i < 20; i++){
            result = Increment(result);
            
        }

        result = Add(result,5);        
        result = Add(result,5);
        result++;
        result++;
        Debug.Log(result);
        result = Add(result,3);
        */
    }

    public void ManualIncrement()
    {
        banana = Increment(1);
    }

    public void buyCooker(){
        if (banana >= Costs[0]){
            banana -= Costs[0];
            UpdateBananaDisplay(banana);
            Numbers[0]++;
            CookerButtonText.text = Names [0] + "  " + Numbers[0].ToString();
        }
    }
    public void buyOvern(){
        if (banana >= Costs[1]){
            banana -= Costs[1];
            UpdateBananaDisplay(banana);
            Numbers[1]++;
            OvenButtonText.text = Names [1] + "  " + Numbers[1].ToString();
        }
    }
    public void buyBakery(){
        if (banana >= Costs[2]){
            banana -= Costs[2];
            UpdateBananaDisplay(banana);
            Numbers[2]++;
            BakeryButtonText.text = Names [2] + "  " + Numbers[2].ToString();
        }
    }
   
    public int Increment(int value) 
    {
        int total = banana + value;
        UpdateBananaDisplay(total);
       
        return total;
    
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        Counters[0] += Time.deltaTime;
        Counters[1] += Time.deltaTime;
        Counters[2] += Time.deltaTime;


        if (counter >= cooldown) {
            banana = Increment(1);
            counter -= cooldown;

        }

        if (Counters[0] >= Cooldowns[0])
        {
            banana = Increment(Rates[0]*Numbers[0]);
            Counters[0] -= Cooldowns[0];
        }
         if (Counters[1] >= Cooldowns[1])
        {
            banana = Increment(Rates[1]*Numbers[1]);
            Counters[1] -= Cooldowns[1];
        }
         if (Counters[2] >= Cooldowns[2])
        {
            banana = Increment(Rates[2]*Numbers[2]);
            Counters[2] -= Cooldowns[2];
        }
       //if (banana=1000*a
     
    }

    private void UpdateBananaDisplay(int newNumber)
    {
        BananaText.text = "  " + banana.ToString();

    }
}

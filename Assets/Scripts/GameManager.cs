using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int o2Generated = 0;

    public TextMeshProUGUI o2Text;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multButtonText;
    public TextMeshProUGUI multText;
    public TextMeshProUGUI autoclickButtonText;
    public TextMeshProUGUI autoclickText;
    public TextMeshProUGUI passiveButtonText;
    public TextMeshProUGUI passiveText;
    public TextMeshProUGUI capacityButtonText;
    public TextMeshProUGUI capacityText;
    public Slider o2Slider;
    public ParticleSystem o2Particle;

    float o2 = 100;
    int capacity = 100;
    int clickMult = 1;
    int autoclick = 0;
    int passive = 0;
    int timerIncrease = 1;

    public void Start()
    {
        multButtonText.text = multCost().ToString();
        multText.text = $"Pump({clickMult}):";
        autoclickButtonText.text = autoclickCost().ToString();
        autoclickText.text = $"Auto pump({autoclick}):";
        passiveButtonText.text = passiveCost().ToString();
        passiveText.text = $"Passive pump({passive}):";
        capacityButtonText.text = (capacity / 2).ToString();
        capacityText.text = $"Capacity({capacity}):";
        InvokeRepeating("EverySecond", 1, 1);
        InvokeRepeating("Every10Seconds", 10, 10);
    }
    public void Update()
    {
        o2 -= Time.deltaTime * timerIncrease;
        if (o2 < 0)
            SceneManager.LoadScene("Lose");
        O2Update();
    }

    public void EverySecond()
    {
        for (int i = 0; i < autoclick; i++)
        {
            AddO2(clickMult);
        }
        //I know i could do AddO2(clickMult * autoclick) and it would be objectively better, but this feels more true to what I want the mechanic to be. It actually simulates the clicking.;
        AddO2(passive);
        O2Update();
    }
    public void Every10Seconds()
    {
        timerIncrease += 1;
    }
    public void MainButtonClicked()
    {
        o2Particle.Play();
        AddO2(clickMult);
        O2Update();
    }
    public void MultButtonClicked()
    {
        if (o2 > multCost())
        {
            o2 -= multCost();
            clickMult += 1;
            multButtonText.text = multCost().ToString();
            multText.text = $"Pump({clickMult}):";
        }
    }
    public void AutoclickButtonClicked()
    {
        if (o2 > autoclickCost())
        {
            o2 -= autoclickCost();
            autoclick += 1;
            autoclickButtonText.text = autoclickCost().ToString();
            autoclickText.text = $"Auto pump({autoclick}):";
        }
    }
    public void PassiveButtonClicked()
    {
        if (o2 > passiveCost())
        {
            o2 -= passiveCost();
            passive += 1;
            passiveButtonText.text = passiveCost().ToString();
            passiveText.text = $"Passive pump({passive}):";
        }
    }
    public void CapacityButtonClicked()
    {
        if (o2 > capacity / 2)
        {
            o2 -= capacity / 2;
            capacity *= 2;
            o2Slider.maxValue = capacity;
            capacityButtonText.text = (capacity / 2).ToString();
            capacityText.text = $"Capacity({capacity}):";
        }
    }
    void AddO2(int o2added)
    {
        if (o2 + o2added > capacity)
        {
            o2Generated += Mathf.RoundToInt(capacity - o2);
            o2 = capacity;
        }
        else
        {
            o2 += o2added;
            o2Generated += o2added;
        }
        scoreText.text = $"score: {o2Generated}";
    }
    int multCost()
    {
        return Mathf.RoundToInt(Mathf.Pow(clickMult * 5, 2));
    }
    int autoclickCost()
    {
        return Mathf.RoundToInt(Mathf.Pow((autoclick + 1) * 10, 2));
    }
    int passiveCost()
    {
        return Mathf.RoundToInt(Mathf.Pow((passive + 1) * 3, 2));
    }
    void O2Update()
    {
        o2Text.text = "O2:" + Mathf.Round(o2).ToString();
        o2Slider.value = o2;
    }
}

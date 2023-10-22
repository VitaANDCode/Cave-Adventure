using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] ores;
    public GameObject StoneOre;
    public GameObject IronOre;
    public GameObject RubyOre;
    public GameObject EmeraldOre;
    public GameObject DiamondOre;

    public int stoneOreCount;
    public int ironOreCount;
    public int rubyOreCount;
    public int emeraldOreCount;
    public int diamondOreCount;
    public int gearWheelCount;

    public Text stoneOreText;
    public Text ironOreText;
    public Text rubyOreText;
    public Text emeraldOreText;
    public Text diamondOreText;
    public Text gearWheelText;


    private void Start()
    {
        stoneOreCount = 0;
        ironOreCount = 0;
        rubyOreCount = 0;
        emeraldOreCount = 0;
        diamondOreCount = 0;
        gearWheelCount = 0;

        ores = new GameObject[5];
        ores[0] = StoneOre;
        ores[1] = IronOre;
        ores[2] = RubyOre;
        ores[3] = EmeraldOre;
        ores[4] = DiamondOre;
    }

    private void Update()
    {
        stoneOreText.text = stoneOreCount.ToString();
        ironOreText.text = ironOreCount.ToString();
        rubyOreText.text = rubyOreCount.ToString();
        emeraldOreText.text = emeraldOreCount.ToString();
        diamondOreText.text = diamondOreCount.ToString();
        gearWheelText.text = gearWheelCount.ToString();
    }
}

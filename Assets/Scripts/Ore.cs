using UnityEngine;
using UnityEngine.UI;

public class Ore : MonoBehaviour
{
    public GameManager gameManager;

    public AudioManager audioManager;
    public AudioClip digOre;
    public AudioClip getOre;

    public ParticleSystem particleSystem;

    public Slider slider;

    public GameObject gameZone;

    public int integrity;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
        gameZone = GameObject.Find("GameZone");

        particleSystem.Stop();

        if (gameObject.tag == "StoneOre")
        {
            integrity = 10;
        }
        else if (gameObject.tag == "IronOre")
        {
            integrity = 15;
        }
        else if (gameObject.tag == "RubyOre")
        {
            integrity = 20;
        }
        else if (gameObject.tag == "EmeraldOre")
        {
            integrity = 25;
        }
        else if (gameObject.tag == "DiamondOre")
        {
            integrity = 30;
        }

        slider.maxValue = integrity;
    }

    private void Update()
    {
        slider.value = integrity;

        if (integrity <= 0) 
        {
            if (gameObject.tag == "StoneOre")
            {
                gameManager.stoneOreCount++;
            }
            else if (gameObject.tag == "IronOre")
            {
                gameManager.ironOreCount++;
            }
            else if (gameObject.tag == "RubyOre")
            {
                gameManager.rubyOreCount++;
            }
            else if (gameObject.tag == "EmeraldOre")
            {
                gameManager.emeraldOreCount++;
            }
            else if (gameObject.tag == "DiamondOre")
            {
                gameManager.diamondOreCount++;
            }

            audioManager.PlaySound(getOre);

            Destroy(gameObject);
            GenerateNewOre();
        }
    }

    public void OnPhotoClick()
    {
        integrity -= 1;

        audioManager.PlaySound(digOre);

        particleSystem.Play();
    }

    public void GenerateNewOre()
    {
        int randomOreIndex = Random.Range(0, gameManager.ores.Length);

        GameObject objectPrefab = null;

        int oreChance = Random.Range(1, 101);

        if (oreChance <= 5)
        {
            objectPrefab = gameManager.ores[4];
        }
        else if (oreChance <= 15)
        {
            objectPrefab = gameManager.ores[3];
        }
        else if (oreChance <= 30)
        {
            objectPrefab = gameManager.ores[2];
        }
        else if (oreChance <= 55)
        {
            objectPrefab = gameManager.ores[1];
        }
        else 
        {
            objectPrefab = gameManager.ores[0];
        }

        GameObject newObject = Instantiate(objectPrefab, gameZone.transform);

        newObject.transform.SetAsLastSibling();
    }
}

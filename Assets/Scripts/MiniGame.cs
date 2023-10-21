using UnityEngine;
using UnityEngine.UI;


public class MiniGame : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject diamondHuntBtn;
    public GameObject goldenLadder;
    public GameObject roulettMultiply;

    [SerializeField]
    private float interval = 60f;

    private void Start()
    {
        InvokeRepeating("ChoiceMiniGame", interval, interval);
    }

    public void ChoiceMiniGame()
    {
        int randomChoice = Random.Range(0, 3);

        if (randomChoice == 0)
        {
            diamondHuntBtn.SetActive(true);
        }
        else if (randomChoice == 1)
        {
            goldenLadder.SetActive(true);
        }
        else
        {
            roulettMultiply.SetActive(true);
        }
    }
}

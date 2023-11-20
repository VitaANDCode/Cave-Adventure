using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject MapPanel;

    public GameObject mainCanvas;

    public int indexBoss;
    public int bossHp;

    public GameObject[] boss;
    public Image[] bossLocation;

    public Slider slider;

    [SerializeField]
    public float interval = 1f;

    public int timeBoss;
    public int seconds;
    public int minutes;

    public Text timerText;

    private void Start()
    {
        int indexBoss = MapPanel.GetComponent<BossMap>().indexBoss;

        if (indexBoss == 1)
        {
            bossHp = 100;
            timeBoss = 60;
        }

        slider.maxValue = bossHp;

        boss[indexBoss - 1].gameObject.SetActive(true);
        bossLocation[indexBoss - 1].gameObject.SetActive(true);

        InvokeRepeating("Timer", interval, interval);
    }

    private void Update()
    {
        minutes = timeBoss / 60;
        seconds = timeBoss % 60;

        string time = (minutes < 10 ? "0" + minutes.ToString() : minutes.ToString()) + ":";
        time += seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();

        timerText.text = time;

        if (bossHp <= 0)
        {
            gameObject.SetActive(false);
            mainCanvas.SetActive(true);
        }

        slider.value = bossHp;
    }

    public void HitBoss()
    {
        bossHp -= gameManager.clickPower;
    }

    public void Timer()
    {
        timeBoss--;
    }
}

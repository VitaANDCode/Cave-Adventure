using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondHunt : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject panel;
    public GameObject btn;

    public GameObject diamond;
    public GameObject bomb;

    public Text diamondText;

    public int[] gamePlace = new int[25];

    public int diamondCount;

    List<GameObject> elements = new List<GameObject>();

    public void StartGame()
    {
        // ��������� ������ ����-���� � ���������� ������
        panel.SetActive(true);
        btn.SetActive(false);

        // ���������� ��� ������
        for (int i = 1; i <= 25; i++)
        {
            GameObject.Find(i.ToString()).GetComponent<Button>().enabled = true;
        }

        // �������� ������ ���������, ������� �������� � ������� ����
        foreach (GameObject elem in elements)
        {
            Destroy(elem);
        }

        diamondCount = 0;

        // ������ 1 � 0 : 1 - �����, 0 - �����
        // ��������� �������
        for (int i = 0; i < gamePlace.Length; i++)
        {
            gamePlace[i] = 1;
        }

        // ������� ��� ����
        int[] indexBombs = new int[5];
        indexBombs[0] = Random.Range(0, 5);
        indexBombs[1] = Random.Range(5, 10);
        indexBombs[2] = Random.Range(10, 15);
        indexBombs[3] = Random.Range(15, 20);
        indexBombs[4] = Random.Range(20, 25);

        // ���������� ������� ������ (�������)
        for (int i = 0; i < gamePlace.Length; i++)
        {
            for (int j = 0; j < indexBombs.Length; j++)
            {
                if (i == indexBombs[j])
                {
                    gamePlace[i] = 0;
                }
            }
        }
    }

    private void Update()
    {
        // ���������� ������ ���-�� �������
        diamondText.text = diamondCount.ToString();
    }

    public void OnButtonClick(Button button)
    {
        string id = button.name;
        
        // �������� ������� ������ ����� ��� �����
        if (gamePlace[int.Parse(id) - 1] == 1) // �����
        {
            diamondCount++;

            GameObject newObject = Instantiate(diamond, button.transform);

            newObject.transform.SetAsLastSibling();

            elements.Add(newObject);

            button.enabled = false;
        }
        else                                    // �����
        {
            diamondCount = 0;

            GameObject newObject = Instantiate(bomb, button.transform);

            newObject.transform.SetAsLastSibling();

            elements.Add(newObject);

            for (int i = 1; i <= gamePlace.Length; i++)
            {
                 GameObject.Find(i.ToString()).GetComponent<Button>().enabled = false;
            }
        }
    }

    public void getAward()
    {
        // ��������� ������� � �������� ������
        gameManager.diamondOreCount += diamondCount;
        panel.SetActive(false);
    }
}

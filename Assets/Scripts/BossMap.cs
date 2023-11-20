using UnityEngine;
using UnityEngine.UI;

public class BossMap : MonoBehaviour
{
    public Canvas canvas;
    public Canvas[] bossCanvas;

    public int indexBoss;

    public void OpenMap() { gameObject.SetActive(true); }

    public void CloseMap() { gameObject.SetActive(false); }

    public void OnButtonClick(Button button)
    {
        indexBoss = int.Parse(button.name[button.name.Length - 1].ToString());

        if (indexBoss == 1)
        {
            bossCanvas[indexBoss - 1].gameObject.SetActive(true);
        }

        canvas.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}

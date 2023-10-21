using UnityEngine;

public class BossMap : MonoBehaviour
{
    public GameObject panel;

    public void OpenMap() { panel.SetActive(true); }

    public void CloseMap() { panel.SetActive(false); }
}

using UnityEngine;

public class UpgradeShop : MonoBehaviour
{
    public GameManager gameManager;

    public void Exchange()
    {
        if (gameManager.ironOreCount >= 5)
        {
            gameManager.gearWheelCount += 1;
            gameManager.ironOreCount -= 5;
        }
    }
}

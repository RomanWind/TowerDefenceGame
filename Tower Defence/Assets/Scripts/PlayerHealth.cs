using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image[] healthImages = new Image[3];
    private int playerhealth = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DealDamageToPlayer();
    }

    private void DealDamageToPlayer()
    {
        if (playerhealth > 0)
        {
            healthImages[playerhealth].enabled = false;
            playerhealth -= 1;
        }
        else
        {
            Debug.Log("Level Failed!");
        }
    }
}

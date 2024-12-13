using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlaytimeUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI ammoText;

    //this script will only work with the foam launcher rn
    [SerializeField] Foam_Launcher gun;

    private void SetScoreText()
    {
        scoreText.text = "Score: " + ScoreCalculation.runScore.ToString();
    }

    private void SetAmmoText()
    {
        ammoText.text = "Ammo: " + gun.getAmmoCount().ToString() + "/" + gun.getMaxAmmo().ToString();
    }

    void Update()
    {
        SetScoreText();
        SetAmmoText();
    }
}

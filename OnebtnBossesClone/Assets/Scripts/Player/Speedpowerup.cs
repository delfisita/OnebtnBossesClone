using UnityEngine;
using UnityEngine.UI;

public class Speedpowerup : MovimientoPlayer
{
    public float maxCharge = 100f;
    public float speedMultiplier = 2f;
    public float rechargeRate = 10f;
    public float drainRate = 20f;
    public Image chargeUI;

    private float currentCharge;
    private bool isPowerUpActive = false;
    private bool canChangeDirection = true;
    public bool isInvulnerable = false;

    void Start()
    {
        currentCharge = maxCharge;
    }

    protected override void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && currentCharge > 0 && !isPowerUpActive)
        {
            ActivatePowerUp();
        }

        
        if (canChangeDirection && Input.GetKeyDown(KeyCode.Space))
        {
            speed = -speed;
        }

        base.Update(); 

        
        if (isPowerUpActive)
        {
            DrainCharge();
        }
        else
        {
            RechargeCharge();
        }

        UpdateChargeUI();
    }

    void ActivatePowerUp()
    {
        isPowerUpActive = true;
        canChangeDirection = false; 
        speed *= speedMultiplier;
        isInvulnerable = true; 
    }

    void DeactivatePowerUp()
    {
        isPowerUpActive = false;
        canChangeDirection = true;
        speed /= speedMultiplier; 
        isInvulnerable = false; 
    }

    void DrainCharge()
    {
        currentCharge -= drainRate * Time.deltaTime;

        if (currentCharge <= 0)
        {
            currentCharge = 0;
            DeactivatePowerUp();
        }
    }

    void RechargeCharge()
    {
        if (currentCharge < maxCharge)
        {
            currentCharge += rechargeRate * Time.deltaTime;
            if (currentCharge > maxCharge)
                currentCharge = maxCharge;
        }
    }

    void UpdateChargeUI()
    {
        if (chargeUI != null)
        {
            chargeUI.fillAmount = currentCharge / maxCharge;
         }
    } 
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazineBehaviour
{
    private struct UpdateUI
    {
        public float foo;
        public float panda;
    }

    private UpdateUI updateUI;
    public float maxMagSize;
    public float currentAmmoInMag;
    public float currentAmountOfBullets;
   
    
    public magazineBehaviour(float _magSize, float _currentAmmoInMag,float _amountOfBullets)
    {
        maxMagSize = _magSize;
        currentAmmoInMag = _currentAmmoInMag;
        currentAmountOfBullets = _amountOfBullets;
        updateUI.foo = _magSize;
    }

    public bool HasAmmoInMag()
    {
        return currentAmmoInMag > 0;
    }
    public void Shot()
    {
        Debug.Log(currentAmmoInMag);
        currentAmmoInMag -= 1;
        currentAmountOfBullets -= 1;
        currentAmmoInMag = Mathf.Clamp(currentAmmoInMag, 0, maxMagSize);
    }
    
    public void Reload()
    {
        if (currentAmountOfBullets >= maxMagSize)
        {
            currentAmmoInMag = maxMagSize;
            currentAmountOfBullets -= maxMagSize;

        }
        if (currentAmountOfBullets < maxMagSize)
        {
            currentAmmoInMag = currentAmountOfBullets;
        }
    }



}

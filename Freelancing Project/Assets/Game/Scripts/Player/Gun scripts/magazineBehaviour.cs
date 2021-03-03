using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazineBehaviour
{
    private struct UpdateUI
    {
        public float maxMagSize;
        public float currentAmmoInMag;
        public float currentAmountOfBullets;
    }

    private UpdateUI updateUI;
    
    public magazineBehaviour(float _magSize, float _currentAmmoInMag,float _amountOfBullets)
    {
        updateUI.maxMagSize = _magSize;
        updateUI.currentAmmoInMag = _currentAmmoInMag;
        updateUI.currentAmountOfBullets = _amountOfBullets;
    }

    public bool HasAmmoInMag()
    {
        return updateUI.currentAmmoInMag > 0;
    }
    public void Shot()
    {
        Debug.Log(updateUI.currentAmmoInMag);
        updateUI.currentAmmoInMag -= 1;
        updateUI.currentAmountOfBullets -= 1;
        updateUI.currentAmmoInMag = Mathf.Clamp(updateUI.currentAmmoInMag, 0, updateUI.maxMagSize);
    }
    
    public void Reload()
    {
        if (updateUI.currentAmountOfBullets >= updateUI.maxMagSize)
        {
            updateUI.currentAmmoInMag = updateUI.maxMagSize;
            updateUI.currentAmountOfBullets -= updateUI.maxMagSize;

        }
        if (updateUI.currentAmountOfBullets < updateUI.maxMagSize)
        {
            updateUI.currentAmmoInMag = updateUI.currentAmountOfBullets;
        }
    }



}

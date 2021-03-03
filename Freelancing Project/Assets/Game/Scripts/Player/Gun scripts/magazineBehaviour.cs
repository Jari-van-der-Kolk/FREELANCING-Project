using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazineBehaviour
{
    public float maxMagSize;
    public float currentAmmoInMag;
    public float currentAmountOfBullets;
    private float extract;
    
    public magazineBehaviour(float _maxAmmo, float _currentAmmoInMag,float _amountOfBullets)
    {
        maxMagSize = _maxAmmo;
        currentAmmoInMag = _currentAmmoInMag;
        currentAmountOfBullets = _amountOfBullets;
    }

    public bool HasAmmoInMag()
    {
        return currentAmmoInMag > 0;
    }
    public void Shot()
    {
        currentAmmoInMag -= 1;
        currentAmountOfBullets -= 1;
        currentAmmoInMag = Mathf.Clamp(currentAmmoInMag, 0, maxMagSize);
    }
    
    public void Reload()
    {
        
    }


}

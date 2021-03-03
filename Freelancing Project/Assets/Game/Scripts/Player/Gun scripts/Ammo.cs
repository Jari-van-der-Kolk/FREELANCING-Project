using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo
{
    public float maxMagSize;
    public float currentAmmoInMag;
    
    public Ammo(float _maxAmmo, float _currentAmmoInMag)
    {
        maxMagSize = _maxAmmo;
        currentAmmoInMag = _currentAmmoInMag;
    }

    public bool HasAmmoInMag()
    {
        return currentAmmoInMag <= 0;
    }

}

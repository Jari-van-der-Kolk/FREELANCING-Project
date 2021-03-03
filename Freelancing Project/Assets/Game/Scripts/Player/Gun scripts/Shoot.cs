using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] private FloatReference damage;
    [SerializeField] private FloatReference magezineSize;
    [SerializeField] private FloatReference currentAmmoInMag;
    [SerializeField] private FloatReference amountOfBullets;
    [SerializeField] private FloatReference shootingSpeed;
    private Timer timer = new Timer();
    private magazineBehaviour ammo;

    private IRayProvider rayProvider;
    private ISelector selector;



    void Start()
    {
        ammo = new magazineBehaviour(magezineSize.Value, currentAmmoInMag.Value, amountOfBullets.Value);
        rayProvider = GetComponent<IRayProvider>(); //dit called het midden van het scherm
        selector = GetComponent<ISelector>(); // maakt de ray die ervoor zorgt dat je de enemy raakt
    }

    void Update()
    {
        Shooting();
    }
    
    void Shooting()
    {
        timer.GetDeltaTime(Time.deltaTime);
        timer.TimeMultiplication(shootingSpeed.Value);

        if (Input.GetMouseButton(0) && timer.time > 1f && ammo.HasAmmoInMag())
        {
            ammo.Shot();
            Debug.Log(ammo.HasAmmoInMag());

            selector.Check(rayProvider.CreateRay());

            if (selector.GetSelection() != null)
                selector.GetSelection().GetComponent<Idamageable>().GetDamaged(damage.Value);

            Debug.Log(name + "has shot");
            timer.ResetTime(0);
        }
        else if (!ammo.HasAmmoInMag())
        {
            return;
        }
    }
}

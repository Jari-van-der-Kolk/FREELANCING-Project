using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] private FloatReference damage;
    [SerializeField] private FloatReference magezineSize;
    [SerializeField] private FloatReference ammoInMag;
    [SerializeField] private FloatReference amountOfBullets;
    [SerializeField] private FloatReference shootingSpeed;
    private Timer timer = new Timer();
    private magazineBehaviour ammo;

    private IRayProvider rayProvider;
    private ISelector selector;



    void Start()
    {
        ammo = new magazineBehaviour(magezineSize.Value, ammoInMag.Value, amountOfBullets.Value);
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

            Debug.Log(name + " is shooting");
            selector.Check(rayProvider.CreateRay());
            ammo.Shot();


            if (selector.GetSelection() != null)
                selector.GetSelection().GetComponent<Idamageable>().GetDamaged(damage.Value);

            timer.ResetTime(0);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(name + " Reloaded");
            ammo.Reload();
        }
        else if (!ammo.HasAmmoInMag())
        {
            return;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] private FloatReference damage;
    [SerializeField] private FloatReference magezineSize;
    [SerializeField] private FloatReference currentAmmo;
    [SerializeField] private FloatReference shootingSpeed;
    private Timer timer = new Timer();
    private Ammo ammo;

    private IRayProvider rayProvider;
    private ISelector selector;



    void Start()
    {
        ammo = new Ammo(magezineSize.Value, currentAmmo.Value);
        rayProvider = GetComponent<IRayProvider>(); //dit called het midden van het scherm
        selector = GetComponent<ISelector>(); // maakt de ray die ervoor zorgt dat je de enemy raakt
    }

    void Update()
    {
        timer.GetDeltaTime(Time.deltaTime);
        timer.TimeMultiplication(shootingSpeed.Value);

        if (Input.GetMouseButton(0) && timer.time > 1f && ammo.HasAmmoInMag())
        {
            selector.Check(rayProvider.CreateRay());

            if(selector.GetSelection() != null)
            selector.GetSelection().GetComponent<Idamageable>().GetDamaged(damage.Value);
            
            Debug.Log(name + "has shot");
            timer.ResetTime(0);
        }


    }
}

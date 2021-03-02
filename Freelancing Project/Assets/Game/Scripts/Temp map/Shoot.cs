using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    private Timer timer = new Timer();
    [SerializeField] private FloatReference damage;
    [SerializeField] private float shootingSpeed;

    private IRayProvider rayProvider;
    private ISelector selector;



    void Start()
    {
        rayProvider = GetComponent<IRayProvider>(); //dit called het midden van het scherm
        selector = GetComponent<ISelector>(); // maakt de ray die ervoor zorgt dat je de enemy raakt
    }

    void Update()
    {
        timer.GetDeltaTime(Time.deltaTime);
        timer.TimeMultiplication(shootingSpeed);

        if (Input.GetMouseButton(0) && timer.time > 1f)
        {
            selector.Check(rayProvider.CreateRay());
            if(selector.GetSelection() != null)
            selector.GetSelection().GetComponent<Idamageable>().GetDamaged(damage.Value);
            
            Debug.Log(name + "has shot");
            timer.ResetTime(0);
        }


    }
}

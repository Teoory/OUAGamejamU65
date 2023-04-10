using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KarakterUI : MonoBehaviour
{
    [SerializeField] private Slider staminaSlider;
    public GameObject DoubleJump;
    public bool DoobleJumpReady;

    private float maxStamina = 100;
    public float stamina;

    private void Awake() {
        maxStamina = GetComponentInParent<KarakterKontrol>().maxStamina;
    }

    private void Start() {
        staminaSlider.maxValue = maxStamina;
    }

    private void Update() {
        stamina = GetComponentInParent<KarakterKontrol>().stamina;
        DoobleJumpReady = GetComponentInParent<KarakterKontrol>().DoobleJumpReady;

        if(DoobleJumpReady)
        {
            DoubleJump.SetActive(true);
        }else
        {
            DoubleJump.SetActive(false);
        }
        staminaSlider.value = stamina;

        if(stamina == maxStamina)
        {staminaSlider.gameObject.SetActive(false);}
        if(stamina >= 0 && stamina <= 99)
        {staminaSlider.gameObject.SetActive(true);}
    }

    private void OnGUI() {
        float t = Time.deltaTime /1f;
        staminaSlider.value = Mathf.Lerp(staminaSlider.value, stamina, t);
    }
}

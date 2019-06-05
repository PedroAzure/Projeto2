using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIPresser : MonoBehaviour, IPointerDownHandler,
    IPointerUpHandler
{
    bool pressed = false;

    public AudioClip MusicClip;
    public AudioSource MusicSource;

    // Bullet's Components
    public GameObject bulletPrefab;
    public Button fireButton;
    public GameObject ship;
    public Animator controlAnimator;

    public Vector3 offset = new Vector3(0.8f, 0.1f, 0);

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;

    Vector3 pos;

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (pressed)
            Fire();
    }

    public void Fire()
    {
        controlAnimator.SetBool("IsOpen", false);
        controlAnimator.SetBool("ShotHidden", true);

        if (cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;

            MusicSource.Play(); // play music

            Instantiate(bulletPrefab, ship.transform.position + offset, transform.rotation);
        }
    }
}
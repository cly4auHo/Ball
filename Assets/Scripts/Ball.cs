﻿using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] private float trajectorySpeed = 1f;
    [SerializeField] private float movementSpeed = 2;
    private TrailRenderer trailRenderer;
    private AudioSource audioSource;
    private TrajectoryProvider trajectoryProvider;
    private bool isMoving = false;
    private float startSpeed;
    private float index;

    void Start()
    {
        trajectoryProvider = new TrajectoryProvider();
        trailRenderer = GetComponent<TrailRenderer>();
        audioSource = GetComponent<AudioSource>();
        startSpeed = trajectorySpeed;

        ResetToStart();
    }

    public void ResetToStart()
    {
        isMoving = false;
        index = 0;

        transform.position = trajectoryProvider.GetPosInTime(0);
        trailRenderer.Clear();
        audioSource.Stop();
    }

    public void OnSpeedChange(Slider slider)
    {
        trajectorySpeed = startSpeed * slider.value;
    }

    public void StartMove()
    {
        audioSource.Play();

        if (isMoving)
            return;

        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
            Move();
    }

    private void Move()
    {
        if (trajectorySpeed <= 0)
            return;

        index += trajectorySpeed;

        transform.position = Vector3.Lerp(transform.position,
            trajectoryProvider.GetPosInTime(Mathf.FloorToInt(index)), Time.deltaTime * movementSpeed);
    }
}

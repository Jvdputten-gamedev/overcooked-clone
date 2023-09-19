using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KitchenGameManager : MonoBehaviour
{
    public static KitchenGameManager Instance {get; private set;}

    public event EventHandler OnStateChanged;


    private enum State {
        WaitingToStart,
        CountDownToStart,
        GamePlaying,
        GameOver
    }

    private State state;
    private float WaitingToStartTimer = 1f;
    private float countdownToSTartTimer = 3f;
    private float gamePlayingTimer;
    private float gamePlayingTimerMax = 10f;

    private void Awake() {
        Instance = this;
        state = State.WaitingToStart;
    }

    private void Update() {
        switch (state){
            case State.WaitingToStart:
                WaitingToStartTimer -= Time.deltaTime;
                if (WaitingToStartTimer < 0f){
                    state = State.CountDownToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountDownToStart:
                countdownToSTartTimer -= Time.deltaTime;
                if (countdownToSTartTimer < 0f){
                    state = State.GamePlaying;
                    gamePlayingTimer = gamePlayingTimerMax;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0f){
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                break;
        }

        Debug.Log(state);
    }

    public bool IsGamePlaying(){
        return state == State.GamePlaying;
    }

    public bool IsCountdownToStartActive(){
        return state == State.CountDownToStart;
    }

    public float GetCountdownToStartTimer(){
        return countdownToSTartTimer;
    }

    public bool IsGameOver(){
        return state == State.GameOver;
    }

    public float GetGamePlayingTImerNormalized(){
        return 1 - (gamePlayingTimer/gamePlayingTimerMax);
    }
}

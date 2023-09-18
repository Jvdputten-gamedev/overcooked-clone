using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;
    private void Start() {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f){
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f){
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
    }

    private void DeliveryManager_OnRecipeSuccess(object ender, System.EventArgs e){
        Debug.Log("Playing success sound");
        PlaySound(audioClipRefsSO.deliverySuccess, Camera.main.transform.position);
    }

    private void DeliveryManager_OnRecipeFailed(object ender, System.EventArgs e){
        Debug.Log("Playing failedsound");
        PlaySound(audioClipRefsSO.deliveryFail, Camera.main.transform.position);
        
    }
}

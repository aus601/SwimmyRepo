using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class MouthMove : MonoBehaviour
{
    public Transform mouth;

    private RealtimeAvatarVoice _voice;
    private float _mouthSize;

    void Awake()
    {
        //Get reference to RealtimeAvatarVoice component
        _voice = GetComponent<RealtimeAvatarVoice>();
    }

    void Update()
    {
        //Use current voice volume (0 to 1) to calculate target mouth size (0.1 to 1.0)
        float targetMouthSize = Mathf.Lerp(0.1f, 1.0f, _voice.voiceVolume * 2);

        //Animate mouth size towards target mouth size for smooth open/close animation
        _mouthSize = Mathf.Lerp(_mouthSize, targetMouthSize, 30.0f * Time.deltaTime);

        //Apply the mouth size to the scale of mouth geometry
        Vector3 localScale = mouth.localScale;
        localScale.y = _mouthSize;
        mouth.localScale = localScale;
    }
}

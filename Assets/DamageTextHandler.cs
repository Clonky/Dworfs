using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Assets.Scripts;

public class DamageTextHandler : MonoBehaviour
{
    Stack<Assets.Scripts.DmgTxtEvent> eventQueue = new Stack<Assets.Scripts.DmgTxtEvent>();
    TextMeshPro textMesh;
    ParticleSystem particleSystem;
    ParticleSystemRenderer renderSystem;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
        renderSystem = GetComponent<ParticleSystemRenderer>();
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Pause();
        renderSystem.mesh = textMesh.mesh;
    }

    // Update is called once per frame
    void Update()
    {
        if (eventQueue.Count > 0)
        {
            DmgTxtEvent currEvent = eventQueue.Pop();
            gameObject.transform.position = currEvent.Position;
            currEvent.HandleEvent(ref textMesh, ref renderSystem, ref particleSystem);
        }
        
    }

    public void pushEventOnStack(Assets.Scripts.DmgTxtEvent ev) {
        eventQueue.Push(ev);
    }

}

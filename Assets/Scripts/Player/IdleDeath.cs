using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.PostProcessing;

public class IdleDeath : MonoBehaviour
{
    // Variables publicas
    public float TimeToDie;
    public UnityEvent onDeath;
    public PostProcessVolume ppVolume;

    // Variables privadas
    private CharacterController characterController;
    private float m_Time = 0;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIdle();
        PostProcessingEffect();
    }

    // funcion para revisar que el player esté en Idle
    void CheckIdle()
    {
        // Si no nos estamos moviendo entonces aumentamos el tiempo
        if (characterController.velocity.magnitude == 0f)
        {
            m_Time += 1f * Time.deltaTime;

            //GetComponent<PlayerMovement>().GetMovementVector();
            ppVolume.weight = (m_Time / TimeToDie) * 0.65f;
            
            // Si llegamos al tiempo de muerte entonces activamos el evento
            if (m_Time >= TimeToDie)
            {
                onDeath.Invoke();
                enabled = false;
            }
        }
        // Si nos movemos reiniciamos el tiempo
        else
        {
            m_Time = 0f;
        }
    }

    // Funcion para controlar el postprocesado
    void PostProcessingEffect()
    {
        //ppVolume.weight = (m_Time / TimeToDie) * 0.65f;
    }
}

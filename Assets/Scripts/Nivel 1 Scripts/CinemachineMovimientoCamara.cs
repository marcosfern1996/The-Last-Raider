using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineMovimientoCamara : MonoBehaviour
{

    public static CinemachineMovimientoCamara Instance;
    private CinemachineVirtualCamera cinemachineVirtualCamara;
    private CinemachineBasicMultiChannelPerlin CinemachineBasicMultiChannelPerlin;
    public float tiempoDeMovimiento;
    public float tiempoDeMovimientoTotal;
    public float intencidadIni;

    private void Awake()
    {
        Instance = this;
        cinemachineVirtualCamara = GetComponent<CinemachineVirtualCamera>();

        CinemachineBasicMultiChannelPerlin = cinemachineVirtualCamara.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    }

    public void MoverCamara(float intencidad, float tiempo, float frecuencia) {

        CinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intencidad;
        CinemachineBasicMultiChannelPerlin.m_FrequencyGain = frecuencia;
        intencidadIni = intencidad;
        tiempoDeMovimiento = tiempo;
        tiempoDeMovimientoTotal = tiempo;

    }

    private void Update()
    {
        if(tiempoDeMovimiento>0)
        {
            tiempoDeMovimiento -= Time.deltaTime;
            CinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(intencidadIni, 0, 1 - (tiempoDeMovimiento / tiempoDeMovimientoTotal));
        }
    }

}

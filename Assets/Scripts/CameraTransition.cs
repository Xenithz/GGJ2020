using System.Collections;
using Cinemachine;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook cinemachineFreeCam;
    [SerializeField] private GameObject front;
    [SerializeField] private float timeToLerp = 4f;


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(SideView());
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(TopView());
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(ThirdPersonView());
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(FirstPersonView());
        }
    }


    public IEnumerator TopView()
    {
        cinemachineFreeCam.LookAt = cinemachineFreeCam.Follow;

        float endValueY = 1f;
        float endValueX = -90f;

        float midRigEndRadius = 35f;
        float endMidHeight = 0;

        float topRigEndRadius = 0.1f;
        float endFov = 5f;

        float startValueY = cinemachineFreeCam.m_YAxis.Value;
        float startValueX = cinemachineFreeCam.m_XAxis.Value;

        float startTopRigRadius = cinemachineFreeCam.m_Orbits[0].m_Radius;

        float startMidHeight = cinemachineFreeCam.m_Orbits[1].m_Height;
        float startMidRigRadius = cinemachineFreeCam.m_Orbits[1].m_Radius;

        float startFov = cinemachineFreeCam.m_Lens.FieldOfView;

        float percCompleted = 0f;
        float timeSinceStarted = Time.time;
        float timeRemaining = 0f;
        while (percCompleted < 1f)
        {
            timeRemaining = Time.time - timeSinceStarted;
            percCompleted = timeRemaining / timeToLerp;
            cinemachineFreeCam.m_YAxis.Value = Mathf.Lerp(startValueY, endValueY, percCompleted);
            cinemachineFreeCam.m_XAxis.Value = Mathf.Lerp(startValueX, endValueX, percCompleted);
            cinemachineFreeCam.m_Orbits[0].m_Radius = Mathf.Lerp(startTopRigRadius, topRigEndRadius, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Height = Mathf.Lerp(startMidHeight, endMidHeight, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Radius = Mathf.Lerp(startMidRigRadius, midRigEndRadius, percCompleted);
            cinemachineFreeCam.m_Lens.FieldOfView = Mathf.Lerp(startFov, endFov, percCompleted);
            yield return null;
        }

        Debug.Log("top completed");
    }


    public IEnumerator SideView()
    {
        float endValueY = 0.5f;
        float endValueX = 0f;

        float midRigEndRadius = 35f;
        float endMidHeight = 0;

        float topRigEndRadius = 1.3f;
        float endFov = 5f;

        cinemachineFreeCam.LookAt = cinemachineFreeCam.Follow;

        float startValueY = cinemachineFreeCam.m_YAxis.Value;
        float startValueX = cinemachineFreeCam.m_XAxis.Value;

        float startTopRigRadius = cinemachineFreeCam.m_Orbits[0].m_Radius;

        float startMidHeight = cinemachineFreeCam.m_Orbits[1].m_Height;
        float startMidRigRadius = cinemachineFreeCam.m_Orbits[1].m_Radius;

        float startFov = cinemachineFreeCam.m_Lens.FieldOfView;


        float percCompleted = 0f;
        float timeSinceStarted = Time.time;
        float timeRemaining = 0f;
        while (percCompleted < 1f)
        {
            timeRemaining = Time.time - timeSinceStarted;
            percCompleted = timeRemaining / timeToLerp;

            cinemachineFreeCam.m_YAxis.Value = Mathf.Lerp(startValueY, endValueY, percCompleted);
            cinemachineFreeCam.m_XAxis.Value = Mathf.Lerp(startValueX, endValueX, percCompleted);
            cinemachineFreeCam.m_Orbits[0].m_Radius = Mathf.Lerp(startTopRigRadius, topRigEndRadius, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Height = Mathf.Lerp(startMidHeight, endMidHeight, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Radius = Mathf.Lerp(startMidRigRadius, midRigEndRadius, percCompleted);
            cinemachineFreeCam.m_Lens.FieldOfView = Mathf.Lerp(startFov, endFov, percCompleted);

            yield return null;
        }
    }

    public IEnumerator ThirdPersonView()
    {
        float endValueY = 0.5f;
        float endValueX = 90f;

        float midRigEndRadius = 2f;
        float endMidHeight = 0.5f;

        float topRigEndRadius = 2;
        float endFov = 40f;

        cinemachineFreeCam.LookAt = cinemachineFreeCam.Follow;


        float startValueY = cinemachineFreeCam.m_YAxis.Value;
        float startValueX = cinemachineFreeCam.m_XAxis.Value;

        float startTopRigRadius = cinemachineFreeCam.m_Orbits[0].m_Radius;

        float startMidHeight = cinemachineFreeCam.m_Orbits[1].m_Height;
        float startMidRigRadius = cinemachineFreeCam.m_Orbits[1].m_Radius;

        float startFov = cinemachineFreeCam.m_Lens.FieldOfView;

        float percCompleted = 0f;
        float timeSinceStarted = Time.time;
        float timeRemaining = 0f;
        while (percCompleted < 1f)
        {
            timeRemaining = Time.time - timeSinceStarted;
            percCompleted = timeRemaining / timeToLerp;
            cinemachineFreeCam.m_YAxis.Value = Mathf.Lerp(startValueY, endValueY, percCompleted);
            cinemachineFreeCam.m_XAxis.Value = Mathf.Lerp(startValueX, endValueX, percCompleted);
            cinemachineFreeCam.m_Orbits[0].m_Radius = Mathf.Lerp(startTopRigRadius, topRigEndRadius, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Height = Mathf.Lerp(startMidHeight, endMidHeight, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Radius = Mathf.Lerp(startMidRigRadius, midRigEndRadius, percCompleted);
            cinemachineFreeCam.m_Lens.FieldOfView = Mathf.Lerp(startFov, endFov, percCompleted);
            yield return null;
        }
    }


    public IEnumerator FirstPersonView()
    {
        float endValueY = 0.5f;
        float endValueX = 90f;

        float midRigEndRadius = 0f;
        float endMidHeight = 0f;

        float topRigEndRadius = 0;
        float endFov = 40f;


        float startValueY = cinemachineFreeCam.m_YAxis.Value;
        float startValueX = cinemachineFreeCam.m_XAxis.Value;

        float startTopRigRadius = cinemachineFreeCam.m_Orbits[0].m_Radius;

        float startMidHeight = cinemachineFreeCam.m_Orbits[1].m_Height;
        float startMidRigRadius = cinemachineFreeCam.m_Orbits[1].m_Radius;

        float startFov = cinemachineFreeCam.m_Lens.FieldOfView;

        float percCompleted = 0f;
        float timeSinceStarted = Time.time;
        float timeRemaining = 0f;
        while (percCompleted < 1f)
        {
            timeRemaining = Time.time - timeSinceStarted;
            percCompleted = timeRemaining / timeToLerp;
            cinemachineFreeCam.m_YAxis.Value = Mathf.Lerp(startValueY, endValueY, percCompleted);
            cinemachineFreeCam.m_XAxis.Value = Mathf.Lerp(startValueX, endValueX, percCompleted);
            cinemachineFreeCam.m_Orbits[0].m_Radius = Mathf.Lerp(startTopRigRadius, topRigEndRadius, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Height = Mathf.Lerp(startMidHeight, endMidHeight, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Radius = Mathf.Lerp(startMidRigRadius, midRigEndRadius, percCompleted);
            cinemachineFreeCam.m_Lens.FieldOfView = Mathf.Lerp(startFov, endFov, percCompleted);
            yield return null;
        }

        cinemachineFreeCam.LookAt = front.transform;
    }
}
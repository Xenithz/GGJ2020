using System.Collections;
using Cinemachine;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public CinemachineCameraOffset cinemachineCameraOffset;
    [SerializeField] private CinemachineFreeLook cinemachineFreeCam;
    [SerializeField] private GameObject front;

    private PlayerMovement playerMovement;
    [SerializeField] private float timeToLerp = 4f;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeToSideView();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeToTopView();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeToFrontView();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeToThirdPersonView();
        }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            Time.timeScale = 5;
        }
        else if (Input.GetKeyUp(KeyCode.PageUp))
        {
            Time.timeScale = 1;
        }
#endif
    }


    public void ChangeToSideView()
    {
        StartCoroutine(SideView());
        playerMovement.topDown = false;
    }

    public void ChangeToTopView()
    {
        Debug.Log("TOP VIEW");
        StartCoroutine(TopView());
        playerMovement.topDown = true;
    }

    public void ChangeToFrontView()
    {
        StartCoroutine(FirstPersonView());
        playerMovement.topDown = false;
    }

    public void ChangeToThirdPersonView()
    {
        StartCoroutine(ThirdPersonView());
        playerMovement.topDown = false;
    }


    public IEnumerator TopView()
    {
        cinemachineFreeCam.LookAt = cinemachineFreeCam.Follow;


        float startZOffset = cinemachineCameraOffset.m_Offset.z;


        float endValueY = 1f;
        float endValueX = 0f;
        float endZOffSet =  5;
        

        float midRigEndRadius = 35f;
        float endMidHeight = 0;

        float topRigEndRadius = 18f;
        float topHeightEnd = 30f;

        float endFov = 60;

        float startValueY = cinemachineFreeCam.m_YAxis.Value;
        float startValueX = cinemachineFreeCam.m_XAxis.Value;

        float startTopRigRadius = cinemachineFreeCam.m_Orbits[0].m_Radius;
        float startTopHeight = cinemachineFreeCam.m_Orbits[0].m_Height;

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
            
            cinemachineCameraOffset.m_Offset.z = Mathf.Lerp(startZOffset, endZOffSet, percCompleted);
            
            cinemachineFreeCam.m_YAxis.Value = Mathf.Lerp(startValueY, endValueY, percCompleted);
            cinemachineFreeCam.m_XAxis.Value = Mathf.Lerp(startValueX, endValueX, percCompleted);
            cinemachineFreeCam.m_Orbits[0].m_Radius = Mathf.Lerp(startTopRigRadius, topRigEndRadius, percCompleted);
            cinemachineFreeCam.m_Orbits[0].m_Height = Mathf.Lerp(startTopHeight, topHeightEnd, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Height = Mathf.Lerp(startMidHeight, endMidHeight, percCompleted);
            cinemachineFreeCam.m_Orbits[1].m_Radius = Mathf.Lerp(startMidRigRadius, midRigEndRadius, percCompleted);
            cinemachineFreeCam.m_Lens.FieldOfView = Mathf.Lerp(startFov, endFov, percCompleted);
            yield return null;
        }
    }


    public IEnumerator SideView()
    {
        float endValueY = 0.5f;
        float endValueX = 0f;

        float midRigEndRadius = 600;
        float endMidHeight = 0;

        float topRigEndRadius = 1.3f;
        float topHeightEndRadius = 4.5f;

        float endFov = 5f;

        cinemachineFreeCam.LookAt = cinemachineFreeCam.Follow;

        float startValueY = cinemachineFreeCam.m_YAxis.Value;
        float startValueX = cinemachineFreeCam.m_XAxis.Value;

        float startTopRigRadius = cinemachineFreeCam.m_Orbits[0].m_Radius;
        float startTopHeight = cinemachineFreeCam.m_Orbits[0].m_Height;


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
            cinemachineFreeCam.m_Lens.FieldOfView = Mathf.Lerp(startTopHeight, topHeightEndRadius, percCompleted);

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
        float topHeightEnd = 4.5f;

        float endFov = 40f;

        cinemachineFreeCam.LookAt = cinemachineFreeCam.Follow;


        float startValueY = cinemachineFreeCam.m_YAxis.Value;
        float startValueX = cinemachineFreeCam.m_XAxis.Value;

        float startTopRigRadius = cinemachineFreeCam.m_Orbits[0].m_Radius;
        float startTopHeight = cinemachineFreeCam.m_Orbits[0].m_Height;


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
            cinemachineFreeCam.m_Orbits[0].m_Height = Mathf.Lerp(startTopHeight, topHeightEnd, percCompleted);
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
        float topHeightEnd = 4.5f;

        float endFov = 40f;


        float startValueY = cinemachineFreeCam.m_YAxis.Value;
        float startValueX = cinemachineFreeCam.m_XAxis.Value;

        float startTopRigRadius = cinemachineFreeCam.m_Orbits[0].m_Radius;
        float startTopHeight = cinemachineFreeCam.m_Orbits[0].m_Height;

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
            cinemachineFreeCam.m_Orbits[0].m_Height = Mathf.Lerp(startTopHeight, topHeightEnd, percCompleted);
            yield return null;
        }

        cinemachineFreeCam.LookAt = front.transform;
    }
}
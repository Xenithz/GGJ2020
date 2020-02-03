using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level2
{
    public class TextEffect3D : MonoBehaviour
    {
        [SerializeField] private MeshRenderer[] renderers;
        [SerializeField] private Material textMat;
        [SerializeField] private float normalFadeTime;
        [SerializeField] private float perCharacterFadeTime;
        [SerializeField] private bool onGroundCollisionFade = true;
        private Coroutine routine;
        [SerializeField] private List<Collider> colliders;
        private bool isGrounded = false;
        [SerializeField] float initialAlpha = 1;
        [SerializeField] public static bool level1Collision = true;

        private void Start()
        {
            foreach (MeshRenderer rend in renderers)
                colliders.Add(rend.GetComponent<Collider>());

            for (int i = 0; i < renderers.Length; i++)
            {
                Material newMat = new Material(textMat);
                renderers[i].material = newMat;
                Color color = renderers[i].material.color;
                color.a = initialAlpha;
                renderers[i].material.color = color;
            }

            //StartCoroutine(NormalFadeIn(5f));



        }

        private IEnumerator NormalFadeInRoutine()
        {
            float timer = 0f;
            float speed = 1f / normalFadeTime;

            while (renderers[0].material.color.a < 1f)
            {
                for (int i = 0; i < renderers.Length; i++)
                {
                    Color color = renderers[i].material.color;
                    color.a += speed * Time.deltaTime;
                    renderers[i].material.color = color;

                }

                yield return null;
            }

            routine = null;



        }

        public void NormalFadeIn()
        {

            routine = StartCoroutine(NormalFadeInRoutine());
        }

        public void NormalFadeOut()
        {

            routine = StartCoroutine(NormalFadeOutRoutine());
        }

        public void PerCharacterFadeIn()
        {

            routine = StartCoroutine(PerCharacterFadeInRoutine());
        }

        public void PerCharacterFadeOut()
        {

            routine = StartCoroutine(PerCharacterFadeOutRoutine());
        }


        private IEnumerator NormalFadeOutRoutine()
        {
            float timer = 0f;
            float speed = 1f / normalFadeTime;

            while (renderers[0].material.color.a > 0f)
            {
                for (int i = 0; i < renderers.Length; i++)
                {
                    Color color = renderers[i].material.color;
                    color.a -= speed * Time.deltaTime;
                    renderers[i].material.color = color;

                }

                yield return null;
            }

            routine = null;
            Destroy(gameObject);
        }

        private IEnumerator PerCharacterFadeOutRoutine()
        {
            float speed = 1f / perCharacterFadeTime;
            int characterIndex = 0;
            while (characterIndex < renderers.Length)
            {
                Color color = renderers[characterIndex].material.color;

                while (color.a >= 0f)
                {
                    color.a -= speed * Time.deltaTime;
                    renderers[characterIndex].material.color = color;
                    yield return null;

                }

                color.a = 0f;
                renderers[characterIndex].material.color = color;
                characterIndex++;

            }

            routine = null;
            Destroy(gameObject);

        }

        private IEnumerator PerCharacterFadeInRoutine()
        {
            float totalTime = perCharacterFadeTime * renderers.Length;
            float speed = 1f / perCharacterFadeTime;
            int characterIndex = 0;
            while (characterIndex < renderers.Length)
            {
                Color color = renderers[characterIndex].material.color;

                while (color.a <= 1f)
                {
                    color.a += speed * Time.deltaTime;
                    renderers[characterIndex].material.color = color;
                    yield return null;

                }

                color.a = 1f;
                renderers[characterIndex].material.color = color;
                characterIndex++;

            }

            routine = null;

        }

        private void OnCollisionEnter(Collision collision)
        {

            if (level1Collision)
            {
                if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {

                    foreach (Collider col in colliders)
                    {
                        Rigidbody rb = col.GetComponent<Rigidbody>();
                        col.enabled = true;
                        rb.constraints = RigidbodyConstraints.None;
                        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX |
                                         RigidbodyConstraints.FreezeRotationY;
                        Vector3 randomRange = Random.insideUnitSphere * 15f;
                        randomRange.y = randomRange.y < 0 ? -randomRange.y : randomRange.y;
                        randomRange.y *= 0.4f;
                        rb.AddForce(randomRange, ForceMode.Impulse);
                    }

                    GetComponent<Collider>().enabled = false;

                    NormalFadeOut();
                }
            }

        }

        private void OnCollisionStay(Collision collision)
        {

            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                isGrounded = true;
            }
        }

        public void SetRigibodiesActive()
        {

            for (int i = 0; i < renderers.Length; i++)
            {

                Vector3 randomRange = Random.insideUnitSphere;
                Rigidbody rb = renderers[i].transform.GetComponent<Rigidbody>();

                renderers[i].transform.GetComponent<Rigidbody>().isKinematic = false;
                //rb.AddForce(randomRange * 13f, ForceMode.Impulse);
            }
            //Invoke("DisableRigidbodies", 4f);

        }

        public void DisableRigidbodies()
        {
            for (int i = 0; i < renderers.Length; i++)
            {

                renderers[i].GetComponent<Rigidbody>().isKinematic = true;

            }
        }



    }

}
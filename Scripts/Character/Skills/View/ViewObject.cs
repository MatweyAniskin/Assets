using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    public class ViewObject : MonoBehaviour
    {
        [SerializeField] MeshFilter meshFilter;
        [SerializeField] MeshRenderer meshRenderer;
        [SerializeField] AnimationCurve curve;
        [SerializeField] int multiply = 4;
        bool destroing = false;
        public void Set(Mesh mesh, Material material)
        {
            StartCoroutine(StartAnimation());
            meshFilter.mesh = mesh;
            meshRenderer.material = material;
        }
        public void Destroy()
        {
            if(!destroing)
                StartCoroutine(EndAnimation());
        }
        IEnumerator StartAnimation()
        {
            for (float i = 0; i <= 1; i += Time.deltaTime*multiply)
            {
                transform.position = new Vector3(0, curve.Evaluate(i), 0);
                yield return null;
            }
        }
        IEnumerator EndAnimation()
        {
            destroing = true;
            for (float i = 1; i >= 0; i -= Time.deltaTime * multiply)
            {
                transform.position = new Vector3(0, curve.Evaluate(i), 0);
                yield return null;
            }
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public class EffectBehaviourOnTarget : MonoBehaviour
    {
        [SerializeField] NpcBehaviour characterBehaviour;
        [SerializeField] EffectAnimation animation;
        [SerializeField] bool onlyPlayerTransform;
        private void Start()
        {
            characterBehaviour.OnTargeted += OnTargeted;
        }
        private void OnDestroy()
        {
            characterBehaviour.OnTargeted -= OnTargeted;
        }
        void OnTargeted(MatrixTransform matrixTransform)
        {
            if (onlyPlayerTransform && !(matrixTransform is PlayerMatrixTransform))
                return;
            Instantiate(animation, transform.position, animation.transform.rotation, transform);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerCamera
{
    [System.Serializable]
    public class FocusBehaviourProfile
    {
        [SerializeField] PlayerBehaviour.Type type;
        [SerializeField][Range(0f, 2f)] float fovPercent;

        public float Fov => fovPercent;
        public static bool operator ==(FocusBehaviourProfile a, PlayerBehaviour.Type b) => a.type == b;
        public static bool operator !=(FocusBehaviourProfile a, PlayerBehaviour.Type b) => !(a == b);
    }

}
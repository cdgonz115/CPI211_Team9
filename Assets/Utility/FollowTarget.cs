using System;
using UnityEngine;


namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {
        public GameObject target;
        public Vector3 offset = new Vector3(0f, 7.5f, 0f);


        private void LateUpdate()
        {
            if(GameObject.Find(target.name))transform.position = target.transform.position + offset;
        }
    }
}

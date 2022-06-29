using UnityEngine;
using Baracuda.Monitoring.API;
using Baracuda.Monitoring;

namespace Alpha
{
    public class ChaseCam : MonoBehaviour
    {
        #region Variables
        [Header("Chase camera properties")]
        [SerializeField] private Transform target;

        [SerializeField] private Vector3 extraOffset;

        [SerializeField] private float lerpSpeed = 1f;
        [SerializeField] private float rotationSpeed = 1f;
        #endregion


        #region UnityMethods
        void FixedUpdate()
        {

            Camera1();

        }
        #endregion

        private void Camera1()
        {
            Vector3 reqRotation = target.transform.position - transform.position;

            Quaternion newRotation = Quaternion.LookRotation(reqRotation);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);

            // Move
            Vector3 newPosition = target.transform.position - target.transform.forward * extraOffset.z - target.transform.up * extraOffset.y;
            Debug.Log(newPosition);
            transform.position = Vector3.Slerp(transform.position, newPosition, lerpSpeed*Time.deltaTime);
        }
    }



}
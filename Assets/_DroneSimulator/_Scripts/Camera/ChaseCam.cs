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

        [Space(20)]
        public Vector3 direct;
        public Vector3 normalDirect;
        public Quaternion newRot;
   
        #endregion


        #region UnityMethods
        void LateUpdate()
        {

            Camera1();

        }
        #endregion

        private void Camera1()
        {
            //Rotation
            //Vector3 reqRotation = target.position - transform.position;
            Vector3 reqRotation = target.eulerAngles;
            reqRotation.x = 0;
            reqRotation.z = 0;
            //Quaternion newRotation = Quaternion.LookRotation(reqRotation,Vector3.up);
           // Quaternion finalRotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
            Quaternion finalRotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(reqRotation), rotationSpeed * Time.deltaTime);
            transform.rotation = finalRotation;


            // Move
            //Vector3 newPosition = target.position - (target.forward * extraOffset.z) - (target.up * extraOffset.y);
            Vector3 newPosition = (target.TransformPoint(extraOffset) - transform.position);
            transform.position = Vector3.Slerp(transform.position, newPosition, lerpSpeed*Time.deltaTime);
        }
        

    }



}
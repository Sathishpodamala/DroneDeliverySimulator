using UnityEngine;


namespace Alpha
{
    public class DroneMotor :MonoBehaviour,IMotor
    {

        #region Variables
        [Header("Motor Properties")]
        [SerializeField] private float maxPower = 4f;
        [SerializeField] private int motorCount = 4;

        [Header("Propeller Properties")]
        [SerializeField] private Transform propeller;
        [SerializeField] private float propellerRotationSpeed=300f;
        #endregion


        #region Interface Methods
        public void Init()
        {
            
        }

        public void UpdateMotor(Rigidbody rb, float throttle)
        {
            Vector3 upVector = transform.up;
            upVector.x = 0;
            upVector.z = 0;

            float difference = 1 - upVector.magnitude;
            float finalDifference = Physics.gravity.magnitude * difference;

            Vector3 motorForce = Vector3.zero;
            motorForce = transform.up * ((rb.mass * Physics.gravity.magnitude+finalDifference) + (maxPower * throttle)) / motorCount;

            rb.AddForce(motorForce, ForceMode.Force);

            HanldePropeller();
        }


        #endregion
        #region Private Methods
        private void HanldePropeller()
        {
            propeller.Rotate(Vector3.up, propellerRotationSpeed);
        }
        #endregion
    }
}

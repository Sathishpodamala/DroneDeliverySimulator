using UnityEngine;


namespace Alpha
{
    public interface IMotor
    {

        void Init();
        void UpdateMotor(Rigidbody rb, float throttle);

    }
}

using UnityEngine;


namespace Alpha
{
    public interface IMotor
    {

        void Init(float maxPower=4,int motorcout=4);
        void UpdateMotor(Rigidbody rb, float throttle);

    }
}

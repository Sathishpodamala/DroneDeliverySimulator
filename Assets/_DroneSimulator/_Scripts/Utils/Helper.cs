using UnityEngine;


namespace Alpha
{
    public static class Helper
    { 
        #region Variables

        #endregion

        #region Helper Methods
        public static bool CheckStringIsValid(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;
            else
                return true;
        }

        public static float Remap(float inputMin,float inputMax,float outputMin,float outputMax,float value)
        {
            float t = Mathf.InverseLerp(inputMin, inputMax, value);
            
            return Mathf.Lerp(outputMin, outputMax, t);
        }

        public static float RemapOnCurve(AnimationCurve curve,float inputMin, float inputMax, float outputMin, float outputMax, float value)
        {
            float t = Mathf.InverseLerp(inputMin, inputMax, value);
            float v = curve.Evaluate(t);
            return Mathf.Lerp(outputMin, outputMax, v);
        }
        #endregion

    }
}

using UnityEngine;
using System.Collections.Generic;
using System.Linq;
namespace Alpha
{
    public class Sector : MonoBehaviour
    {
        #region Variables
        public bool searchAndFillList = false;
        [Space]
        [Header("Sector Properties")]
        [SerializeField] private string sectorName;
        [SerializeField] private int sectorId;
        public List<Building> buildings = new List<Building>();
        #endregion

        #region UnityMethods
        private void OnValidate()
        {
            if(searchAndFillList)
            {
                buildings.Clear();
                buildings = GetComponentsInChildren<Building>().ToList<Building>();
                SetBuildingIds();
            }
        }
        #endregion

        #region PublicMethods
        public void SetBuildingIds()
        {
            if (!Helper.CheckStringIsValid(sectorName))
                return;
            int num = 1;
            foreach (Building building in buildings)
            {
                string id = sectorName + "_" + sectorId+"_"+num;
                building.SetBuildingId(id);
                num++;
            }
        }
        #endregion

        #region PrivateMethods
        public void CheckSectorNameIsValid()
        {
            string.IsNullOrEmpty(sectorName);
        }
        #endregion

        #region GameEventListeners

        #endregion
    }
}

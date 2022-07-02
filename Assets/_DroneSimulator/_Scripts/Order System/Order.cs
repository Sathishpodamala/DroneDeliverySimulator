using UnityEngine;


namespace Alpha
{
    [System.Serializable]
    public class Order
    {
        #region Variables
        private string orderID;
        private Transform pickupPoint;
        private Transform dropPoint;
        private float weight;
        private float price;
        private float distance;
        #endregion

        #region Getters
        public string OrderID  => orderID;
        public Transform PickupPoint=> pickupPoint; 
        public Transform DropPoint => dropPoint;
        public float Weight  => weight;
        public float Price => price;
        public float Distance => distance; 
        #endregion


        #region Constructors
        public Order()
        {
            orderID = "Not Assigned";
            pickupPoint = null;
            dropPoint = null;
            weight = 0;
            price = 0;
            distance = 0;
            
        }

        public Order(Transform pickup,Transform drop, float weight, float price, float distance, string orderId=null)
        {
            this.pickupPoint = pickup;
            this.dropPoint = drop;
            this.weight = weight;
            this.price = price;
            this.distance = distance;
            this.orderID = orderId;

        }
        #endregion

    }
}

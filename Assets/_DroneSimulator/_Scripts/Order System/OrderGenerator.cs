using UnityEngine;
using System.Collections.Generic;

namespace Alpha
{
    public class OrderGenerator 
    { 
        #region Variables
        #endregion

        #region PublicMethods
        public Order GenerateOrder(List<Building> buildings,OrderConfig config)
        {
            Order order=null;
            PickedPoints points = GetPickAndDropPoint(buildings, config.minDistance, config.maxDistance);

            if(points!=null)
            {
                string pickid = buildings[points.pickIndex].BuildingID;
                string dropid = buildings[points.dropIndex].BuildingID;
                string orderId = pickid + "_" + dropid;
                float weight = CalculateWeight(config, points.distance);
                float price = CalculatePrice(config, weight);
                float distance = points.distance;
                Transform pickPoint = buildings[points.pickIndex].Pick_DropPoint;
                Transform dropPoint = buildings[points.dropIndex].Pick_DropPoint;

                order = new Order(pickPoint, dropPoint, weight, price, distance, orderId);
                return order;
            }

            return order;
        }

        public List<Order>GenerateBulkOrders(List<Building> buildings, OrderConfig config, int numberOfOrders)
        {
            List<Order> bulkOrders = new List<Order>();

            for (int i = 0; i < numberOfOrders; i++)
            {
                bulkOrders.Add(GenerateOrder(buildings, config));
            }

            return bulkOrders;
        }
        #endregion

        #region PrivateMethods
        private PickedPoints GetPickAndDropPoint(List<Building> buildings,float minDist,float maxDist)
        {
            int count = buildings.Count;
            if (count < 2)
                return null;

            int pickId;
            int dropId;
            Transform pickPoint = null;
            Transform dropPoint = null;

            PickedPoints pickedPoints = null;

            int iterationCount = 0;
            int iterations = 100;

            while (true)
            {
                 pickId = Random.Range(0, count);
                 dropId = Random.Range(0, count);

                if (pickId == dropId)
                    continue;

                 pickPoint = buildings[pickId].Pick_DropPoint;
                 dropPoint = buildings[dropId].Pick_DropPoint;

                if (pickPoint && dropPoint)
                {
                    float dist = Vector3.Distance(pickPoint.position, dropPoint.position);

                    if (dist >= minDist && dist <= maxDist)
                    {
                        pickedPoints = new PickedPoints(pickId, dropId, dist);
                        return pickedPoints;
                    }
                }

                if(iterationCount>iterations)
                {
                    return null;
                }

                iterationCount++;
            }
        }


        public float CalculateWeight(OrderConfig config,float distance)
        {
            return Helper.CustomRemapbasedOnCurve(config.weightCurve, config.minDistance, config.maxDistance, config.minWeight, config.maxWeight, distance);
        }

        public float CalculatePrice(OrderConfig config, float weight)
        {
            return Helper.CustomRemapbasedOnCurve(config.priceCurve, config.minWeight, config.maxWeight, config.minPrice, config.maxPrice, weight);
        }
        #endregion
    }

    public class PickedPoints
    {
        public int pickIndex;
        public int dropIndex;
        public float distance;

        public PickedPoints(int pickId, int dropId, float dist)
        {
            this.pickIndex = pickId;
            this.dropIndex = dropId;
            this.distance = dist;
        }
    }
}

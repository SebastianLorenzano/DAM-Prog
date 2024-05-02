using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Jar
    {
        private double capacity;
        private double quantity;

        public void SetCapacity(double value)
        {
            if (value < 0)
                capacity = 0;
            capacity = value;
            if (quantity > capacity)
                quantity = capacity;
        }

        public double GetCapacity()
        {
            return capacity;
        }
        public double SetQuantity(double value)
        {
            if (value < 0)
                quantity = 0;
            if (value > capacity)
            {
                value -= capacity;
                quantity = capacity;
                return value;
            }
            quantity = value;
            return 0;
        }
        public double GetQuantity()
        {
            return quantity;
        }
        
        public double GetPercent()
        {
            if (capacity == 0)
                return 0;
            return quantity / capacity;
        }

        public void AddQuantity(double value)
        {
            SetQuantity(quantity + value);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class BigNumber
    {
        private List<int> _digits = new List<int>();

        public BigNumber(long number)
        {
            SetBigNumber(number);
        }
        
        public BigNumber(string number)
        {
            SetBigNumber(number);
        }

        private BigNumber(List<int> digits)
        {
            _digits = digits;
        }

        public bool IsPositive()
        {
            return GetDigitAt(GetDigitCount() - 1) > 0;
        }

        public void SetBigNumber(long number)
        {
            _digits.Clear();
            while (number > 0)
            {
                _digits.Add((int)(number % 10));
                number /= 10;
            }
        }

        public void SetBigNumber(string number)
        {
            _digits.Clear();
            for (int i = number.Length - 1; i >= 0; i--)
            {
                 _digits.Add(number[i] - '0');
            }
        }

        public BigNumber Clone()
        {
            return this;
        }
        public override string ToString()
        {
            string aux = "";
            for (int i = 0; i < _digits.Count; i++)
                aux += _digits[i];
            return aux;

        }

        public int GetDigitCount()
        {
            return _digits.Count;
        }

        public int GetDigitAt(int index)
        {
           if (index > _digits.Count() || index < 0)
                return 0;
            return _digits[index];
        }

        public static BigNumber Add(BigNumber number1, BigNumber number2)
        {
            List<int> digits = new List<int>();
            bool added1 = false;
            int aux1 = 1;
            int aux2 = 1;
            int n = Math.Max(number1.GetDigitCount(), number2.GetDigitCount());
            if (!number1.IsPositive())
                aux1 = -1;
            if (!number2.IsPositive())
                aux2 = -1;
            for (int i = n - 1; i >= 0; i--)
            {
                int aux = number1.GetDigitAt(i) * aux1 + number2.GetDigitAt(i) * aux2;
                if (added1)
                {
                    aux++;
                    added1 = false;
                }
                if (aux < 0)
                {
                    aux += 10;
                    if (number1.GetDigitAt(i + 1) > 0)
                         
                }


                if (aux >= 10)
                {
                    aux -= 10;
                    added1 = true;
                }
                digits.Add(aux);
            }
            return new BigNumber(digits);
        }

        public static BigNumber Sub(BigNumber number1, BigNumber number2)
        {
            return new BigNumber(1234);
        }

        public static BigNumber Div(BigNumber number1, BigNumber number2)
        {
            return new BigNumber(1234);
        }

        public static BigNumber Mod(BigNumber number1, BigNumber number2)
        {
            return new BigNumber(1234);
        }

    }
}




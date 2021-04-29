using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_2.Models
{
    public class CalculationModel
    {
        public int Val1 { get; set; }
        public int Val2 { get; set; }
        public string Operation { get; set; }
        public string Result { get; set; }

        public void calc_Result()
        {
            Result = "" + Val1;
            switch (Operation)
            {
                case "+":
                    Result += " + " + Val2 + " = " + (Val1 + Val2);
                    break;
                case "-":
                    Result += " - " + Val2 + " = " + (Val1 - Val2);
                    break;
                case "*":
                    Result += " * " + Val2 + " = " + (Val1 * Val2);
                    break;
                case "/":
                    Result += " / " + Val2 + " = ";
                    if (Val2 != 0) Result += (Val1 / Val2);
                    else Result += "ERROR: Division by zero";
                    break;
            }
        }
    }
}

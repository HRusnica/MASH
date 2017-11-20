using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MASH.DAL
{
    public class CalculateDAL : ICalculateDAL
    {
        public string GetPrediction(int iterator)
        {
            string prediction = "You will live a long life" + iterator;
            return prediction;
        }
    }
}
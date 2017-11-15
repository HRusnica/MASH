using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MASH.DAL
{
    public interface ICalculateDAL
    {
        string GetPrediction(int iterator);
    }
}
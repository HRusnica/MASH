using MASH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MASH.DAL
{
    public interface IFutureGroupDAL
    {
        List<FutureGroup> GetAllGroups(string themeSelection, int isGirl);
    }
}
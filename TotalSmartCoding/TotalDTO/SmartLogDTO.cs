using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;

using TotalModel;
using TotalModel.Helpers;

namespace TotalDTO
{
    public static class SmartLogDTO
    {
        public static void Init()
        {
            Type typeNotify = typeof(NotifyPropertyChangeObject);
            List<string> propertyInfos = typeNotify.GetProperties().Select(s => s.Name).ToList();

            propertyInfos.AddRange(typeof(BaseDTO).GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance).Select(s => s.Name).ToList());

            SmartLogDTO.ExclusiveNames = propertyInfos.Except(new List<string>() { "Reference", "PreparedPersonID", "ApproverID", "Description", "Caption", "ViewDetails" }).ToList();

            SmartLogDTO.OptionalNames = typeof(IBaseModel).GetProperties().Select(s => s.Name).ToList();
        }

        public static List<string> ExclusiveNames;
        public static List<string> OptionalNames;
    }
}

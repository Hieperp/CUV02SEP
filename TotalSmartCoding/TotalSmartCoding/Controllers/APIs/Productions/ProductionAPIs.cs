using System.Collections.Generic;

using Ninject;

using TotalModel.Models;

using TotalCore.Repositories.Commons;
using TotalSmartCoding.Libraries;


namespace TotalSmartCoding.Controllers.APIs.Productions
{
    public class ProductionAPIs
    {
        public string IpAddress(int fillingLineID, int deviceID)
        {
            IFillingLineAPIRepository fillingLineAPIRepository = CommonNinject.Kernel.Get<IFillingLineAPIRepository>();

            IList<FillingLineSetting> fillingLineSettings = fillingLineAPIRepository.GetFillingLineSettings(fillingLineID, deviceID);
            if (fillingLineSettings != null && fillingLineSettings.Count > 0)
                return fillingLineSettings[0].IPv4Byte1 + "." + fillingLineSettings[0].IPv4Byte2 + "." + fillingLineSettings[0].IPv4Byte3 + "." + fillingLineSettings[0].IPv4Byte4;
            else
                return "127.0.0.1";
        }
    }
}

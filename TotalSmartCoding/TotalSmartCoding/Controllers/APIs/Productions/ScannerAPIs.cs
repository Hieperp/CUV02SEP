using System;
using System.Collections.Generic;

using AutoMapper;

using TotalBase;
using TotalModel.Models;
using TotalDTO.Productions;
using TotalCore.Repositories.Productions;

namespace TotalSmartCoding.Controllers.APIs.Productions
{
    public class ScannerAPIs
    {
        private readonly IPackRepository packRepository;
        private readonly ICartonRepository cartonRepository;

        public ScannerAPIs(IPackRepository packRepository, ICartonRepository cartonRepository)
        {
            this.packRepository = packRepository;
            this.cartonRepository = cartonRepository;
        }

        public IList<BarcodeDTO> GetBarcodeList(GlobalVariables.FillingLine fillingLineID, int cartonID, int palletID)
        {
            try
            {
                IList<BarcodeDTO> barcodeList = new List<BarcodeDTO>();

                if (cartonID > 0)
                {
                    IList<Pack> packs = this.packRepository.GetPacks(fillingLineID, (int)GlobalVariables.BarcodeStatus.Freshnew + "," + (int)GlobalVariables.BarcodeStatus.Readytoset + "," + (int)GlobalVariables.BarcodeStatus.Wrapped, cartonID);
                    if (packs.Count > 0)
                    {
                        packs.Each(pack =>
                        {
                            PackDTO packDTO = Mapper.Map<Pack, PackDTO>(pack);
                            barcodeList.Add(packDTO);
                        });
                    }
                }
                else
                    if (palletID > 0)
                    {
                        IList<Carton> cartons = this.cartonRepository.GetCartons(fillingLineID, (int)GlobalVariables.BarcodeStatus.Freshnew + "," + (int)GlobalVariables.BarcodeStatus.Readytoset + "," + (int)GlobalVariables.BarcodeStatus.Wrapped + "," + (int)GlobalVariables.BarcodeStatus.Pending + "," + (int)GlobalVariables.BarcodeStatus.Noread, palletID);
                        if (cartons.Count > 0)
                        {
                            cartons.Each(carton =>
                            {
                                CartonDTO cartonDTO = Mapper.Map<Carton, CartonDTO>(carton);
                                barcodeList.Add(cartonDTO);
                            });
                        }
                    }

                return barcodeList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

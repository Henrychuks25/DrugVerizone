using DrugVerizone.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrugVerizone.Services
{
    public interface IManufacturerRepository
    {
        Task<ManufacturerViewDto> Create(ManufacturerCreateDto man);
        Task<ManufacturerViewDto> Delete(Guid manID);
        Task<IEnumerable<ManufacturerViewDto>> Get();
        Task<ManufacturerViewDto> ListById(Guid id);
        Task<bool> ManufacturerExist(Guid manId);
        Task<bool> Save();
        Task<ManufacturerViewDto> Update(Guid manID, ManufacturerUpdateDto drugUpdate);
    }
}
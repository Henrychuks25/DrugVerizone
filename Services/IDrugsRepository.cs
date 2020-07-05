using DrugVerizone.Entities;
using DrugVerizone.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrugVerizone.Services
{
    public interface IDrugsRepository
    {
        
        Task<DrugsViewDto> Create(DrugCreateDto drugs);
        public Task<IEnumerable<ManufacturerViewDto>> GetMan();
        Task<DrugsViewDto> Delete(Guid drugID);
        Task<bool> DrugExist(Guid drugId);
        public Task<IEnumerable<DrugsViewDto>> Get();
        
        Task<DrugsViewDto> ListById(Guid id);
        Task<bool> Save();
        Task<DrugsViewDto> Update(Guid drugID, DrugUpdateDto drugUpdate);
    }
}
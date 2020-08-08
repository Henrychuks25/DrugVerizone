using DrugVerizone.Entities;
using DrugVerizone.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrugVerizone.Services
{
    public interface IDrugTypeRepository
    {
        
        Task<DrugTypeViewDto> Create(DrugTypeCreateDto drugs);
        Task<DrugTypeViewDto> Delete(Guid drugID);
        Task<bool> DrugExist(Guid drugId);
        public Task<IEnumerable<DrugTypeViewDto>> Get();
        
        Task<DrugTypeViewDto> ListById(Guid id);
        Task<bool> Save();
        Task<DrugTypeViewDto> Update(Guid drugID, DrugTypeUpdateDto drugUpdate);
    }
}
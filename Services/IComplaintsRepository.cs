using DrugVerizone.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrugVerizone.Services
{
    public interface IComplaintsRepository
    {
        Task<ComplaintViewDto> Create(ComplaintsCreateDto drugs);
        Task<ComplaintViewDto> Delete(Guid drugID);
        void Dispose();
        Task<bool> DrugExist(Guid drugId);
        Task<IEnumerable<ComplaintViewDto>> Get();
        Task<ComplaintViewDto> ListById(Guid id);
        Task<bool> Save();
        Task<ComplaintViewDto> Update(Guid drugID, ComplaintsUpdateDto drugUpdate);
    }
}
using AutoMapper;
using DrugVerizone.DbContexts;
using DrugVerizone.Entities;
using DrugVerizone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Services
{
    public class cComplaintsRepository : IComplaintsRepository
    {
        private readonly DrugVerifyContext _context;
        private readonly IMapper _mapper;

        public cComplaintsRepository(DrugVerifyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }


        public async Task<bool> Save()
        {
            return await Task.Run(async () =>
            {
                return (await _context.SaveChangesAsync() >= 0);
            });
        }



        public async Task<IEnumerable<ComplaintViewDto>> Get()
        {
            return await Task.Run(async () =>
            {
                var result = await _context.Complaint.ToListAsync<Complaints>();
                return _mapper.Map<IEnumerable<ComplaintViewDto>>(result);

            });


        }

        public async Task<ComplaintViewDto> ListById(Guid id)
        {
            return await Task.Run(async () =>
           {
               if (id == Guid.Empty)
               {
                   throw new ArgumentNullException(nameof(id));
               }

               var result = await _context.Complaint.Where(x => x.Id == id).FirstOrDefaultAsync();

               return _mapper.Map<ComplaintViewDto>(result);
           });



        }

        public async Task<ComplaintViewDto> Create(ComplaintsCreateDto drugs)
        {
            return await Task.Run(async () =>
            {
                if (drugs == null)
                {
                    throw new ArgumentNullException(nameof(drugs));
                }
                var drugEntity = _mapper.Map<Complaints>(drugs);
                drugEntity.Id = Guid.NewGuid();
                drugEntity.complaintDate = DateTime.Now;
                _context.Complaint.Add(drugEntity);

                bool saveDrug = await Save();
                return _mapper.Map<ComplaintViewDto>(drugEntity);
            });
        }



        public async Task<ComplaintViewDto> Update(Guid drugID, ComplaintsUpdateDto drugUpdate)
        {
            return await Task.Run(async () =>
            {
                if (drugUpdate == null)
                {
                    throw new ArgumentNullException(nameof(drugUpdate));
                }
                var drugEntity = await _context.Complaint.FirstOrDefaultAsync(c => c.Id == drugID);
                if (drugEntity == null)
                {
                    throw new ArgumentNullException(nameof(drugEntity));
                }
                var result = _mapper.Map(drugUpdate, drugEntity);

                bool save = await Save();

                return _mapper.Map<ComplaintViewDto>(result);
            });
        }



        public async Task<ComplaintViewDto> Delete(Guid drugID)
        {
            return await Task.Run(async () =>
            {
                var value = await _context.Complaint.FirstOrDefaultAsync(d => d.Id == drugID);

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(drugID));
                }

                _context.Complaint.Remove(value);

                await Save();

                return _mapper.Map<ComplaintViewDto>(value);
            });
        }




        public async Task<bool> DrugExist(Guid drugId)
        {
            return await Task.Run(async () =>
            {
                if (drugId == Guid.Empty)
                {
                    throw new ArgumentNullException(nameof(drugId));
                }
                return await _context.Complaint.AnyAsync(d => d.Id == drugId);
            });
        }


    }
}

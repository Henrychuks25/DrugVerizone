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
    public class cDrugsRepository : IDrugsRepository
    {
        private readonly DrugVerifyContext _context;
        private readonly IMapper _mapper;

        public cDrugsRepository(DrugVerifyContext context, IMapper mapper)
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

       

        public async Task<IEnumerable<DrugsViewDto>> Get()
        {
            return await Task.Run(async () =>
            {
                var result = await _context.Drugs.Include(m => m.Manufacturer).ToListAsync<Drugs>();
                return _mapper.Map<IEnumerable<DrugsViewDto>>(result);

            }); 


        }

        public async Task<DrugsViewDto> ListById(Guid id)
        {
            return await Task.Run(async () =>
           {
               if (id == Guid.Empty)
               {
                   throw new ArgumentNullException(nameof(id));
               }

               var result = await _context.Drugs.Where(x => x.Id == id).FirstOrDefaultAsync();

               return _mapper.Map<DrugsViewDto>(result);
           });
          

         
        }
      
        public async Task<DrugsViewDto> Create(DrugCreateDto drugs)
        {
            return await Task.Run(async () =>
            {
                if(drugs == null)
                {
                    throw new ArgumentNullException(nameof(drugs));
                }
                var drugEntity = _mapper.Map<Drugs>(drugs);
                drugEntity.Id = Guid.NewGuid();
                drugEntity.RegisteredDate = DateTime.Now;
                _context.Drugs.Add(drugEntity);

                bool saveDrug = await Save();
                return _mapper.Map<DrugsViewDto>(drugEntity);
            });
        }

       

        public async Task<DrugsViewDto> Update(Guid drugID, DrugUpdateDto drugUpdate)
        {
            return await Task.Run(async () =>
            {
                if(drugUpdate == null)
                {
                    throw new ArgumentNullException(nameof(drugUpdate));
                }
                var drugEntity = await _context.Drugs.FirstOrDefaultAsync(c => c.Id == drugID);
                if(drugEntity == null)
                {
                    throw new ArgumentNullException(nameof(drugEntity));
                }
                var result = _mapper.Map(drugUpdate, drugEntity);

                bool save = await Save();

                return _mapper.Map<DrugsViewDto>(result);
            });
        }

        

        public async Task<DrugsViewDto> Delete(Guid drugID)
        {
            return await Task.Run(async () =>
            {
                var value = await _context.Drugs.FirstOrDefaultAsync(d => d.Id == drugID);

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(drugID));
                }

                _context.Drugs.Remove(value);

                await Save();

                return _mapper.Map<DrugsViewDto>(value);
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
                return await _context.Drugs.AnyAsync(d => d.Id == drugId);
            });
        }
    }
}

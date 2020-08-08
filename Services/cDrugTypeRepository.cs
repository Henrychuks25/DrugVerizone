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
    public class cDrugTypeRepository : IDrugTypeRepository
    {
        private readonly DrugVerifyContext _context;
        private readonly IMapper _mapper;

        public cDrugTypeRepository(DrugVerifyContext context, IMapper mapper)
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

       

        public async Task<IEnumerable<DrugTypeViewDto>> Get()
        {
            return await Task.Run(async () =>
            {
                var result = await _context.DrugType.ToListAsync<DrugTypes>();
                return _mapper.Map<IEnumerable<DrugTypeViewDto>>(result);

            }); 


        }

        public async Task<DrugTypeViewDto> ListById(Guid id)
        {
            return await Task.Run(async () =>
           {
               if (id == Guid.Empty)
               {
                   throw new ArgumentNullException(nameof(id));
               }

               var result = await _context.DrugType.Where(x => x.Id == id).FirstOrDefaultAsync();

               return _mapper.Map<DrugTypeViewDto>(result);
           });
          

         
        }
      
        public async Task<DrugTypeViewDto> Create(DrugTypeCreateDto drugs)
        {
            return await Task.Run(async () =>
            {
                if(drugs == null)
                {
                    throw new ArgumentNullException(nameof(drugs));
                }
                var drugEntity = _mapper.Map<DrugTypes>(drugs);
                drugEntity.Id = Guid.NewGuid();
               // drugEntity.RegisteredDate = DateTime.Now;
                _context.DrugType.Add(drugEntity);

                bool saveDrug = await Save();
                return _mapper.Map<DrugTypeViewDto>(drugEntity);
            });
        }

       

        public async Task<DrugTypeViewDto> Update(Guid drugID, DrugTypeUpdateDto drugUpdate)
        {
            return await Task.Run(async () =>
            {
                if(drugUpdate == null)
                {
                    throw new ArgumentNullException(nameof(drugUpdate));
                }
                var drugEntity = await _context.DrugType.FirstOrDefaultAsync(c => c.Id == drugID);
                if(drugEntity == null)
                {
                    throw new ArgumentNullException(nameof(drugEntity));
                }
                var result = _mapper.Map(drugUpdate, drugEntity);

                bool save = await Save();

                return _mapper.Map<DrugTypeViewDto>(result);
            });
        }

        

        public async Task<DrugTypeViewDto> Delete(Guid drugID)
        {
            return await Task.Run(async () =>
            {
                var value = await _context.DrugType.FirstOrDefaultAsync(d => d.Id == drugID);

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(drugID));
                }

                _context.DrugType.Remove(value);

                await Save();

                return _mapper.Map<DrugTypeViewDto>(value);
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
                return await _context.DrugType.AnyAsync(d => d.Id == drugId);
            });
        }

       
    }
}

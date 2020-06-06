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
    public class cManufacturerRepository : IManufacturerRepository
    {
        private readonly DrugVerifyContext _context;
        private readonly IMapper _mapper;

        public cManufacturerRepository(DrugVerifyContext context, IMapper mapper)
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



        public async Task<IEnumerable<ManufacturerViewDto>> Get()
        {
            return await Task.Run(async () =>
            {
                var result = await _context.Manufacturers.Include(m => m.Drugs).ToListAsync<Manufacturer>();
                return _mapper.Map<IEnumerable<ManufacturerViewDto>>(result);

            });


        }

        public async Task<ManufacturerViewDto> ListById(Guid id)
        {
            return await Task.Run(async () =>
           {
               if (id == Guid.Empty)
               {
                   throw new ArgumentNullException(nameof(id));
               }

               var result = await _context.Manufacturers.Where(x => x.Id == id).FirstOrDefaultAsync();

               return _mapper.Map<ManufacturerViewDto>(result);
           });



        }

        public async Task<ManufacturerViewDto> Create(ManufacturerCreateDto man)
        {
            return await Task.Run(async () =>
            {
                if (man == null)
                {
                    throw new ArgumentNullException(nameof(man));
                }
                var drugEntity = _mapper.Map<Manufacturer>(man);
                drugEntity.Id = Guid.NewGuid();
                drugEntity.RegistrationDate = DateTime.Now;
                _context.Manufacturers.Add(drugEntity);

                bool saveDrug = await Save();
                return _mapper.Map<ManufacturerViewDto>(drugEntity);
            });
        }



        public async Task<ManufacturerViewDto> Update(Guid manID, ManufacturerUpdateDto drugUpdate)
        {
            return await Task.Run(async () =>
            {
                if (drugUpdate == null)
                {
                    throw new ArgumentNullException(nameof(drugUpdate));
                }
                var drugEntity = await _context.Manufacturers.FirstOrDefaultAsync(c => c.Id == manID);
                if (drugEntity == null)
                {
                    throw new ArgumentNullException(nameof(drugEntity));
                }
                var result = _mapper.Map(drugUpdate, drugEntity);

                bool save = await Save();

                return _mapper.Map<ManufacturerViewDto>(result);
            });
        }



        public async Task<ManufacturerViewDto> Delete(Guid manID)
        {
            return await Task.Run(async () =>
            {
                var value = await _context.Manufacturers.FirstOrDefaultAsync(d => d.Id == manID);

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(manID));
                }

                _context.Manufacturers.Remove(value);

                await Save();

                return _mapper.Map<ManufacturerViewDto>(value);
            });
        }




        public async Task<bool> ManufacturerExist(Guid manId)
        {
            return await Task.Run(async () =>
            {
                if (manId == Guid.Empty)
                {
                    throw new ArgumentNullException(nameof(manId));
                }
                return await _context.Manufacturers.AnyAsync(d => d.Id == manId);
            });
        }
    }
}

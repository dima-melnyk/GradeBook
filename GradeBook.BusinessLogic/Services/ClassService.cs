using AutoMapper;
using GradeBook.Models.Read;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.DataAccess.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GradeBook.DataAccess;
using System;

namespace GradeBook.BusinessLogic.Services
{
    public class ClassService : IClassService
    {
        private readonly GBContext _context;
        private readonly IMapper _mapper;

        public ClassService(GBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateClass(Class newClass)
        {
            await _context.AddAsync(newClass);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClass(int id)
        {
            var model = await _context.Classes.FirstOrDefaultAsync(c => c.Id == id);
            if (model == null)
                throw new ArgumentNullException("Entity does not found");

            _context.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<ClassModel> GetClass(int id)
        {
            var model = await _context.Classes.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<ClassModel>(model);
        }

        public async Task<IEnumerable<ClassModel>> GetClasses() => (await _context.Classes.ToListAsync()).Select(_mapper.Map<ClassModel>);
    }
}

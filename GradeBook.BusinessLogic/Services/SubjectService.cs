using AutoMapper;
using GradeBook.BusinessLogic.Interfaces;
using GradeBook.DataAccess;
using GradeBook.DataAccess.Entities;
using GradeBook.Models.Read;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook.BusinessLogic.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly GBContext _context;
        private readonly IMapper _mapper;

        public SubjectService(GBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubjectModel>> GetSubjects() => 
            (await _context.Subjects.ToListAsync()).Select(_mapper.Map<SubjectModel>);

        public async Task CreateSubject(Subject newSubject) 
        {
            await _context.AddAsync(newSubject);
            await _context.SaveChangesAsync();
        }
    }
}

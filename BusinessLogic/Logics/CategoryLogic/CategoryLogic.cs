using AutoMapper;
using BusinessLogic.Models.DTO.CategoryDTO;
using Data.Entities;
using Data.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logics.CategoryLogic
{
    public class CategoryLogic
    {
        public CategoryLogic(IGenericRepository<Category> genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }

        public IGenericRepository<Category> _genericRepo { get; }
        public IMapper _mapper { get; }

        public async Task<bool> AddCategory(CategoryAddUIDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO); 
            await _genericRepo.AddAndCommit(category);
            return true;
        }
    }
}

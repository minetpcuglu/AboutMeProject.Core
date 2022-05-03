using AboutMeProject.Application.Models.DTOs;
using AboutMeProject.Application.Services.Interface;
using AboutMeProject.Domain.Repository.EntityTypeRepository;
using AboutMeProject.Domain.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Services.Concrete
{
   public class ToDoListService : IToDoListService
    {
        private readonly IToDoListRepository _todolistRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ToDoListService(IToDoListRepository todolistRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _todolistRepository = todolistRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task Add(ToDoListDTO t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ToDoListDTO>> GetAll()
        {
            var DoList = await _unitOfWork.ToDoListRepository.GetAll();
            var list = _mapper.Map<List<ToDoListDTO>>(DoList);
            await _unitOfWork.Commit();
            //var newList = hobbyList.AsQueryable().Select(x => new HobbyDTO { Id = x.Id, MyHobby = x.MyHobby }); automapper kullanmazsak
            return list;
        }

        public Task<ToDoListDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ToDoListDTO t)
        {
            throw new NotImplementedException();
        }
    }
}

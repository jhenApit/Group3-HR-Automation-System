﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Basecode.Data.Dtos;
using Basecode.Data.Dtos.Address;
using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using static Basecode.Services.Services.ErrorHandling;

namespace Basecode.Services.Services
{
    public class AddressService : ErrorHandling, IAddressService
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;
        private readonly LogContent _logContent = new();

        public AddressService(IAddressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<Address> RetrieveAll()
        {
            return _repository.RetrieveAll().ToList();
        }

        public void Add(AddressCreationDto AddressDto)
        {
            var AddressModel = _mapper.Map<Address>(AddressDto);
            AddressModel.CreatedBy = System.Environment.UserName;
            AddressModel.CreatedDate = DateTime.Now;
            AddressModel.ModifiedBy = System.Environment.UserName;
            AddressModel.ModifiedDate = DateTime.Now;
            AddressModel.IsDeleted = false;

            _repository.Add(AddressModel);
        }

        public Address GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(AddressUpdationDto Address)
        {
            var AddressModel = _mapper.Map<Address>(Address);

            // Update only the properties that should be modified
            AddressModel.Name = Address.Name;
            AddressModel.Email = Address.Email;
            AddressModel.Password = Address.Password;
            AddressModel.ModifiedBy = System.Environment.UserName;
            AddressModel.ModifiedDate = DateTime.Now;

            _repository.Update(AddressModel);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Address GetByCity(string city)
        {
            return _repository.GetByCity(city);
        }

        
    }
}

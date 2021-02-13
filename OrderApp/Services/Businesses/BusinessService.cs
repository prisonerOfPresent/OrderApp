using Optional;
using OrderApp.Data.Entities;
using OrderApp.Data.Repositories.Businesses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderApp.Services.Businesses
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepository _repository;

        public BusinessService(IBusinessRepository repository)
        {
            _repository = repository;
        }

        public async Task<Option<Business>> Get(Business example)
        {
            return await _repository.FindByID(example.BusinessID);
        }

        public async Task<ICollection<Business>> GetAll()
        {
            var businesses = await _repository.FindAll();
            return businesses;
        }

        public Task<Option<Business>> Modify(Business entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Option<Business>> Save(Business entity)
        {
            if ( entity != null )
            {
                return await _repository.Save(entity);
            }
            return Option.None<Business>();
        }

        public Task<ICollection<Business>> SaveAll(ICollection<Business> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Option<Business>> Update(Business entity)
        {
            throw new NotImplementedException();
        }
    }
}

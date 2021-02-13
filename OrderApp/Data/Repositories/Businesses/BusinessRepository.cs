using Optional;
using OrderApp.Constants;
using OrderApp.Data.ConnectionTemplates;
using OrderApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Data.Repositories.Businesses
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly OrderAppDbContext _dbContext;
        private readonly AdoTemplate<Business> _adoTemplate;

        public BusinessRepository(OrderAppDbContext dbContext, AdoTemplate<Business> adoTemplate) 
        {
           _dbContext = dbContext;
            _adoTemplate = adoTemplate;

        }

        public async Task<bool> Delete(Business entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteInBatch(List<Business> entitiesToDelete)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Business>> FindAll()
        {
            var businesses = await _adoTemplate.Query("SELECT * from `business`");
            if ( businesses != null )
            {
                return businesses;
            }
            return null;
        }

        public async Task<Option<Business>> FindByID(string id)
        {
            var business = await _adoTemplate.QueryForObject("SELECT * from `business` WHERE `BusinessID`='" + id + "'");
            return business;
        }

        public async Task<Option<Business>> Modify(Business entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Option<Business>> Save(Business entity)
        {
            // do some validation first
            if (ValidateBusinessRequest(entity, CrudOperationTypes.CREATE)) 
            {
                entity.BusinessID = Guid.NewGuid().ToString();
                entity.CreatedDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                entity.ModifiedDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                var savedEntity = _dbContext.Add(entity);
                await _dbContext.SaveChangesAsync();
                if (savedEntity != null)
                {
                    return Option.Some(savedEntity.Entity);
                }
            }
            return Option.None<Business>();
        }

        public async Task<List<Business>> SaveAll(List<Business> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<Option<Business>> Update(Business entity)
        {
            throw new NotImplementedException();
        }


        // ToDo : Validate the entity according to the type
        private bool ValidateBusinessRequest(Business entity, CrudOperationTypes operation)
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(entity.Name)) isValid = false;
            return isValid;
        }
    }
}

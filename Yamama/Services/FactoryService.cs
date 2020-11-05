using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Yamama.Repository;

namespace Yamama.Services
{
    public class FactoryService : IFactory
    {
        //create instance from dbcontext class
        private readonly yamamadbContext _db;

        public FactoryService(yamamadbContext db)
        {
            _db = db;
        }
        // function to add new factory
        public async  Task<int> AddFactoryAsync(Factory factory)
        {
           int result = 0;
         // add new factory
           await _db.Factory.AddAsync(factory);
         //if the operation succecced return 1
            result += 1;
            return result;
     
        }

        //function to delete factory by id 
        public async Task<int> DeleteFactoryAsync(int id)
        {
            int result = 0;
            //check if the dbcontext is not null
            if (_db != null)
            {
               // if not find the specified factory
                var factory = await _db.Factory.FirstOrDefaultAsync(p => p.Idfactory == id);

                //check the returned value is not null
                if (factory != null)
               // if it not null delete the specified factory
                _db.Factory.Remove(factory);

                //commit the changes on database
                await _db.SaveChangesAsync();
                //if the operation succecced return 1
                result += 1;
                return result;

            }
            return result;
        }
        // function to get all factories
        public async Task <List<Factory>> GetFactories()
        {
            //check if the dbcontext is not null
            if (_db != null)
            {
                // if not find all factories
                return await _db.Factory.ToListAsync();
            }

            return null;
        }
        //function to get specific factory by id
        public async Task <Factory> GetFactory(int id)
        {
            //get all factories
            return   await _db.Factory.FirstOrDefaultAsync(f => f.Idfactory == id);
           
        }


        //function to edit records from factory table
        public async Task<int> UpdateFactory(int id, Factory factory)
        {
            int result = 0;
            //check if the dbcontext is not null
            if (_db != null)
            {
                //if not create a new object from  specific factory 
                Factory existFactory =  await _db.Factory.Where(f => f.Idfactory == id).FirstOrDefaultAsync();

                //check if the returned object  is not null
                if (existFactory != null)
                {
                   
                    existFactory.Name = factory.Name;
                    existFactory.Location = factory.Location;
                    existFactory.ActivityNature = factory.ActivityNature;
                    existFactory.ProductId = factory.ProductId;
                    existFactory.CementPrice = factory.CementPrice;
                    existFactory.TransporterId = factory.TransporterId;
                    existFactory.Notes = factory.Notes;
                    existFactory.InformationSource = factory.InformationSource;
                }
                //edit the  returned object with new changes
                _db.Factory.Update(existFactory);

                //commit changes
                await _db.SaveChangesAsync();
                result += 1;
                return result;

            }
            return result;
        }
    }
}

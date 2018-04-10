using api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Business
{
    public class BaseBusiness<T> where T : class
    {
        private readonly IDataRepository<T> _baseRepository;

        public BaseBusiness(IDataRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public BaseBusiness()
        {
        }

        public Task Create(T item)
        {
            return _baseRepository.Create(item);
        }

        public async Task<int> Update(T item)
        {
            return await _baseRepository.UpdateAndSaveAsync(item);
        }

        public void Delete(T item)
        {
            _baseRepository.Remove(item);
        }
    }
}

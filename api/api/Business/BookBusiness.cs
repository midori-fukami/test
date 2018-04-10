using api.Entity;
using api.Proxy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Business
{
    public class BookBusiness : BaseBusiness<BookEntity>
    {
        private readonly BookRepository _repository;

        public BookBusiness(BookRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public List<BookProxy> Get()
        {
            var list = _repository.GetAll().Select(o => new BookProxy
            {
                Id = o.Id,
                Name = o.Name,
                Code = o.Code,
                Count = o.Count
            });

            list = list.OrderBy(o => o.Name);

            return list.ToList();
        }

        public async Task<BookEntity> AddBook(BookProxy payload)
        {
            var userId = Guid.NewGuid();

            var model = new BookEntity()
            {
                Id = Guid.NewGuid(),
                Name = payload.Name,
                Code = payload.Code,
                Count = payload.Count
            };

            try
            {
                await _repository.AddAndSaveAsync(model);
            }
            catch (Exception ex)
            {
                return model;
            }

            return model;
        }

        public async Task<BookEntity> UpdateBook(Guid id, BookEntity payload)
        {
            var model = await _repository.GetAll().FirstOrDefaultAsync(f => f.Id == id);

            model.Name = payload.Name;
            model.Code = payload.Code;
            model.Count = payload.Count;

            await _repository.UpdateAndSaveAsync(model);

            return payload;
        }

        public async Task<BookEntity> Get(Guid id)
        {
            return await _repository.GetAll().FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<BookEntity> Delete(Guid id)
        {
            var model = await _repository.FirstOrDefaultAsync(f => f.Id == id);

            if (model != null)
                await _repository.RemoveAndSaveAsync(model);

            return model;
        }
    }
}
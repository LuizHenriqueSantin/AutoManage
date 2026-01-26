using AutoManage.Application.DTOs.Owner;
using AutoManage.Application.Interfaces.Queries;
using AutoManage.Domain.Interfaces.Repositories;

namespace AutoManage.Application.Queries
{
    public class OwnerQuery : IOwnerQuery
    {
        private readonly IOwnerRepository _repository;

        public OwnerQuery(IOwnerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<OwnerOut>> GetAll()
        {
            var list = await _repository.GetAll();

            return list.Select(x => new OwnerOut
                {
                    Name = x.Name,
                    CpfCnpj = x.CpfCnpj != null ? x.CpfCnpj.ToString() : string.Empty,
                    Address = x.Address,
                    Email = x.Email != null ? x.Email.ToString() : string.Empty,
                    PhoneNumber = x.PhoneNumber != null ? x.PhoneNumber.ToString() : string.Empty,
                }).ToList();
        }

        public async Task<OwnerOut?> GetByCpfCnpj(string cpfCnpj)
        {
            var entity = await _repository.GetByCpfCnpj(cpfCnpj);

            if (entity == null) return null;

            var owner = new OwnerOut
            {
                Name = entity.Name,
                CpfCnpj = entity.CpfCnpj != null ? entity.CpfCnpj.ToString() : string.Empty,
                Address = entity.Address,
                Email = entity.Email != null ? entity.Email.ToString() : string.Empty,
                PhoneNumber = entity.PhoneNumber != null ? entity.PhoneNumber.ToString() : string.Empty,
            };

            return owner;
        }
    }
}

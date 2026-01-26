using AutoManage.Application.DTOs.Owner;
using AutoManage.Application.DTOs.Vehicle;
using AutoManage.Application.Interfaces.Queries;
using AutoManage.Domain.Enums;
using AutoManage.Domain.Interfaces.Repositories;

namespace AutoManage.Application.Queries
{
    public class VehicleQuery : IVehicleQuery
    {
        private readonly IVehicleRepository _repository;

        public VehicleQuery(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<VehicleOut>> GetAll()
        {
            var list = await _repository.GetAll();

            return list.Select(x => new VehicleOut
                {
                    Chassis = x.Chassis,
                    Model = x.Model,
                    Year = x.Year,
                    Color = x.Color,
                    Price = x.Price,
                    Mileage = x.Mileage,
                    SystemVersion = x.SystemVersion,
                }).ToList();
        }

        public async Task<List<VehicleOut>> GetBySystemVersion(SystemVersion version)
        {
            var list = await _repository.GetBySystemVersion(version);

            return list.Select(x => new VehicleOut
                {
                    Chassis = x.Chassis,
                    Model = x.Model,
                    Year = x.Year,
                    Color = x.Color,
                    Price = x.Price,
                    Mileage = x.Mileage,
                    SystemVersion = x.SystemVersion,
                }).OrderBy(x => x.Mileage)
                .ToList();
        }

        public async Task<VehicleOut?> GetWithOwner(Guid id)
        {
            var entity = await _repository.GetWithOwner(id);

            if (entity == null) return null;

            var result = new VehicleOut
            {
                Chassis = entity.Chassis,
                Model = entity.Model,
                Year = entity.Year,
                Color = entity.Color,
                Price = entity.Price,
                Mileage = entity.Mileage,
                SystemVersion = entity.SystemVersion,
                Owner = entity.Owner != null ? new OwnerOut
                {
                    Name = entity.Owner.Name,
                    CpfCnpj = entity.Owner.CpfCnpj != null ? entity.Owner.CpfCnpj.ToString() : string.Empty,
                    Address = entity.Owner.Address,
                    Email = entity.Owner.Email != null ? entity.Owner.Email.ToString() : string.Empty,
                    PhoneNumber = entity.Owner.PhoneNumber != null ? entity.Owner.PhoneNumber.ToString() : string.Empty,
                } : null,
            };

            return result;
        }
    }
}

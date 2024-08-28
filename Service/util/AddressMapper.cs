using DataModels.DTOs;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.util
{
    public static class AddressMapper
    {
        public static AddressModel ToModel(this AddressDTO dto)
        {
            if (dto == null) return null;

            return new AddressModel
            {
                Id = dto.Id,
                Street = dto.Street,
                City = dto.City,
                State = dto.State,
                Primary = dto.Primary,
                ContactId = dto.ContactId,
            };
        }

        // Map from AddressModel to AddressDTO
        public static AddressDTO ToDTO(this AddressModel model)
        {
            if (model == null) return null;

            return new AddressDTO
            {
                Id = model.Id,
                Street = model.Street,
                City = model.City,
                State = model.State,
                Primary = model.Primary,
                ContactId = model.ContactId,
            };
        }

        public static ICollection<AddressDTO> listToDTO(this IEnumerable<AddressModel> model)
        {
            List< AddressDTO > lista= new List< AddressDTO >();
            foreach (var a in model)
            {
                lista.Add( ToDTO(a));
            }
            return lista;
        }
    }
}

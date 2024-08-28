using DataModels.DTOs;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.util
{
    public static class ContactMapper
    {
        public static ContactDTO ToDTO(this ContactModel model)
        {
            if (model == null) 
                return null;
            return new ContactDTO
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }

        public static ContactModel ToModel(this ContactDTO dto)
        {
            return new ContactModel
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
        }

        public static ContactTableDTO ToDTOTable(this ContactModel model)
        {
            if (model == null)
                return null;
            var primaryPhone = model.PhoneNumbers?.FirstOrDefault(a => a.Primary == true);
            var primaryAddress = model.Addresses?.FirstOrDefault(a => a.Primary == true);

            return new ContactTableDTO
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Number = primaryPhone?.Number ?? "",
                Street = primaryAddress?.Street ?? ""
            };
        }
    }
}

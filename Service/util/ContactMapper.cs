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
    }
}

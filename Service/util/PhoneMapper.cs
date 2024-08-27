using DataModels.DTOs;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.util
{
    public static class PhoneMapper
    {
        public static PhoneDTO ToDTO(this PhoneModel model)
        {
            if (model == null) return null;

            return new PhoneDTO
            {
                Id = model.Id,
                Number = model.Number,
                Primary = model.Primary,
                ContactId = model.ContactId
            };
        }

        // Map from PhoneDTO to PhoneModel
        public static PhoneModel ToModel(this PhoneDTO dto)
        {
            if (dto == null) return null;

            return new PhoneModel
            {
                Id = dto.Id,
                Number = dto.Number,
                Primary = dto.Primary,
                ContactId = dto.ContactId,
                Contact = null  // Optional: Assign null or load the contact separately as needed
            };
        }

        public static ICollection<PhoneDTO> listToDTO(this IEnumerable<PhoneModel> model)
        {
            List<PhoneDTO> lista = new List<PhoneDTO>();
            foreach (var a in model)
            {
                lista.Add(ToDTO(a));
            }
            return lista;
        }
    }

}

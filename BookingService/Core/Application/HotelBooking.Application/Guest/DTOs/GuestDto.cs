using HotelBooking.Domain.Enums;

namespace HotelBooking.Application.Guest.DTOs;

public class GuestDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string DocumentId { get; set; }
    public int IdTypeCode { get; set; }

    public static Domain.Entities.Guest MapToEntity(GuestDto dto)
    {
        return new Domain.Entities.Guest
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Email = dto.Email,
            Document = new Domain.ValueObjects.PersonId
            {
                IdNumber = dto.DocumentId,
                DocumentType =  (DocumentType)dto.IdTypeCode
            }
        };
    }
}
using HotelBooking.Domain.Exceptions;
using HotelBooking.Domain.Ports;
using HotelBooking.Domain.ValueObjects;

namespace HotelBooking.Domain.Entities;

public class Guest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public PersonId Document { get; set; }

    private void ValidateState()
    {
        if (Document == null || string.IsNullOrEmpty(Document.IdNumber) || Document.IdNumber.Length <= 3 || Document.DocumentType == 0)
        {
            throw new InvalidDocumentException();
        }

        if (String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Surname) || Email == null)
        {
            throw new MissingRequiredInformation();
        }
    }

    public async Task Save(IGuestRepository repository)
    {
        this.ValidateState();
        if (this.Id == 0)
        {
            await repository.Create(this);
        }
        else
        {
            //await repository.Update();
        }
    }
}
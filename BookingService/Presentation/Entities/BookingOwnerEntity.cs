﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Presentation.Entities;

public class BookingOwnerEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString(); 
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;

    [ForeignKey(nameof(Address))]


    public string? BookingAdressId { get; set; } = null!;
    public BookingAddressEntity? Address { get; set; } 
}

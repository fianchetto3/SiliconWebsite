

using Microsoft.EntityFrameworkCore;
using SiliconInfrastructure.Context;
using SiliconInfrastructure.Entities;

namespace SiliconInfrastructure.Services;

public class AddressManager(AppDbContext context)
{
    private readonly AppDbContext _context = context;



    public async Task<AddressEntity> GetAddressAsync(string userId)
    {
        var user = await _context.Users
           .Include(u => u.Address)
           .FirstOrDefaultAsync(u => u.Id == userId);

 
        if (user == null)
        {
            return null!;
        }

        return user.Address!;
    }

    public async Task<bool> CreateAddressAsync(AddressEntity entity)
    {

        var existingAddress = await _context.Addresses.FirstOrDefaultAsync(a => a.StreetName == entity.StreetName && a.City == entity.City && a.PostalCode == entity.PostalCode);
        if (existingAddress != null)
        {
            // Adressen finns redan i databasen, inget behov av att skapa en ny
            return false;
        }

        _context.Addresses.Add(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAddressAsync(AddressEntity entity)
    {
        var existingAddress = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == entity.Id);
        if (existingAddress == null)
        {
            // Adressen finns inte i databasen
            return false;
        }

      
        existingAddress.StreetName = entity.StreetName;
        existingAddress.City = entity.City;
        existingAddress.PostalCode = entity.PostalCode;

        await _context.SaveChangesAsync();
        return true;
    }
}




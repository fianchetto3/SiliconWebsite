
using Infrastructure.Context;
using Infrastructure.Entities;

namespace Infrastructure.Repo;

 public class AddressRepository(DataContext context) : Repo<AddressEntity>(context)
{
    private readonly DataContext _context = context;
}

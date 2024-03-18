
using Infrastructure.Factories;
using Infrastructure.Model;
using Infrastructure.Repo;

namespace Infrastructure.Services;

public class AddressService(AddressRepository addressRepository)
{
    private readonly AddressRepository _addressRepository = addressRepository;


    public async Task<ResponseResult> CreateAddressAsync(string streetName, string postalCode, string city)
    {
        try
        {
            var exists = await _addressRepository.EntityExistAsync(x =>  x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            if(exists == null)
            {
                var result = await _addressRepository.CreateOneAsync(AddressFactory.Create(streetName, postalCode, city));
                if(result.StatusCode == StatusCode.OK)
                {
                    var response = ResponseFactory.Ok(AddressFactory.Create(result.ContentResult));
                }
            }
        }

        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }
    public async Task<ResponseResult> GetAddressAsync(string streetName, string postalCode, string city)
    {
        try
        {

            var result = await _addressRepository.GetOneAsync(x=>x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            return result;
        }

        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }
    public async Task<ResponseResult> GetAllAddressAsync()
    {
        try
        {


        }

        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }

}

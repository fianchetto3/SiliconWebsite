using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Model;
using Infrastructure.Repo;

namespace Infrastructure.Services;

public class UserService(UserRepository repository, AddressService addressService,DataContext context )
{
    private readonly UserRepository _repository = repository;
    private readonly AddressService _addressService = addressService;
    private readonly DataContext _context = context;



    public async Task<ResponseResult> CreateUserAsync(SignUpModel model)
    {
        try
        {

            var exists = await _repository.EntityExistAsync(x => x.Email == model.Email);
             if(exists.StatusCode == StatusCode.EXISTS)
                return exists;

            var result = await _repository.CreateOneAsync(UserFactory.Create(model));
            if (result.StatusCode != StatusCode.OK)
            {
                return result;
            }
               


                return ResponseFactory.Ok("User was Created Successfully");

            
        }

        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }

    public async Task<UserModel> SignInAsync(SignInModel model)
    {
        try
        {
            var result = await _repository.GetOneAsync(x => x.Email == model.Email);

            var userEntity = (UserEntity)result.ContentResult!;
            if (userEntity != null)
            {
                if (PasswordHasher.ValidateSecurePassword(model.Password, userEntity.Password, userEntity.SecurityKey!))
                {
                    return new UserModel
                    {
                        Id = userEntity.Id,
                        FirstName = userEntity.FirstName,
                        LastName = userEntity.LastName,
                        Email = userEntity.Email
                    };
                }
            }
        }
        catch (Exception ex)
        {
            // Hantera undantag, logga eller rapportera fel
            Console.WriteLine($"An error occurred during sign-in: {ex.Message}");
        }

        return null;
    }
}




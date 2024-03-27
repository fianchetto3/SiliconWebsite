using Azure;
using Infrastructure.Entities;
using Infrastructure.Helpers;
using Infrastructure.Model;
using Infrastructure.Repo;

namespace Infrastructure.Factories
{
    public class UserFactory(UserRepository repository)
    {
        private readonly UserRepository _repository = repository;

        public static UserEntity Create()
        {
            try
            {
                var date = DateTime.Now;

                return new UserEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Created = date,
                    Modified = date,


                };



            }
            catch { }
            return null!;

        }

        public static UserEntity Create(SignUpModel model)
        {
            try
            {
                var date = DateTime.Now;
                var (password, securityKey) = PasswordHasher.GenerateSecurePassword(model.Password);


                return new UserEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = password,
                    SecurityKey = securityKey,
                    Created = date,
                    Modified = date
                };



            }
            catch { }
            return null!;

        }
    }
}

using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Repositories;
using AlexaIOTInfraredRemoteAPI.Domain.Services;

namespace AlexaIOTInfraredRemoteAPI.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async void RegisterUser(User user)
        {
            _userRepository.RegisterUser(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}

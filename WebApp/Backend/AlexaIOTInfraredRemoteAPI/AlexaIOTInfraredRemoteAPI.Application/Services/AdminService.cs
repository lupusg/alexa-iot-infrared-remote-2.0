using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Repositories;
using AlexaIOTInfraredRemoteAPI.Domain.Services;

namespace AlexaIOTInfraredRemoteAPI.Application.Services
{
    public class AdminService: IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public async Task RegisterUser(User user)
        {
            _adminRepository.RegisterUser(user);
            await _adminRepository.SaveChangesAsync();
        }
    }
}

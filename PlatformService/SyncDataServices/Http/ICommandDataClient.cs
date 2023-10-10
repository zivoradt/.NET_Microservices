using PlatformService.Dto;

namespace PlatformService.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SentPlatformToCommand(PlatformReadDto platformReadDto);
    }
}
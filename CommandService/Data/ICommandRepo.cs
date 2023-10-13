using CommandService.Models;

namespace CommandService.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();

        // Platforms
        IEnumerable<Platform> GetAllPlatforms();

        void CreatePlatform(Platform platform);

        bool PlatformExist(int platformId);

        // Commands

        IEnumerable<Command> GetCommandsForPlatform(int platformID);

        Command GetCommand(int platformId, int commandID);

        void CreateCommand(int platformId, Command command);
    }
}
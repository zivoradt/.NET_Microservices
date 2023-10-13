using CommandService.Models;

namespace CommandService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _context;

        public CommandRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateCommand(int platformId, Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            command.PlatformID = platformId;

            _context.Commands.Add(command);
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }
            else
            {
                _context.Add(platform);
            }
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Command GetCommand(int platformId, int commandID)
        {
            return _context.Commands.Where(p => p.PlatformID == platformId && p.Id == commandID).FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandsForPlatform(int platformID)
        {
            return _context.Commands.Where(c => c.PlatformID == platformID).OrderBy(c => c.Platform.Name);
        }

        public bool PlatformExist(int platformId)
        {
            return (_context.Platforms.Any(p => p.Id == platformId));
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
using System.Linq;
using ThirdPartyTools;

namespace FileData
{
   public class FileDataCommand
    {
       private readonly string _cmd;
       private readonly string _filePath;
       private readonly string[] _versionCmds =  {"-v", "--v", "/v", "--version" };
       private readonly string[] _sizeCmds =  { "-s", "--s", "/s", "--size" };

        public FileDataCommand(string cmd , string filePath)
        {
            _cmd = cmd;
            _filePath = filePath;
        }

        public CommandType TypeOfCommand => GetCommandType(_cmd);

        private CommandType GetCommandType(string cmd)
        {
            if (_versionCmds.Contains(_cmd))
            {
                return CommandType.Version;
            }

            if (_sizeCmds.Contains(_cmd))
            {
                return CommandType.Size;
            }

            return CommandType.None;
        }

        public object Execute()
        {
            switch (TypeOfCommand)
            {
                case CommandType.Version:
                    return GetVersion();
                case CommandType.Size:
                    return GetSize();
                case CommandType.None:
                    break;
                
            }

            return string.Empty;
        }

        private int GetSize()
        {
            var fileDetails = new FileDetails();
            return fileDetails.Size(_filePath);
        }

        private string GetVersion()
        {
            var fileDetails = new FileDetails();
            return fileDetails.Version(_filePath);
        }
    }
}

public enum CommandType
{
    None,
    Version,
    Size
}

namespace Xxx.Application.Commands
{
    public class BazDto
    {
        public BazDto(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public string Code { get; private set; }

        public string Description { get; private set; }
    }
}

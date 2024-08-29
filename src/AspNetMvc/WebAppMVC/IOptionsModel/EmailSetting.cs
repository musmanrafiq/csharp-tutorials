using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.IOptionsModel
{
    public sealed class EmailSetting
    {

        public string Email { get; init; }
        [Range(1, int.MaxValue)]
        public int Frequency { get; init; }
    }
}

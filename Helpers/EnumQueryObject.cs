using System.ComponentModel.DataAnnotations;

namespace AvtoElon.API.Demo.Helpers
{
    public class EnumQueryObject
    {
        public Currency Currency { get; set; }
        public Category Category { get; set; }
        public Location Location { get; set; }
    }
}

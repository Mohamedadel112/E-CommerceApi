using System.Text.Json;

namespace Shared.ErrorsModel
{
    public class ErrorsDetails 
    {
        public int StatusCode { get; set; }
        public string MsgError { get; set; }
        public IEnumerable<string>? Errors { get; set; } 
        public override string ToString()  => JsonSerializer.Serialize(this);
    }
}

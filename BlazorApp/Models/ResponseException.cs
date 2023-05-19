namespace BlazorApp.Models
{
    public class ResponseException
    {
        public string Path { get; set; }
        public DateTime Timestamp { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Message { get; set; }
        public string Code { get; set; }
    }
}


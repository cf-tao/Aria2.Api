namespace Aria2.Api
{
    public class ChangeUriRequest
    {
        public string Gid { get; set; } = "";
        public string Uri { get; set; } = "";
        public int FileIndex { get; set; }
        public IList<string> DelUris { get; set; } = new List<string>();
        public IList<string> AddUris { get; set; } = new List<string>();
    }
}
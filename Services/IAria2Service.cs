using Aria2NET;

namespace Aria2.Api.Services
{
    public interface IAria2Service
    {
        Task<SessionResult> GetSessionInfo();

        Task<string> AddUriTaskAsync(string[] uris);

        Task<IDictionary<string, string>> GetGlobalOptionAsync();

        Task<IList<FileResult>> GetFilesAsync(string gid);

        Task<IList<DownloadStatusResult>> GetAllAsync();

        Task<IList<DownloadStatusResult>> GetActiveAsync();

        Task<IList<DownloadStatusResult>> GetWaitingAsync(int offset, int num);

        Task<IList<DownloadStatusResult>> GetStoppedAsync(int offset, int num);

        Task<DownloadStatusResult> GetStatusAsync(string gid);

        Task<string> PauseAsync(string gid, bool? force = false);

        Task<string> UnPauseAsync(string gid);

        Task<bool> PauseAllAsync(bool? force = false);

        Task<bool> UnpauseAllAsync();

        Task<string> AddTorrentAsync(byte[] torrent);

        Task<List<string>> AddMetalinkAsync(byte[] torrent);

        Task<string> RemoveAsync(string gid, bool? force = false);

        Task RemoveDownloadResultAsync(string gid);

        Task<VersionResult> GetVersionAsync();

        Task<IList<UriResult>> GetUrisAsync(string gid);

        Task<IList<PeerResult>> GetPeersAsync(string gid);

        Task<IList<ServerResult>> GetServersAsync(string gid);

        Task<int> ChangePositionAsync(string gid, int pos, ChangePositionHow how);

        Task<IDictionary<string, string>> GetOptionAsync(string gid);

        Task<IList<string>> ChangeUriAsync(string gid, int fileIndex, IList<string> delUris, IList<string> addUris);

        Task ChangeOptionAsync(string gid, IDictionary<string, string> options);

        Task ChangeGlobalOptionAsync(IDictionary<string, string> options);

        public Task PurgeDownloadResultAsync();

        public Task<GlobalStatResult> GetGlobalStatAsync();

        public Task<IList<string>> SaveSessionAsync();
    }
}
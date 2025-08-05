using Aria2NET;
using FileResult = Aria2NET.FileResult;

namespace Aria2.Api.Services
{
    public class Aria2Service : IAria2Service
    {
        private Aria2NetClient _client = new Aria2NetClient("http://localhost:6800/jsonrpc", "slb123");
        public Aria2Service()
        {

        }

        public Task<SessionResult> GetSessionInfo()
        {
            return _client.GetSessionInfo();
        }

        public Task<string> AddUriTaskAsync(string[] uris)
        {
            return _client.AddUriAsync(uris.ToList());
        }

        public Task<IDictionary<string, string>> GetGlobalOptionAsync()
        {
            return _client.GetGlobalOptionAsync();
        }

        public Task<IList<FileResult>> GetFilesAsync(string gid)
        {
            return _client.GetFilesAsync(gid);
        }


        public Task<IList<DownloadStatusResult>> GetAllAsync()
        {
            return _client.TellAllAsync();
        }

        public Task<IList<DownloadStatusResult>> GetActiveAsync()
        {
            return _client.TellActiveAsync();
        }

        public Task<IList<DownloadStatusResult>> GetWaitingAsync(int offset, int num)
        {
            return _client.TellWaitingAsync(offset, num);
        }
        public Task<IList<DownloadStatusResult>> GetStoppedAsync(int offset, int num)
        {
            return _client.TellStoppedAsync(offset, num);
        }

        public Task<DownloadStatusResult> GetStatusAsync(string gid)
        {
            return _client.TellStatusAsync(gid);
        }

        public Task<string> PauseAsync(string gid, bool? force = false)
        {
            if (force == true)
            {
                return _client.ForcePauseAsync(gid);
            }
            return _client.PauseAsync(gid);
        }

        public Task<string> UnPauseAsync(string gid)
        {
            return _client.UnpauseAsync(gid);
        }

        public Task<bool> PauseAllAsync(bool? force = false)
        {
            if (force == true)
            {
                return _client.ForcePauseAllAsync();
            }
            return _client.PauseAllAsync();
        }

        public Task<bool> UnpauseAllAsync()
        {
            return _client.UnpauseAllAsync();
        }

        public Task<string> AddTorrentAsync(byte[] torrent)
        {
            return _client.AddTorrentAsync(torrent);
        }

        public Task<List<string>> AddMetalinkAsync(byte[] torrent)
        {
            return _client.AddMetalinkAsync(torrent);
        }

        public Task<string> RemoveAsync(string gid, bool? force = false)
        {
            if (force == true)
            {
                return _client.ForceRemoveAsync(gid);
            }
            return _client.RemoveAsync(gid);
        }

        public Task RemoveDownloadResultAsync(string gid)
        {
            return _client.RemoveDownloadResultAsync(gid);
        }

        public Task<VersionResult> GetVersionAsync()
        {
            return _client.GetVersionAsync();
        }

        public Task<IList<UriResult>> GetUrisAsync(string gid)
        {
            return _client.GetUrisAsync(gid);
        }

        public Task<IList<PeerResult>> GetPeersAsync(string gid)
        {
            return _client.GetPeersAsync(gid);
        }

        public Task<IList<ServerResult>> GetServersAsync(string gid)
        {
            return _client.GetServersAsync(gid);
        }

        public Task<int> ChangePositionAsync(string gid, int pos, ChangePositionHow how)
        {
            return _client.ChangePositionAsync(gid, pos, how);
        }

        public Task<IDictionary<string, string>> GetOptionAsync(string gid)
        {
            return _client.GetOptionAsync(gid);
        }

        public Task<IList<string>> ChangeUriAsync(string gid, int fileIndex, IList<string> delUris, IList<string> addUris)
        {
            return _client.ChangeUriAsync(gid, fileIndex, delUris, addUris);
        }

        public Task ChangeOptionAsync(string gid, IDictionary<string, string> options)
        {
            return _client.ChangeOptionAsync(gid, options);
        }

        public Task ChangeGlobalOptionAsync(IDictionary<string, string> options)
        {
            return _client.ChangeGlobalOptionAsync(options);
        }

        public Task PurgeDownloadResultAsync()
        {
            return _client.PurgeDownloadResultAsync();
        }

        public Task<GlobalStatResult> GetGlobalStatAsync()
        {
            return _client.GetGlobalStatAsync();
        }

        public Task<IList<string>> SaveSessionAsync()
        {
            return _client.SaveSessionAsync();
        }
    }
}

using Aria2.Api.Services;
using Aria2NET;
using Microsoft.AspNetCore.Mvc;
using FileResult = Aria2NET.FileResult;

namespace Aria2.Api.Controllers
{
    [ApiController]
    [Route("aria2")]
    public class Aria2Controller : ControllerBase
    {
        private readonly ILogger<Aria2Controller> _logger;
        private readonly IAria2Service _aria2Service;

        public Aria2Controller(ILogger<Aria2Controller> logger, IAria2Service aira2)
        {
            _logger = logger;
            _aria2Service = aira2;
        }

        [HttpGet("session")]
        public async Task<SessionResult> GetSessionInfo()
        {
            return await _aria2Service.GetSessionInfo();
        }

        [HttpPost("add-uri")]
        public async Task<string> AddUriTaskAsync([FromBody] string[] uris)
        {
            return await _aria2Service.AddUriTaskAsync(uris);
        }

        [HttpGet("global-options")]
        public async Task<IDictionary<string, string>> GetGlobalOptionAsync()
        {
            return await _aria2Service.GetGlobalOptionAsync();
        }

        [HttpGet("files/{gid}")]
        public async Task<IList<FileResult>> GetFilesAsync(string gid)
        {
            return await _aria2Service.GetFilesAsync(gid);
        }

        [HttpGet("all")]
        public async Task<IList<DownloadStatusResult>> GetAllAsync()
        {
            return await _aria2Service.GetAllAsync();
        }

        [HttpGet("active")]
        public async Task<IList<DownloadStatusResult>> GetActiveAsync()
        {
            return await _aria2Service.GetActiveAsync();
        }

        [HttpGet("waiting")]
        public async Task<IList<DownloadStatusResult>> GetWaitingAsync(int offset, int num)
        {
            return await _aria2Service.GetWaitingAsync(offset, num);
        }

        [HttpGet("stopped")]
        public async Task<IList<DownloadStatusResult>> GetStoppedAsync(int offset, int num)
        {
            return await _aria2Service.GetStoppedAsync(offset, num);
        }

        [HttpGet("status/{gid}")]
        public async Task<DownloadStatusResult> GetStatusAsync(string gid)
        {
            return await _aria2Service.GetStatusAsync(gid);
        }

        [HttpPost("pause/{gid}")]
        public async Task<ActionResult<string>> PauseAsync(string gid, [FromQuery] bool? force = false)
        {
            return await _aria2Service.PauseAsync(gid, force);
        }


        [HttpPost("unpause/{gid}")]
        public async Task<ActionResult<string>> UnPauseAsync(string gid)
        {
            return await _aria2Service.UnPauseAsync(gid);
        }

        [HttpPost("pause-all")]
        public async Task<ActionResult<bool>> PauseAllAsync([FromQuery] bool? force = false)
        {
            return await _aria2Service.PauseAllAsync(force);
        }

        [HttpPost("unpause-all")]
        public async Task<ActionResult<bool>> UnpauseAllAsync()
        {
            return await _aria2Service.UnpauseAllAsync();
        }

        [HttpPost("add-torrent")]
        public async Task<ActionResult<string>> AddTorrentAsync([FromBody] byte[] torrent)
        {
            return await _aria2Service.AddTorrentAsync(torrent);
        }

        [HttpPost("add-metalink")]
        public async Task<ActionResult<List<string>>> AddMetalinkAsync([FromBody] byte[] metalink)
        {
            return await _aria2Service.AddMetalinkAsync(metalink);
        }

        [HttpDelete("remove/{gid}")]
        public async Task<ActionResult<string>> RemoveAsync(string gid, [FromQuery] bool? force = false)
        {
            return await _aria2Service.RemoveAsync(gid, force);
        }

        [HttpDelete("remove-result/{gid}")]
        public async Task<ActionResult> RemoveDownloadResultAsync(string gid)
        {
            await _aria2Service.RemoveDownloadResultAsync(gid);
            return NoContent();
        }

        [HttpGet("version")]
        public async Task<ActionResult<VersionResult>> GetVersionAsync()
        {
            return await _aria2Service.GetVersionAsync();
        }

        [HttpGet("uris/{gid}")]
        public async Task<IList<UriResult>> GetUrisAsync(string gid)
        {
            return await _aria2Service.GetUrisAsync(gid);
        }

        [HttpGet("peers/{gid}")]
        public async Task<IList<PeerResult>> GetPeersAsync(string gid)
        {
            return await _aria2Service.GetPeersAsync(gid);
        }

        [HttpGet("servers/{gid}")]
        public async Task<IList<ServerResult>> GetServersAsync(string gid)
        {
            return await _aria2Service.GetServersAsync(gid);
        }

        [HttpPost("change-position/{gid}")]
        public async Task<ActionResult<int>> ChangePositionAsync(string gid, int pos, ChangePositionHow how)
        {
            return await _aria2Service.ChangePositionAsync(gid, pos, how);
        }

        [HttpGet("option/{gid}")]
        public async Task<IDictionary<string, string>> GetOptionAsync(string gid)
        {
            return await _aria2Service.GetOptionAsync(gid);
        }

        [HttpPost("change-uri/{gid}")]
        public async Task<IList<string>> ChangeUriAsync(ChangeUriRequest request)
        {
            return await _aria2Service.ChangeUriAsync(request.Gid, request.FileIndex, request.DelUris, request.DelUris);
        }

        [HttpPost("change-option/{gid}")]
        public async Task<ActionResult> ChangeOptionAsync(string gid, [FromBody] IDictionary<string, string> options)
        {
            await _aria2Service.ChangeOptionAsync(gid, options);
            return NoContent();
        }

        [HttpPost("change-global-option")]
        public async Task<ActionResult> ChangeGlobalOptionAsync([FromBody] IDictionary<string, string> options)
        {
            await _aria2Service.ChangeGlobalOptionAsync(options);
            return NoContent();
        }

        [HttpPost("purge")]
        public async Task<ActionResult> PurgeDownloadResultAsync()
        {
            await _aria2Service.PurgeDownloadResultAsync();
            return NoContent();
        }

        [HttpGet("global-stat")]
        public async Task<ActionResult<GlobalStatResult>> GetGlobalStatAsync()
        {
            return await _aria2Service.GetGlobalStatAsync();
        }

        [HttpGet("save-session")]
        public async Task<IList<string>> SaveSessionAsync()
        {
            return await _aria2Service.SaveSessionAsync();
        }
    }
}
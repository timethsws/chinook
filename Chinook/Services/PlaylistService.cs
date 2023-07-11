using Chinook.ClientModels;
using Chinook.Models;
using Microsoft.EntityFrameworkCore;
using Playlist = Chinook.Models.Playlist;

namespace Chinook.Services;

/// <summary>
/// Playlist Service
/// </summary>
public class PlaylistService
{
    private readonly ChinookContext _dbContext;
    public const string FAVORITES_PLAYLIST_NAME = "My favorite tracks";

    public PlaylistService(ChinookContext dbContext)
    {
        _dbContext = dbContext;
    }

    
    /// <summary>
    /// Get playlists for a user
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <returns></returns>
    public async Task<List<Playlist>> GetPlaylistsAsync(string userId)
    {
        return await _dbContext.Playlists
            .AsNoTracking()
            .Where(p => p.UserPlaylists.Any(p => p.UserId == userId))
            .ToListAsync();
    }

    /// <summary>
    /// Add a track to the favourites
    /// </summary>
    /// <param name="trackId">Track Id</param>
    /// <param name="userId">User Id</param>
    /// <returns></returns>
    public async Task<bool> FavouriteTrack(long trackId, string userId)
    {
        var favouritesPlaylist = await GetFavouritesPlaylist(userId);
        var track = _dbContext.Tracks.SingleOrDefault(t => t.TrackId == trackId);
        if (track == null)
        {
            // Error Handling
            return false;
        }
        favouritesPlaylist.Tracks.Add(track);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    
    /// <summary>
    /// Remove a track from favourites
    /// </summary>
    /// <param name="trackId">Track Id</param>
    /// <param name="userId">User Id</param>
    /// <returns></returns>
    public async Task<bool> UnFavouriteTrack(long trackId, string userId)
    {
        var favouritesPlaylist = await GetFavouritesPlaylist(userId);
        
        var track = favouritesPlaylist.Tracks.SingleOrDefault(t => t.TrackId == trackId);
        if (track == null)
        {
            // Error Handling
            return false;
        }

        favouritesPlaylist.Tracks.Remove(track);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    
    /// <summary>
    /// Get the favourites playlists
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <returns></returns>
    private async Task<Playlist> GetFavouritesPlaylist(string userId)
    {
        var favouritesPlaylist =  await _dbContext.Playlists
            .Include(p => p.UserPlaylists)
            .Include(p => p.Tracks)
            .Where(p => p.Name == FAVORITES_PLAYLIST_NAME && p.UserPlaylists.Any(up => up.UserId == userId))
            .SingleOrDefaultAsync();
        
        return favouritesPlaylist ?? await CreateFavouritesPlaylist(userId);
    }

    /// <summary>
    /// Creates the favourites playlists
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <returns></returns>
    private async Task<Playlist> CreateFavouritesPlaylist(string userId)
    {
        var playlist = await _dbContext.Playlists.AddAsync(new Playlist()
        {
            Name = FAVORITES_PLAYLIST_NAME,
            UserPlaylists = new List<UserPlaylist>()
            {
                new()
                {
                    UserId = userId
                }
            }
        });

        return playlist.Entity;
    }

    /// <summary>
    /// Get all playlists
    /// </summary>
    /// <param name="currentUserId">Current user Id</param>
    /// <param name="playlistId">Playlist Id</param>
    /// <returns></returns>
    public async Task<ClientModels.Playlist> GetAsync(string currentUserId, long playlistId)
    {
        return await _dbContext.Playlists
            .Include(a => a.Tracks).ThenInclude(a => a.Album).ThenInclude(a => a.Artist)
            .Where(p => p.PlaylistId == playlistId)
            .Select(p => new ClientModels.Playlist()
            {
                Name = p.Name,
                Tracks = p.Tracks.Select(t => new ClientModels.PlaylistTrack()
                {
                    AlbumTitle = t.Album.Title,
                    ArtistName = t.Album.Artist.Name,
                    TrackId = t.TrackId,
                    TrackName = t.Name,
                    IsFavorite = t.Playlists.Any(p => p.UserPlaylists.Any(up => up.UserId == currentUserId && up.Playlist.Name == "Favorites"))
                }).ToList()
            })
            .FirstOrDefaultAsync();
    }

    /// <summary>
    /// Add a track to a playlist
    /// </summary>
    /// <param name="addToPlaylistRequestModel"><Add to playlist request model/param>
    /// <param name="selectedTrackTrackId"><track/param>
    /// <param name="userId">user Id</param>
    public async Task AddTrackToPlaylistAsync(AddToPlaylistRequest addToPlaylistRequestModel, long selectedTrackTrackId, string userId)
    {
        if (string.IsNullOrWhiteSpace(addToPlaylistRequestModel.PlaylistName))
        {
            var playlist = await _dbContext.Playlists
                .Include(p => p.Tracks)
                .Where(p => p.PlaylistId == addToPlaylistRequestModel.PlaylistId)
                .SingleOrDefaultAsync();

            var track = await _dbContext.Tracks
                .Where(t => t.TrackId == selectedTrackTrackId)
                .SingleOrDefaultAsync();

            playlist.Tracks.Add(track);
        }
        else
        {
            var playlist = new Playlist()
            {
                Name = addToPlaylistRequestModel.PlaylistName,
                UserPlaylists = new List<UserPlaylist>()
                {
                    new()
                    {
                        UserId = userId
                    }
                },
            };

            var track = await _dbContext.Tracks
                .Where(t => t.TrackId == selectedTrackTrackId)
                .SingleOrDefaultAsync();

            playlist.Tracks.Add(track);

            await _dbContext.Playlists.AddAsync(playlist);
        }
       
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Remove track from playlist
    /// </summary>
    /// <param name="trackId"></param>
    /// <param name="playlistId"></param>
    public async Task RemoveTrack(long trackId, long playlistId)
    {
        var playlist = await _dbContext.Playlists.Include(p =>p.Tracks).FirstOrDefaultAsync(p => p.PlaylistId == playlistId);
        var track = await _dbContext.Tracks.FirstOrDefaultAsync(t => t.TrackId == trackId);
        playlist.Tracks.Remove(track);
        await _dbContext.SaveChangesAsync();
    }
}
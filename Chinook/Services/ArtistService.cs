using Chinook.ClientModels;
using Chinook.DTOs;
using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Services;

public class ArtistService
{
    private readonly ChinookContext _dbContext;

    public ArtistService(ChinookContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<ArtistDto>> GetAllAsync(string searchString = null)
    {
        var query = _dbContext.Artists
            .AsNoTracking()
            .Include(a => a.Albums)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchString))
        {
            query = query.Where(a => a.Name.Contains(searchString));
        }
        
        return await query
            .Select(a => new ArtistDto()
            {
                ArtistId = a.ArtistId,
                Name = a.Name,
                AlbumsCount = a.Albums.Count
            })
            .ToListAsync();
    }

    public async Task<Artist?> GetAsync(long artistId)
    {
        return await _dbContext.Artists
            .AsNoTracking()
            .Include(a => a.Albums)
            .Where(a => a.ArtistId == artistId)
            .SingleOrDefaultAsync();
    }
    
    public async Task<List<PlaylistTrack>> GetArtistTracksAsync(long artistId,string currentUserId)
    {
        return await _dbContext.Tracks.Where(a => a.Album.ArtistId == artistId)
            .Include(a => a.Album)
            .Select(t => new PlaylistTrack()
            {
                AlbumTitle = (t.Album == null ? "-" : t.Album.Title),
                TrackId = t.TrackId,
                TrackName = t.Name,
                IsFavorite = t.Playlists.Any(p => p.UserPlaylists.Any(up => up.UserId == currentUserId && up.Playlist.Name == "Favorites"))
            })
            .ToListAsync();
    }
}
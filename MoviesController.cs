using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalVideoWebAPI.Data;
using RentalVideoWebAPI.Models;


namespace RentalVideoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private readonly MoviesAPIDbContext dbContext;

        public MoviesController(MoviesAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetMovies()
        {
            return Ok(await dbContext.Movies.ToListAsync());
        }

        [HttpGet("{MovieId}")]
        public async Task<ActionResult> GetMovieById(Guid MovieId)
        {
            var movie = await dbContext.Movies.FindAsync(MovieId);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> AddContx(AddMoviesRequest addMovieRequest)
        {
            var movies = new Movies
            {
                MovieId =addMovieRequest.MovieId,
                MovieTitle = addMovieRequest.MovieTitle,
                Director = addMovieRequest.Director,
                Year = addMovieRequest.Year,
                Genre = addMovieRequest.Genre,
                Language = addMovieRequest.Language
            };
            await dbContext.Movies.AddAsync(movies);
            await dbContext.SaveChangesAsync();
            return Ok(movies);
        }

        [HttpPut("{MovieId}")]
        public async Task<ActionResult> UpdateMovie(Guid MovieId, UpdateMoviesRequest updateMovieRequest)
        {
            var movie = await dbContext.Movies.FindAsync(MovieId);
            if (movie != null)
            {
                movie.MovieId = updateMovieRequest.MovieId;
                movie.MovieTitle = updateMovieRequest.MovieTitle;
                movie.Director = updateMovieRequest.Director;
                movie.Year = updateMovieRequest.Year;
                movie.Genre = updateMovieRequest.Genre;
                movie.Language = updateMovieRequest.Language;
                await dbContext.SaveChangesAsync();
                return Ok(movie);
            }
            return NotFound();
        }

        [HttpDelete("{MovieId}")]
        public async Task<ActionResult> DeleteMovie(Guid MovieId)
        {
            var movie = await dbContext.Movies.FindAsync(MovieId);
            if (movie != null)
            {
                dbContext.Movies.Remove(movie);
                await dbContext.SaveChangesAsync();
                return Ok(movie);
            }
            return NotFound();
        }
    }
}

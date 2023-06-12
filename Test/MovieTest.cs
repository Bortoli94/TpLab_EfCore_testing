using Xunit;
using TPLabIV.Models;

namespace TPLabIV.Test
{
    public class MovieTest
    {
        [Fact]
        public void Movie_GetMovieName_ReturnsCorrectName()
        {
            var movieName = new Movie { MovieName = "Interestelar" };
            
            Assert.IsType<string>(movieName.MovieName);
            Assert.Equal("Interestelar", movieName.MovieName);
        }
        [Fact]
        public void Movie_MovieGenre_ReturnsCorrectGenre()
        {
            var movieGenre = new Movie { MovieGenre = "Science Fiction" };
            Assert.IsType<string>(movieGenre.MovieGenre);
            Assert.Equal("Science Fiction", movieGenre.MovieGenre);
        }
        [Fact]
        public void Movie_GetMovieDuration_ReturnsCorrectMovieDuration()
        {
            var movieDuration = new Movie { MovieDuration = 169 };
            Assert.IsType<int>(movieDuration.MovieDuration);
            Assert.Equal(169, movieDuration.MovieDuration);
        }
        [Fact]
        public void Movie_GetMovieBudget_ReturnsCorrectMovieBudget()
        {
            var movieBudget = new Movie { MovieBudget = 165000000 };
            Assert.IsType<decimal>(movieBudget.MovieBudget);
            Assert.Equal(165000000, movieBudget.MovieBudget);
        }

        [Fact]
        public void TestMovieWithInvalidProperties()
        {
        
            var movie = new Movie
            {
                MovieName = null,
                MovieGenre = null,
                MovieDuration = 0,
                MovieBudget = 0
            };
           
            Assert.Null(movie.MovieName);
            Assert.Null(movie.MovieGenre);
            Assert.Equal(0, movie.MovieDuration);
            Assert.Equal(0, movie.MovieBudget);
        }
    }
}

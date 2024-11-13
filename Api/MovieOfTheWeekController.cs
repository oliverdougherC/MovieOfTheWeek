using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MovieOfTheWeek.Api
{
    [ApiController]
    [Route("MovieOfTheWeek")]
    public class MovieOfTheWeekController : ControllerBase
    {
        [HttpGet("Featured")]
        [AllowAnonymous]
        public async Task<ActionResult> GetFeaturedMovie()
        {
            var movie = await Plugin.HomePageModification.GetFeaturedMovie();
            return Ok(movie);
        }

        [HttpPost("SetMovie")]
        [Authorize(Policy = "RequiresElevation")]
        public ActionResult SetMovie([FromBody] string movieId)
        {
            var config = Plugin.Instance.Configuration;
            config.SelectedMovieId = movieId;
            Plugin.Instance.SaveConfiguration();
            return Ok();
        }
    }
} 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGameTask.Models;
using WebGameTask.Persistence;

namespace WebGameTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameTaskController : ControllerBase
    {
        private readonly DataContext _context;


        public GameTaskController(DataContext context)
        {
            _context = context;
        }
        //Endpoint to get all GameTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameTask>>> GetGameTasks()
        {
            return await _context.GameTasks.ToListAsync();
        }

        //Endpoint to create solution(only correct solutions)
        [HttpPost("solutions")]
        public async Task<ActionResult<Solution>> PostSolution(Solution solution)
        {
            _context.Solutions.Add(solution);
            await _context.SaveChangesAsync();
            return solution;
        }

        //Endpoint to get top3 players
        [HttpGet("solutions")]
        public async Task<ActionResult<List<TopPlayer>>> GetTopPlayers()
        {
            var solutions = await _context.Solutions.ToListAsync();
            List<TopPlayer> topPlayers = new();
            if (solutions.Count > 0)
            {
                foreach (var uniquePlayer in solutions.Select(x => x.PlayerName).Distinct())
                {
                    var solutionsByName = solutions.FindAll(x => x.PlayerName == uniquePlayer);
                    topPlayers.Add(
                    new TopPlayer
                    {
                        PlayerName = uniquePlayer,
                        SolutionAmount = solutionsByName.Count,
                        SolutionNames = TaskNames(solutionsByName)
                    });
                }
                return topPlayers.OrderByDescending(x => x.SolutionAmount).ToList().Take(3).ToList();
            }
            return null;
        }

        //method for creating completed tasks string
        public string TaskNames(List<Solution> solutions)
        {
            string taskNames = "";
            foreach (var solution in solutions)
            {
                if (taskNames != "")
                    taskNames += ", ";
                taskNames += solution.TaskName;
            }
            return taskNames;
        }
    }
}

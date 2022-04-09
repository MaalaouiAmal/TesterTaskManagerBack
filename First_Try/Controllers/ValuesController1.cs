using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace First_Try.Controllers
{
    [Route("api/Jira/")]
    [ApiController]
    public class ValuesController1 : ControllerBase
    {
        // GET: api/<ValuesController1>
        [HttpGet]
        [Route("[action]")]
        public dynamic backlog()
        {
   
            Jira req = new Jira();
            string res = req.getBacklog();
            
            return res;
                }





        // GET api/<ValuesController1>/5
        
        [HttpGet]
        [Route("[action]/{boardId}")]
        public string GetActiveSprint(int boardId)
        {
         
            Jira req = new Jira();
            return req.getSprints(boardId);
            
        }


        // GET api/<ValuesController1>/5

        [HttpGet]
        [Route("[action]/{boardId}")]
        public string GetVersionReleasesResponse(int boardId)
        {
    
            Jira req = new Jira();
            return req.getVersionReleases(boardId);

        }




        // GET api/<ValuesController1>/5

        [HttpGet]
        [Route("[action]/{boardId}/{sprintId}")]
        public string GetIssuesForSprintResponse(int boardId , int sprintId )
        {
  
            Jira req = new Jira();
            return req.getIssue(boardId,sprintId) ;

        }

    }
}

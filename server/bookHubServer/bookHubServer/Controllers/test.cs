using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookHubServer.Tool;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bookHubServer.Controllers
{
    [Route("api/[controller]")]
    public class test : Controller
    {




        // POST api/values
        [HttpPost]
        public IActionResult Post(string temp)
        {
            return Ok(pwdEncryptTool.Encrypt(temp));
        }

    }
}


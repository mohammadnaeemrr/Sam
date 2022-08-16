using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sam.Models;
using Sam.Services;

namespace Sam.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpController : Controller
    {
        public readonly EmployeeServices empservices;

    public EmpController(EmployeeServices empservices){
        this.empservices = empservices;

    }
    [HttpGet]
    public  List<EmployeeData> GetStudent(){
        return  empservices.Get();
        
    }

    [HttpPost]

    public async Task<IActionResult> PostStudent(EmployeeData empdata){
        await empservices.CreateAsync(empdata);
        return CreatedAtAction(nameof(GetStudent),new{id=empdata.Id},empdata);
    }
       
    }
}
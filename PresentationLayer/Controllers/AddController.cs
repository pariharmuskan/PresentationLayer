using BusinesslogicLayer;
using DataAccessLayers.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace PresentationLayer.Controllers
{
    public class AddController : Controller
    {
        private readonly IEmployeeService _context;

        public AddController(IEmployeeService context)
        {
            _context = context;
        }


        public async Task<IActionResult> HomeIndex()
        {
            var emp = await _context.GetEmployeesAsync();
            return View();
        }
        public async Task<IActionResult> HomeIndex11()
        {
            var emp = await _context.GetEmployeesAsync();
            return Json(emp);
        }

        public async Task<IActionResult> Show()
        {
            var emp = await _context.GetEmployeesAsync();
            return Json(emp);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _context.AddEmployee(employee);
                return RedirectToAction("HomeIndex");
            }

            return View(employee);
        }
        public IActionResult Adddata()
        {
            return View();
        }

        public async Task<IActionResult> Destroy(int id)
        {
            await _context.DeleteEmployee(id);
          

            return RedirectToAction("HomeIndex" );
        }
        public async Task<IActionResult> Edit(int id)
        {
            var c=await _context.GetEmployeeById(id);


            return View(c);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            await _context.UpdateEmployee(employee);


            return Json(employee);
        }
        //public IActionResult Edit21(Employee model)
        //{

        //    _context.Employees.Update(model);
        //    _context.SaveChanges();
        //    return RedirectToAction("Grid1");
        //}

    }
}

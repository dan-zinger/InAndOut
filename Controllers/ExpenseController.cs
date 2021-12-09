using InAndOut1.Data;
using InAndOut1.Models;
using InAndOut1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut1.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //  _db.Expenses;
            
            // foreach (var obj in objList.ToList())
            // {
            //     obj.ExpenseType = _db.ExpenseTypes.FirstOrDefault(u => u.Id == obj.ExpenseTypeId).ToList();
            // }

  
        var expenseViewModel = from e in _db.Expenses
                               join et in _db.ExpenseTypes on e.ExpenseTypeId equals et.Id
                               select new ExpenseViewModel { Id = e.Id, ExpenseName = e.ExpenseName, Amount = e.Amount, ExpenseTypeId = e.ExpenseTypeId, ExpenseType = et.Name};
            return View(expenseViewModel);
            
            // var objList = (from e in _db.Expenses join t in _db.ExpenseTypes on e.ExpenseTypeId equals t.Id select new  
            // {  
            //     e.Id,
            //     e.ExpenseName,
            //     e.Amount,
            //     e.ExpenseTypeId,
            //     t.Name
            // }).ToList();

            // var result = new List<ExpenseViewModel>();
            // foreach (var obj in objList)
            // {
            //     var expenseVM = new ExpenseViewModel();
            //     expenseVM.Id = obj.Id;
            //     expenseVM.ExpenseName = obj.ExpenseName;
            //     expenseVM.Amount = obj.Amount;
            //     expenseVM.ExpenseTypeId = obj.ExpenseTypeId;
            //     expenseVM.ExpenseType = obj.Name;
            // }

            // return View(result);

        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem 
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }); 

            ViewBag.TypeDropDown = TypeDropDown;
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense obj)
        {
            if(ModelState.IsValid)
            {
                _db.Expenses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            IEnumerable<SelectListItem> TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem 
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }); 

            ViewBag.TypeDropDown = TypeDropDown;

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");            
            }
            return View(obj);
            
        }

    }
}

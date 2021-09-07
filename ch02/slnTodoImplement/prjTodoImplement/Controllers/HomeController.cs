using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjTodoImplement.Models;
namespace prjTodoImplement.Controllers
{
    public class HomeController : Controller
    {
        //資料庫連接
        dbTodoEntities db = new dbTodoEntities();
        // GET: Home
        public ActionResult Index()
        {
            var todos = db.tTodo
                //依照fDate排序再把結果給todos變數
                .OrderByDescending(m => m.fDate).ToList();
            return View(todos);
        }

        //Create get
        public ActionResult Create()
        {
            return View();
        }
        //Create Post進來
        [HttpPost]
        public ActionResult Create(string fTitle, string fLevel, DateTime fDate)
        {
            tTodo todo = new tTodo();
            todo.fTitle = fTitle;
            todo.fLevel = fLevel;
            todo.fDate = fDate;
            //把todo裡的資料加到資料庫
            db.tTodo.Add(todo);
            db.SaveChanges();
            //結果傳給index
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            //找到資料庫裡tTodo資料表中where條件符合的第一筆
            var todo = db.tTodo.Where(x => x.fId == id).FirstOrDefault();
            //資料表刪除這筆資料
            db.tTodo.Remove(todo);
            //資料庫保存
            db.SaveChanges();
            //刪除完回首頁
            return RedirectToAction("Index");
        }
    }
}
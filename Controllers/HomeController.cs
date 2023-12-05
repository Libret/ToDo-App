using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using Todo.Models.ViewModels;
using ToDo_App.Models;

namespace ToDo_App.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var ToDoAllViewModels = GetAllToDoItems();
        return View(ToDoAllViewModels);
    }
    public RedirectResult InsertData(ToDoItem toDoItem)
    {
        var conOpen = SqliteCon.SqliteOpenConnnection();
        {
            using (var tableCmd = conOpen.CreateCommand())
            {
                tableCmd.CommandText = $"INSERT INTO todoItem (name) VALUES ('{toDoItem.Name}')";
                try
                {
                    tableCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        return Redirect("https://localhost:7149/");
    }
    public static ToDoViewModel GetAllToDoItems()
    {
        List<ToDoItem> toDoList = new();

        var con = SqliteCon.SqliteOpenConnnection();

        var tableCmd = con.CreateCommand();
        {
            tableCmd.CommandText = "SELECT * FROM todoItem";

            using (var reader = tableCmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        toDoList.Add(
                        new ToDoItem
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
                
                return new ToDoViewModel 
                {
                    ToDoList = toDoList
                };
            };
        }
    }
}


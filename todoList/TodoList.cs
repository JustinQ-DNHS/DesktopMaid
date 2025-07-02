using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TodoList
{
    public class Todo
    {
        private string filePath = "TodoList.json";
        private string json;
        private List<TodoItem> todoList;
        // Initiates class, and ensures TodoList.json exists. Then converts JSON to C# TodoItem objects
        public Todo()
        {
            if (!File.Exists(filePath)) { File.WriteAllText(filePath, "[]"); }
            json = File.ReadAllText(filePath);
            todoList = JsonSerializer.Deserialize<List<TodoItem>>(json) ?? new List<TodoItem>();
        }
        public void printList()
        {
            Console.WriteLine("");
            foreach (var i in todoList)
            {
                Console.WriteLine($"Title: {i.Title}\nDescription: {i.Description}\nDueDate: {i.DueDate}");
            }
            Console.WriteLine("");
        }
    }
    public class TodoItem
    {
        public TodoItem(string title, string description, string dueDate)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
    }
}
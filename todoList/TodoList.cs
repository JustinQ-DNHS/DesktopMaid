using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TodoList
{
    public class Todo
    {
        // FILEPATH, IF CHANGING FILE LOCATION CHANGE THIS.
        private string filePath = "todoList/TodoList.json";
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
            Console.WriteLine($"Todo list has {todoList.Count} items.");
            foreach (var i in todoList)
            {
                Console.WriteLine($"Title: {i.Title}\nDescription: {i.Description}\nDueDate: {i.DueDate}");
            }
        }
        public void addItem(string title, string description, string dueDate)
        {
            todoList.Add(new TodoItem(title, description, dueDate));
        }
        public void save()
        {
            
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
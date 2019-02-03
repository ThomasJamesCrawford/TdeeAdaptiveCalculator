using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TDEE
{
    public class TodoItemDatabase
    {
        SQLiteAsyncConnection database;

        public TodoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TodoItem>().Wait();
        }

        public Task<List<TodoItem>> GetItemsAsync()
        {
            return database.Table<TodoItem>().ToListAsync();
        }

        public Task<List<TodoItem>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public async Task<int> SaveItemAsync(TodoItem item)
        {
            TodoItem dbItem = database.FindAsync<TodoItem>(item.Date).Result;
            
            if (dbItem != null && item != null)
            {
                if (item.Calories == -1)
                {
                    item.Calories = dbItem.Calories;
                }

                if (item.Weight == -1)
                {
                    item.Weight = dbItem.Weight;
                }
                await database.DeleteAsync<TodoItem>(dbItem.Date);
            }
            Console.WriteLine("INSERT");
            return await database.InsertAsync(item);
        }

        public async Task<int> SaveCompleteItemAsync(TodoItem item)
        {
            TodoItem dbItem = database.FindAsync<TodoItem>(item.Date).Result;

            if (dbItem != null && item != null)
            {
                await database.DeleteAsync<TodoItem>(dbItem.Date);
            }

            return await database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(TodoItem item)
        {
            Console.WriteLine("DELETE");

            return await database.DeleteAsync<TodoItem>(item.Date);
        }

        public Task<int> DeleteAll()
        {
            return database.DeleteAllAsync<TodoItem>();
        }
    }
}

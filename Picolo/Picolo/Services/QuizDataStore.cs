using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Picolo.Models;
using SQLite;

/// <summary>
/// Written by Shannon Tetley, n6255078
/// </summary>

namespace Picolo.Services
{
    public class QuizDataStore : IDataStore<Quiz>
    {
        public Task<bool> AddItemAsync(Quiz item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Quiz> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Quiz>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Quiz item)
        {
            throw new NotImplementedException();
        }
    }
}

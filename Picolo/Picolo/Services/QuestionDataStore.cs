using System;
using System.Collections.Generic;
using System.Text;
using Picolo.Models;
using System.Threading.Tasks;
using System.Linq;
using SQLite;

/// <summary>
/// Written by Shannon Tetley, n6255078
/// </summary>

namespace Picolo.Services
{
    public class QuestionDataStore : IDataStore<Question>
    {
        public Task<bool> AddItemAsync(Question item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Question> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Question>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Question item)
        {
            throw new NotImplementedException();
        }
    } // End class
} // End namespace

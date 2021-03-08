// Written by Aaron Hayton N9946977
using Picolo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SQLite;
using System.Xml.Schema;
using Picolo.Views;

namespace Picolo.Services
{
    public class GroupDataStore : IDataStore<Groups>
    {
        readonly List<Groups> groups;

        public GroupDataStore()
        {
            groups = new List<Groups>()
            {
                new Groups
                {
                    GroupName = "The Nightwatchers",
                    MemberId1 = "User2",
                    MemberId2 = "User3",
                    MemberId3 = "User4",
                    MemberId4 = null,
                    GroupXP = 2000
                },
                new Groups
                {
                    GroupName = "Crescent Regiment",
                    MemberId1 = "User5",
                    MemberId2 = "User6",
                    MemberId3 = "User7",
                    MemberId4 = null,
                    GroupXP = 600
                }
            };
        }

        public async Task<bool> AddItemAsync(Groups item)
        {
            groups.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = groups.Where((Groups arg) => arg.Id == id).FirstOrDefault();
            groups.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Groups> GetItemAsync(string id)
        {
            return await Task.FromResult(groups.FirstOrDefault(s => s.GroupName == id));
        }

        public async Task<IEnumerable<Groups>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(groups);
        }

        public async Task<bool> UpdateItemAsync(Groups item)
        {
            var oldItem = groups.Where((Groups arg) => arg.GroupName == item.GroupName).FirstOrDefault();
            groups.Remove(oldItem);
            groups.Add(item);

            return await Task.FromResult(true);
        }
    }
}

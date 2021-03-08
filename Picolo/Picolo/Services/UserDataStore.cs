// Written by Minseong (Jason) Kim N10218807

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Picolo.Models;
using System.Linq;

namespace Picolo.Services
{
    public class UserDataStore : IDataStore<User>
    {
        readonly List<User> users;

        public UserDataStore()
        {
            users = new List<User>()
            {
                new User {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User1",
                    Username = "wHoaMI",
                    Password = null,
                    PersonalExperience = 8850,
                    PartyExperience = 0,
                    HatColour = null, // This needs to be updated when hat quiz is completed
                    
                    //statistics
                    QuestionsAnswered = 75,
                    QuestsCompleted = 3,
                    CommentsPosted = 3,
                    AverageQuizAccuracy = 99,
                    AverageTimeTakenEachActivity = 23,

                    //trophygained
                    Trophy5Gained = true,
                    Trophy6Gained = false,
                    Trophy7Gained = false,
                    Trophy8Gained = false,
                    Trophy9Gained = false,
                },
                new User {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User2",
                    Username = "IaMyUo",
                    Password = null,
                    PersonalExperience = 8850,
                    HatColour = "Red",
                },
                new User {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User3",
                    Username = "WhoAreYou",
                    Password = null,
                    PersonalExperience = 8850,
                    HatColour = "Blue",
                },
                new User {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User4",
                    Username = "YouAreMe",
                    Password = null,
                    PersonalExperience = 8850,
                    HatColour = "White",
                },
                new User {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User5",
                    Username = "IaMyUo3",
                    Password = null,
                    PersonalExperience = 8850,
                    HatColour = "Black",
                },
                new User {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User6",
                    Username = "IaMyUo4",
                    Password = null,
                    PersonalExperience = 8850,
                    HatColour = "Yellow",
                },
                new User {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User7",
                    Username = "IaMyUo5",
                    Password = null,
                    PersonalExperience = 8850,
                    HatColour = "Green",
                }
            };
        }

        public async Task<bool> AddItemAsync(User item)
        {
            users.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = users.Where((User arg) => arg.Id == id).FirstOrDefault();
            users.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<User> GetItemAsync(string id)
        {
            return await Task.FromResult(users.FirstOrDefault(s => s.Name == id));
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(users);
        }

        public async Task<bool> UpdateItemAsync(User item)
        {
            var oldItem = users.Where((User arg) => arg.Name == item.Name).FirstOrDefault();
            users.Remove(oldItem);
            users.Add(item);

            return await Task.FromResult(true);
        }
    }
}

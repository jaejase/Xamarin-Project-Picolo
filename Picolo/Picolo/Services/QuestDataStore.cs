// Written by Mia Basta N10246771
using Picolo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SQLite;

namespace Picolo.Services
{
    public class QuestDataStore : IDataStore<Quest>
    {
        readonly List<Quest> quests;

        public QuestDataStore()
        {

            quests = new List<Quest>()
            {
                // Quests
                new Quest {
                    Id = "group1",
                    Type = "group",
                    Name = "Complete the Six Hats Quiz",
                    Topic = "Group",
                    Experience = 500,
                    QuestDate = DateTime.Now,
                    Status = ""
                },
                new Quest
                {
                    Id = "quiz1",
                    Type = "quiz1",
                    Name = "Quiz 1 - Australian History",
                    Topic = "History",
                    Experience = 200,
                    QuestDate = DateTime.Now,
                    Status = ""
                },
                //new Quest {
                //    Id = Guid.NewGuid().ToString(),
                //    Type = "quiz",
                //    Name = "Quiz 1 - Algebra",
                //    Topic = "Mathematics",
                //    Experience = 200,
                //    QuestDate = new DateTime(2020, 11, 26),
                //    Status = ""
                //},
                new Quest {
                    Id = Guid.NewGuid().ToString(),
                    Type = "quiz",
                    Name = "Quiz 2 - Calculus",
                    Topic = "Mathematics",
                    Experience = 200,
                    QuestDate = new DateTime(2020, 11, 29),
                    Status = ""
                },
               
                // Dailies
                new Quest {
                    Id = Guid.NewGuid().ToString(),
                    Type = "daily",
                    Name = "Review Topic 1",
                    Topic = "Mathematics",
                    Experience = 50
                },
                new Quest {
                    Id = Guid.NewGuid().ToString(),
                    Type = "daily",
                    Name = "Review Topic 2",
                    Topic = "Mathematics",
                    Experience = 50
                },
                new Quest {
                    Id = Guid.NewGuid().ToString(),
                    Type = "daily",
                    Name = "Ask a Question in Class",
                    Topic = "General",
                    Experience = 50
                },

                // Completed
                new Quest {
                    Id = "1",
                    Type = "quiz",
                    Name = "Quiz 7 - Trigonometry",
                    Topic = "Mathematics",
                    Experience = 200,
                    QuestDate = new DateTime(2020, 10, 15),
                    Status = "complete",
                    QuestResult = 23,
                    NumQuestions = 25

                },
                new Quest {
                    Id = "2",
                    Type = "quiz",
                    Name = "Quiz 6 - Combinatorics",
                    Topic = "Mathematics",
                    Experience = 200,
                    QuestDate = new DateTime(2020, 10, 09),
                    Status = "complete",
                    QuestResult = 12,
                    NumQuestions = 25
                },
                new Quest {
                    Id = Guid.NewGuid().ToString(),
                    Type = "quiz",
                    Name = "Quiz 5 - Boolean Algebra",
                    Topic = "Mathematics",
                    Experience = 200,
                    QuestDate = new DateTime(2020, 10, 12),
                    Status = "complete",
                    QuestResult = 25,
                    NumQuestions = 25
                },
            };
        }

        public async Task<bool> AddItemAsync(Quest item)
        {
            quests.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = quests.Where((Quest arg) => arg.Id == id).FirstOrDefault();
            quests.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Quest> GetItemAsync(string id)
        {
            return await Task.FromResult(quests.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Quest>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(quests);
        }

        public async Task<bool> UpdateItemAsync(Quest item)
        {
            var oldItem = quests.Where((Quest arg) => arg.Id == item.Id).FirstOrDefault();
            quests.Remove(oldItem);
            quests.Add(item);

            return await Task.FromResult(true);
        }
    }
}

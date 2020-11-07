using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Data.Impl
{
    public class UserService : IUserService
    {
        private IList<User> users;
        private string userFile = "users.json";
        public UserService(){
            if(!File.Exists(userFile)){
                Seed();
                WriteToUserFileTemp();
            }else{
                string content = File.ReadAllText(userFile);
                users = JsonSerializer.Deserialize<IList<User>>(content);
            }
        }

        private void WriteToUserFileTemp()
        {
            string productAsJson = JsonSerializer.Serialize(users);
            File.WriteAllText(userFile, productAsJson);
        }

        private void Seed()
        {
            User[] us = {
                new User{
                    username = "Jannik",
                    password = "1234"
                },
                new User{
                    username = "Maria",
                    password = "4321"
                },
                new User{
                    username = "Dumi",
                    password = "1234"
                },
                new User{
                    username = "Wojtek",
                    password = "1234",
                },
                new User{
                    username = "Pawel",
                    password = "1234",
                },
            };
            users = us.ToList();
        }

        public async Task<IList<User>> getUsersAsync()
        {
            IList<User> temp = new List<User>(users);
            return temp; 
        }
    }
}
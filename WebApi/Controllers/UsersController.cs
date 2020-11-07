using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Impl;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsersController : ControllerBase{
        private IUserService userService;

        public UsersController(IUserService userService){
            this.userService = userService;
        }


        [HttpGet]
        public async Task<IList<User>> getUsers(){
            try{
                IList<User> users = await userService.getUsersAsync();
                return users;
            }catch(Exception e){
                Console.WriteLine(e);
                return null;
            }
        }
    }   
}
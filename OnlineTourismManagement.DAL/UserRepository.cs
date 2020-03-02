﻿using OnlineTourismManagement.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTourismManagement.DAL
{
    public class UserRepository
    {
        //static SqlConnection connection;
        static OnlineTourismDBContext context = new OnlineTourismDBContext();
        public static IEnumerable<UserDetails> GetUsers()
        {
            return context.UserDB.ToList();
        }
        public static void AddUser(UserDetails user)
        {
            context.UserDB.Add(user);
            context.SaveChanges();
        }
        public static bool ValidateSignIn(string username,string password)
        {
            bool isValue=false;
            IEnumerable<UserDetails> users = context.UserDB.ToList();
            foreach (var value in users)
            {
                if (username == value.MailId && password == value.Password)
                {
                    isValue = true;
                    break;
                }
            }
            return isValue;
        }
    }
}

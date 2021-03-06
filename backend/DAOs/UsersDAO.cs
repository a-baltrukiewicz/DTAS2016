﻿using backend.DataObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.ObjectsFactories;
namespace backend.DAOs
{

    class UsersDAO : AbstractDAO<User>
    {
       

       

        public UsersDAO() { }

        public List<User> GetAllUsers()
        {
            return ReceiveFromDatabase("select * from users where deleted = 0");
        }

        public string SaveUsers(string json)
        {
            if (CheckForSQLInjection(json))
                throw new Exception();
            List<User> users = Tokenize(json);
            //dodanie hashowania haseł oraz obsługi "cichego usunięcia"
            string comm = "insert into Users values ";
            foreach (User user in users)
            {
                comm += "('" + user.firstName + "', '" + user.lastName +
                    "', '" + user.email + "', '" + DataObjects.LoginKeeper.sha256(user.password) + "', '" +
                    user.sex + "', 0),";
            }
            comm = comm.Remove(comm.Length - 1);
            return SendToDatabase(comm);
        }

        public string DeleteUser(int id)
        {
            String comm = "delete users where id = " + id.ToString();
            return SendToDatabase(comm);
        }
        public object LoginUser(string json)
        {
            JToken token = JToken.Parse(json);
            string pass1 = SendToDatabase("select password from users where email = '" + token["email"].ToString() + "' and deleted = 0");
            JToken pass2;
            try
            {
                pass2 = JToken.Parse(pass1);
            }
            catch
            {
                return ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeUnauthorized();
            }
            string pass3 = pass2[0]["password"].ToString();
            string tokenPass = token["password"].ToString();
            string encryptedPassword = LoginKeeper.sha256(tokenPass);
            if (Equals(encryptedPassword, pass3))
            {
                JToken userID1 = JToken.Parse(SendToDatabase("select id from users where email = '" + token["email"].ToString() + "' and deleted = 0"));
                int userID = Int32.Parse(userID1[0]["id"].ToString());
                for (int i = 0; i < LoginKeeper.Instance.loggedUsersList.Count; i++)
                {
                    if (LoginKeeper.Instance.loggedUsersList[i].userID == userID)
                    {
                        return ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeOK().message = LoginKeeper.Instance.loggedUsersList[i].token;
                    }
                }
                LoginKeeper.logonToken newLogonToken = new LoginKeeper.logonToken();
                newLogonToken.token = System.Guid.NewGuid().ToString();
                newLogonToken.userID = userID;
                newLogonToken.lastActionDate = DateTime.Now;
                LoginKeeper.Instance.loggedUsersList.Add(newLogonToken);
                return ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeOK().message = newLogonToken.token;
            }
            return ObjectsFactories.HTTPResponseFactory.GetObject().CreateCodeUnauthorized();
        }


        protected override List<User> Tokenize(string json)
        {
            List<User> users = new List<User>();
            //dodano try/catch gdyby JSON nie był poprawny
            try
            {
                JToken token = JToken.Parse(json);


                if (token is JArray)
                {
                    for (int i = 0; i < token.Count(); i++)
                    {
                        User newUser = new User();
                        try
                        {
                            newUser.id = (int)token[i]["ID"];
                        }
                        catch
                        {
                            newUser.id = -1;
                        }
                        newUser.firstName = token[i]["firstName"].ToString();
                        newUser.lastName = token[i]["lastName"].ToString();
                        newUser.email = token[i]["email"].ToString();
                        newUser.password = token[i]["password"].ToString();
                        newUser.sex = token[i]["sex"].ToString();
                        users.Add(newUser);
                    }
                    return users;
                }
                else
                {
                    User newUser = new User();
                    try
                    {
                        newUser.id = (int)token["ID"];
                    }
                    catch
                    {
                        newUser.id = -1;
                    }
                    newUser.firstName = token["firstName"].ToString();
                    newUser.lastName = token["lastName"].ToString();
                    newUser.email = token["email"].ToString();
                    newUser.password = token["password"].ToString();
                    newUser.sex = token["sex"].ToString();
                    users.Add(newUser);
                    return users;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return users;
            }
        }


    }
}
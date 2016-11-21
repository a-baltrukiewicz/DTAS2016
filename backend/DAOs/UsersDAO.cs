using backend.DataObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.DAOs
{
    class UsersDAO : AbstractDAO <User>
    {
        public UsersDAO() { }

        public List<User> GetAllUsers()
        {
            return ReceiveFromDatabase("select * from users");
        }

        public string SaveUsers(string json)
        {
            List<User> users = Tokenize(json);
            string comm = "insert into Users values ";
            foreach (User user in users)
            {
                comm += "('" + user.firstName + "', '" + user.lastName +
                    "', '" + user.email + "', '" + user.password + "', '" +
                    user.sex + ("'),");
            }
            comm = comm.Remove(comm.Length - 1);
            return SendToDatabase(comm);
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

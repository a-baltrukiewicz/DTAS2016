using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.DataObjects
{
    public class LoginKeeper
    {


        private static LoginKeeper instance;

        public static string sha256(string password)
        {
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            System.Text.StringBuilder hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        public int SearchIDByToken(string token)
        {
            for (int i=0; i<=LoginKeeper.Instance.loggedUsersList.Count; i++)
            {
                if (Equals(LoginKeeper.Instance.loggedUsersList[i].token, token))
                {
                    return LoginKeeper.Instance.loggedUsersList[i].userID;
                }
            }
            return -1;
        }

        public struct logonToken
        {
            public string token;
            public int userID;
            public DateTime lastActionDate;
        }
        public List<logonToken> loggedUsersList = new List<logonToken>();

        

        private LoginKeeper() { }

        public static LoginKeeper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginKeeper();
                }
                return instance;
            }
        }
    }







}


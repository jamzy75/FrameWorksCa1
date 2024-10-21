using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorksCA1
{
    internal class User
    {
        public int id;

        public string name;

        public string email;

        public string password;


        public int ID
        {
            get { return id; }
            set { id = value; }

        }

        public string Name
        {
            get { return name; }
            set { name = value; }

        }

        public string Email
        {
            get { return email; }
            set { email = value; }

        }

        public string Password
        {
            get { return password; }
            set { password = value; }

        }

        public User()
        {
        }

        // Full constructor
        public User(int id, string name, string email, string password)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;
        }



    }
}
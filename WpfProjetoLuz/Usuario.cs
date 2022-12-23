using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjetoLuz
{
    public class Usuario
    {
        private string name;
        private string email;
        private string password;
        private string id;

        public Usuario()
        {

        }

        public Usuario(string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;
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

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public Usuario Clone()
        {
            return (Usuario)this.MemberwiseClone();
        }
    }   

}

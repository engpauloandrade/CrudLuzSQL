using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjetoLuz
{
    public class Usuario : INotifyPropertyChanged
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
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    RaisePropertyChanged("Email");
                }
            }


        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    RaisePropertyChanged("Password");
                }
            }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        //-- implementação da interface INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public Usuario Clone()
        {
            return (Usuario)this.MemberwiseClone();
        }
    }   

}

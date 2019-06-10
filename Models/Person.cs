using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2WPF.Models
{
    public class Person : INotifyPropertyChanged
    {
        private string firstname;
        private string lastname;
        private string age;
        private string email;

        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
                //OnPropertyChanged(FirstName);
            }
        }

        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
                //OnPropertyChanged(LastName);
            }
        }

        public string Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                //OnPropertyChanged(Age);
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                //OnPropertyChanged(Email);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler ph = PropertyChanged;
            if(ph!=null)
            {
                ph(this, new PropertyChangedEventArgs(p));
            }
        }

        internal void Remove(Person person)
        {
            throw new NotImplementedException();
        }
    }
}

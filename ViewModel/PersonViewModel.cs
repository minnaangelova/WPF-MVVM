using hw2WPF.Models;
using hw2WPF.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Collections;

namespace hw2WPF.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person _person = new Person();

        public Person Person
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
                NotifyPropertyChanged("Person");
            }
        }

        private ObservableCollection<Person> _people = new ObservableCollection<Person>();

        public ObservableCollection<Person> People
        {
            get
            {
                return _people;
            }
            set
            {
                _people = value;
                NotifyPropertyChanged("People");
            }
        }


        private ICommand _SubmitCommand;

        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(SubmitExecute, CanSubmitExecute, false);
                }

                return _SubmitCommand;
            }
        }

        private void SubmitExecute(object parameter)
        {
            People.Add(Person);
        }

        private bool CanSubmitExecute(object parameter)
        {
            if (string.IsNullOrEmpty(Person.FirstName)
                || string.IsNullOrEmpty(Person.LastName)
                || string.IsNullOrEmpty(Person.Age)
                || string.IsNullOrEmpty(Person.Email))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private Person _selectedItem;
        public Person SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem == value)
                {
                    return;
                }

                _selectedItem = value;
                NotifyPropertyChanged("SelectedItem");
            }
        }

 

        private ICommand _DeleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new RelayCommand(DeleteExecute, CanDeleteExecute, false);
                }

                return _DeleteCommand;
            }
        }

               

        private void DeleteExecute(object parameter)
        {
         
            People.Remove(Person);
        }


        private bool CanDeleteExecute(object parameter)
        {
            if (string.IsNullOrEmpty(Person.FirstName)
              || string.IsNullOrEmpty(Person.LastName)
              || string.IsNullOrEmpty(Person.Age)
              || string.IsNullOrEmpty(Person.Email))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}

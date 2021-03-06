﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using User_Serialization.Commands;
using User_Serialization.Mediators;
using User_Serialization.Models;

namespace User_Serialization.ViewModels
{
    public class AddViewModel : INotifyPropertyChanged
    {
        private User newUser;

        public User NewUser
        {
            get { return newUser; }
            set
            {
                BindProperty(ref newUser, value);
            }
        }

        public SendUserPubSub SendUserPubSub { get; set; }
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand NewIdCommand { get; set; }

        public AddViewModel()
        {
            NewUser = new User();
            NewIdCommand = new DelegateCommand(NewId, null);
            AddCommand = new DelegateCommand(Add, CanAdd);
        }


        private void NewId(object o)
        {
            NewUser.Id = Guid.NewGuid();
        }
        private void Add(object o)
        {
            SendUserPubSub.Publish(NewUser);
            NewUser = new User();
        }
        private bool CanAdd(object arg)
        {
            return !NewUser.HasErrors && NewUser.FirstName != null && NewUser.LastName != null && NewUser.Username != null && NewUser.Email != null;
        }
        private void BindProperty<T>(ref T property, T value, [CallerMemberName]string propertyName = null)
        {
            property = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

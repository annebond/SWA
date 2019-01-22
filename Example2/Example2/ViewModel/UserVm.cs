using Example2.Model;
using System;
using System.Collections.ObjectModel;

namespace Example2.ViewModel
{
    public class UserVm
    {
        private User user;
        private ObservableCollection<Message> messages;

        public string Username
        {
            get { return user.Username; }
            set { user.Username = value; }
        }

        public ObservableCollection<Message> Messages
        {
            get { return messages; }
            set { messages = value; }
        }

        public UserVm(string username)
        {
            user = new User(username);
            messages = new ObservableCollection<Message>();
        }

        public void AddMessage(string msg)
        {
            if (msg != null)
            {
                messages.Add(new Message(msg, DateTime.Now.ToString("t")));
            }
        }

    }
}

using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;
using System.Collections.ObjectModel;

namespace CoisadiMae.Models
{
    public class Conversation : BaseEntity
    {
        public Mom Mom { get; set; }


        public Bot Bot { get; set; }

        public ObservableCollection<Message> Messages { get; set; }
    }
}
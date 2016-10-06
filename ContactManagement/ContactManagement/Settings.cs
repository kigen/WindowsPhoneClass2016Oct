using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement
{
   public  class Settings
   {
       private readonly Windows.Storage.ApplicationDataContainer _localSettings;
       public Settings()
       {
           _localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
       }

       public List<Contact> Contacts
       {
           get
           {
               return _localSettings.Values["contacts"] 
                   as List<Contact>;
           }

           set
           {
               _localSettings.Values["contacts"] = value;
           }
           
       } 





    }
}

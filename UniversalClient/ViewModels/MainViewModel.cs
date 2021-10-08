using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UniversalClient.ViewModelBase;

namespace UniversalClient.ViewModels
{
    class MainViewModel:ViewModel
    {
        private ICommand _sendMessageCommand;
        private static string _status;
        
        private static Socket _clientSocket = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
        private static string _ipAddress;
        public string IPAddressServer
        {
            get
            {
                return _ipAddress;
            }
            set
            {
                _ipAddress = value;
                OnPropertyChanged("IPAddress");
            }
        }

        public ICommand SendMessageCommand
        {
            get
            {
                if (_sendMessageCommand == null)
                {
                    _sendMessageCommand = new RelayCommand(c => ExecuteSendMessageCommand());
                }
                return _sendMessageCommand;
            }
        }

        private static void ExecuteSendMessageCommand()
        {
            try
            {
                _status = "Sending Message...";
                _clientSocket.Connect(IPAddress.Parse(_ipAddress), 666); 
                
            }
            catch (Exception)
            {

                throw;
            }
            _status = "Connected!";

            
        }
    }
}

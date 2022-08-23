using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Interface
{
    public interface IMessageService
    {
        void ShowMessage(string title, string message);
    }
}

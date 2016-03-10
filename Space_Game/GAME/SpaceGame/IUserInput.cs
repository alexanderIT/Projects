using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public interface IUserInput
    {
        event EventHandler OnLeftPressed;

        event EventHandler OnRightPressed;

        event EventHandler OnActionPressed;

        void ProcessInput();//proverqva dali i natisnato nalqvo ili nadqsno i ako e producira sabitieto OnRightPressed ....
    }
}

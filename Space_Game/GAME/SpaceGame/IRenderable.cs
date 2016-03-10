using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public interface IRenderable
    {
        MatrixCoords GetTopLeft();//vzima koordinati na obekta   

        char[,] GetImage();//vra6ta kak izglejda obecta
    }
}

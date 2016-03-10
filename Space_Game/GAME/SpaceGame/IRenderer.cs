using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public interface IRenderer
    {
        void EnqueueForRendering(IRenderable obj);//kazva ei tova trqbva da se narisuva v sledwa6tiq kadar

        void RenderAll();//risuva kadara v bufera i posle go mesti na konzolata

        void ClearQueue();//za4istva prostranstvoto za noviq kadyr,t.e pravi prazen list
    }
}

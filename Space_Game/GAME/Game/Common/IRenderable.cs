namespace Game.Common
{
    public interface IRenderable
    {
        MatrixCoords GetTopLeft();//take coord of objects 

        char[,] GetImage();
    }
}

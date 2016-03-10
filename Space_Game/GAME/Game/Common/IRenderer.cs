namespace Game.Common
{
    public interface IRenderer
    {
        void EnqueueForRendering(IRenderable obj);//says what has to be drawn in next frame

        void RenderAll();//draw frame in buffer and after move it on console

        void ClearQueue();//clear space for new frame and make empty list
    }
}

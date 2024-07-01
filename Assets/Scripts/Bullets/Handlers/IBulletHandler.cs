namespace Bullets.Handlers
{
    public interface IBulletHandler
    {
        // TODO: rewrite with DI.
        public static IBulletHandler Instance { get; set; }
        
        public void OnAddHandle(Bullet[] bullets, Bullet bullet);

        public void OnRemoveHandle(Bullet[] bullets, Bullet bullet);
    }
}
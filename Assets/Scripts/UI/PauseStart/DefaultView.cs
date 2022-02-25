namespace NotReaper.UI
{
    public class DefaultView : View
    {
        private RecentPanel recents;


        private void Awake()
        {
            recents = GetComponent<RecentPanel>();
        }
        public override void Show() 
        {
            recents.Show();
        }
        public override void Hide() 
        {
            recents.Hide();
        }
    }

}

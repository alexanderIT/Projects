namespace BlogSystem.Web.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

 

    public class SidebarViewModel
    {
        public IEnumerable<RecentBlogPostViewModel> RecentPosts { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }
    }
}
namespace BlogSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using BlogSystem.Data.Contracts;
    using BlogSystem.Data.Models;
    using BlogSystem.Web.ViewModels;


    public class SidebarController : BaseController
    {
        private readonly IRepository<BlogPost> blogPosts;
        private readonly IRepository<Tag> tags;

        public SidebarController(IRepository<BlogPost> blogPosts, IRepository<Tag> tags)
        {
            this.blogPosts = blogPosts;
            this.tags = tags;
        }

        [ChildActionOnly]
        [OutputCache(Duration = 10 * 60)]
        public ActionResult Index()
        {
            var model = new SidebarViewModel();
            model.RecentPosts = this.Cache.Get(
                "RecentBlogPosts",
                () =>
                this.blogPosts.All()
                    .OrderByDescending(x => x.CreatedOn)
                    .Project()
                    .To<RecentBlogPostViewModel>()
                    .Take(5)
                    .ToList(),
                600);

            model.Tags = this.tags.All().Project().To<TagViewModel>().OrderByDescending(x => x.PostsCount).ToList();
           

            return this.PartialView("_SidebarPartial", model);
        }
    }
}
using DataDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDB.Data
{
    public class DataDBInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        public DataDBInitializer() :base()
        {
            // CreateDatabaseIfNotExists<DataContext>
        }
        protected override void Seed(DataContext context)
        {
            base.Seed(context);

            #region User
            context.Users.Add(new User() { Id = 1, Email="cnavarro3196@gmail.com",Name="Carlos Navarro",Type= 2,Password= "ALf+7hLcEJtybEO6iJhf4nzoiIPmhWIll3KY8u5nFJox5d/ZYIuebgbot2dNnR75jA==" });
            #endregion

            #region Feed
            List<Feed> feeds = new List<Feed>();
            feeds.Add(new Feed() { Id = 1, FeedName = "Android Police", IsSubscribed=true, Image= "https://res-3.cloudinary.com/crunchbase-production/image/upload/c_lpad,h_256,w_256,f_auto,q_auto:eco/v1424946691/jpukpapfq2sw6oyt7gnn.png" });
            feeds.Add(new Feed() { Id = 2, FeedName = "9to5 Mac", IsSubscribed= true, Image= "https://res-2.cloudinary.com/crunchbase-production/image/upload/c_lpad,h_256,w_256,f_auto,q_auto:eco/y9bpkuhobwfldihvetuk" });
            feeds.Add(new Feed() { Id = 3, FeedName = "9to5 Google", IsSubscribed=true, Image= "https://res-5.cloudinary.com/crunchbase-production/image/upload/c_lpad,h_256,w_256,f_auto,q_auto:eco/v1424949370/kot3evc40bwghtzmbjri.png" });
            feeds.Add(new Feed() { Id = 4, FeedName = "ComicBook.com" , IsSubscribed=true, Image= "https://res-2.cloudinary.com/crunchbase-production/image/upload/c_lpad,h_256,w_256,f_auto,q_auto:eco/v1489443930/qlzwswdojhjfw8wvlqor.png" });

            feeds.ForEach(feed => context.Feeds.Add(feed));
            #endregion

            #region FeedItem
            List<FeedItem> feedItems = new List<FeedItem>();
            feedItems.Add(new FeedItem() {  FeedId = 1, Title = "OnePlus Launcher 4.4 brings updated app switcher to OnePlus phones",
                Content = "The app switcher on Android used to be a core part of the operating system, but with the introduction of gesture navigation, it's now a component of your device's home screen launcher. This means it can be updated outside of OS upgrades, and that's exactly what is happening on OnePlus devices. OnePlus Launcher 4.4 is now rolling out on the Play Store, and it brings a shiny new Recents interface with it. Before now, the app switcher interface consisted of a simple row of application previews, with a name and menu button above each item."
              , Date = DateTime.UtcNow });
            feedItems.Add(new FeedItem() {  FeedId = 1,
                Title = "TikTok passes one billion installs on the Play Store, boosted by the coronavirus pandemic",
                Content = "When stuck at home with little to do, people turn to social media. TikTok is amongst the most popular ones these days, as the app was the second most downloaded free app on the Play Store at the end of March. It's now so popular that it passed one billion installs on the Play Store. Although TikTok has been massively gaining popularity during the past year, it seems the ongoing pandemic has boosted its downloads. We've already seen the app grow from the third position in the free apps section to second, and it's now passed the one billion threshold.",
                Date = DateTime.UtcNow });
            feedItems.Add(new FeedItem() {  FeedId = 1, Title = "Instagram Live broadcasts can now be watched on the web",
                Content = "Instagram Live has become one of the largest platforms for personal streaming, but broadcasts were only viewable from the mobile app, which can be a drag for longer streams. Fortunately, Instagram has now added support for watching Live content from the web, so you can watch homebound celebrities from the comfort of a large screen. The mobile Instagram Live experience has comments scrolling up through a transparent window at the bottom of the video. If you're streaming with more than one person, comments can obstruct the view, making it difficult to pay attention to the video and chat simultaneously. ",
                Date = DateTime.UtcNow });

            feedItems.Add(new FeedItem() {  FeedId = 2, Title = "Report claims new iPad Pro’s A12Z Bionic chip is just a ‘renamed A12X with an enabled GPU core’"
                , Content = "Early benchmarks and reviews of the 2020 iPad Pro have indicated that performance is only marginally better than the 2018 iPad Pro. This year’s model features a new A12Z Bionic processor, but early indications from Notebook Check suggest there are minimal physical differences compared to the 2018 iPad Pro’s A12X Bionic processor. In its press release for the new iPad Pro, Apple said that one of the changes with the A12Z Bionic processor was the addition of an eighth GPU core. Notebook Check, however, claims that it has confirmed the A12X Bionic processor from 2018 actually features 8 GPU cores, but that one is disabled. This would imply that Apple has simply enabled that eighth GPU core and changed the marketing name of the processor."
                , Date = DateTime.UtcNow});
            feedItems.Add(new FeedItem() { FeedId = 2, Title = "Apple releases watchOS 6.2.1 with FaceTime Audio bug fixes",
                Content = "Apple has released watchOS 6.2.1 to the public today, bringing bug fixes and performance improvements specifically related to FaceTime. Today’s update for Apple Watch users comes following yesterday’s release of iOS 13.4.1 and iPadOS 13.4.1. watchOS 6.2.1 includes a fix for a FaceTime Audio bug that affected Apple Watch users."
                , Date = DateTime.UtcNow});

            feedItems.Add(new FeedItem()
            {
                FeedId = 3,
                Title = "Pixel 4 down to $499 on Google Store as $300 discount starts four months early"
               ,
                Content = "Google reported “declines in hardware” sales during its Q4 2019 earnings this February. That year-end period includes the busy holiday shopping season and the launch of Made by Google’s flagship phones. In a trend that carries over from last year, the Google Store today discounted the Pixel 4 to $499. A $300 discount sees the Pixel 4 start at $499 for 64GB, while $599 gets you a 128GB variant of the smaller phone or the entry Pixel 4 XL. Prices max out at $699 for a 4 XL with double the storage. This deal only applies to the unlocked Pixel 4 lineup, kicking off at midnight and lasting until May 9, 2020 at 11:59 p.m. PT."
               ,
                Date = DateTime.UtcNow
            });

            feedItems.Add(new FeedItem()
            {
                FeedId = 4,
                Title = "The Batman Set Photos Suggest A Long Halloween Setting"
               ,
                Content = "The Batman movie is now officially in production, which means DC Comics fans have been keep their eyes glued to the Internet for any kind of set photo or video reveals. Director Matt Reeves has manage to keep a veil of secrecy up on the exact details of the Batman reboot, but now there's some intriguing evidence about the film's possible comic book connections. New The Batman set photos have now popped up online, which seem to suggest the film will take place (at least in part) during Halloween. Naturally, that implication has longtime Batman fans buzzing that The Batman is indeed going to be based on the famous storyline of Batman: The Long Halloween"
                ,Date = DateTime.UtcNow
            });


            feedItems.ForEach(feedItem => context.FeedItems.Add(feedItem));
            #endregion

            #region UserFeed
            context.UserFeeds.Add(new UserFeed() { Id = 1, FeedId = 1, UserId = 1 });
            #endregion


            context.SaveChanges();
        }
    }
}

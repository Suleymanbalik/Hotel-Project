
using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DasboardSubscribeCountPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            // Instagram information

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/balikslymn"),
                Headers =
    {
        { "X-RapidAPI-Key", "62866b66e7mshb26ab835d6dcd1ep1f5a78jsn914b3e70e091" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ResultInstagramFollowersAndSubsDto resultInstagramFollowersAndSubsDtos = JsonConvert.DeserializeObject<ResultInstagramFollowersAndSubsDto>(body);
                ViewBag.InstagramFollowers = resultInstagramFollowersAndSubsDtos.followers;
                ViewBag.InstagramFollowing = resultInstagramFollowersAndSubsDtos.following;

            }



            // Twitter Information

            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter32.p.rapidapi.com/getProfile?username=baliksuleyman"),
                Headers =
    {
        { "X-RapidAPI-Key", "62866b66e7mshb26ab835d6dcd1ep1f5a78jsn914b3e70e091" },
        { "X-RapidAPI-Host", "twitter32.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ResultTwitterFollowersAndSubsDto resultTwitterFollowersAndSubsDto = JsonConvert.DeserializeObject<ResultTwitterFollowersAndSubsDto>(body2);
                ViewBag.TwitterFollowers = resultTwitterFollowersAndSubsDto.data.user_info.followers_count;
                ViewBag.TwitterFriends = resultTwitterFollowersAndSubsDto.data.user_info.friends_count;
                
            }

            // LinkedIn Information

            
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fsuleyman-balik-1006a1180%2F"),
                Headers =
    {
        { "X-RapidAPI-Key", "62866b66e7mshb26ab835d6dcd1ep1f5a78jsn914b3e70e091" },
        { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                ResultLinkedInFollowerAndSubsDto resultLinkedInFollowerAndSubsDto = JsonConvert.DeserializeObject<ResultLinkedInFollowerAndSubsDto>(body3);
                ViewBag.LinkedInFollowers = resultLinkedInFollowerAndSubsDto.data.followers_count;
                
            }
            return View();
        }
    }
}

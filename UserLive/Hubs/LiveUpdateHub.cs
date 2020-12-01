using BussinessOperation.Interfaces;
using Inferastructure.APIResponses;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserLive.Hubs
{
    public class LiveUpdateHub : Hub
    {
        private readonly IUserService  _userService;
        private IMemoryCache _cache;

        public LiveUpdateHub(IUserService userService, IMemoryCache memoryCache)
        {
            _userService = userService;
            _cache = memoryCache;
        }
        public override async Task OnConnectedAsync()
        {
            try
            {
                await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
                await base.OnConnectedAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void NewConnection(string connectionId, string groupType)
        {
            try
            {
                if (!string.IsNullOrEmpty(connectionId) && !string.IsNullOrEmpty(groupType))
                {
                    var client = SignalRExtensionMethods.CurrentConnections.FirstOrDefault(x => x.connections == connectionId);
                    if (client == null)
                    {
                        HubClientModel hubClientModel = new HubClientModel();
                        var context = Context.GetHttpContext();
                        hubClientModel.connections = connectionId;
                        hubClientModel.groupType = groupType;
                        SignalRExtensionMethods.CurrentConnections.Add(hubClientModel);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RemoveFromGroup(string connectionId, string groupType)
        {
            string groupName = "users_list_" + groupType;
            try
            {
                var client = SignalRExtensionMethods.CurrentConnections.FirstOrDefault(x => x.connections == connectionId);
                if (client != null)
                {
                    SignalRExtensionMethods.CurrentConnections.Remove(client);
                }

                await Startup.mMyHubContext.Groups.RemoveFromGroupAsync(connectionId, groupName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddInGroup(string connectionId, string groupType)
        {
            string groupName = "users_list_" + groupType;

            try
            {
                await Startup.mMyHubContext.Groups.AddToGroupAsync(connectionId, groupName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            try
            {
                var client = SignalRExtensionMethods.CurrentConnections.FirstOrDefault(a => a.connections == Context.ConnectionId);
                if (client != null)
                {
                    SignalRExtensionMethods.CurrentConnections.Remove(client);
                }
                return base.OnDisconnectedAsync(exception);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task SendNewUsersList()
        {
            string groupName = "";
            try
            {
                var client = SignalRExtensionMethods.CurrentConnections.Where(cc => !string.IsNullOrEmpty(cc.connections)).Select(a => new { a.groupType }).Distinct().ToList();
                //for inplay list
                if (client != null && client.Count() > 0)
                {
                    foreach (var groupslist in client)
                    {
                        groupName = "users_list_" + groupslist.groupType;
                        string cacheName = "userslist" + DateTime.Now.Date;
                        var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(5));
                        var userlist = _userService.GetMasterUsers();
                        var date = DateTime.Now.ToLocalTime();
                        _userService.AddDate(date);
                        _cache.Set(cacheName, userlist, cacheEntryOptions);
                        await Startup.mMyHubContext.Clients.Group(groupName).SendAsync("NewUsersList", userlist);
                    }
                }
            }
            catch (Exception ex)
            {
                var e = ex.Message;
            }
        }
    }
}

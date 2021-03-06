﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNewsCollection.Models;
using Xamarin.Auth;

namespace TwitterNewsCollection.Authentication
{
    public interface IAuthenticationService
    {
        Task<Account> LoginToTwitter();
        Task<List<RetwittedItem>> GetTwitterFeeds(Account userAccount);
    }
}
